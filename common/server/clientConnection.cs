//-----------------------------------------------------------------------------
// Torque Game Engine 
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------


//-----------------------------------------------------------------------------
// This script function is called before a client connection
// is accepted.  Returning "" will accept the connection,
// anything else will be sent back as an error to the client.
// All the connect args are passed also to onConnectRequest
//

function getRawIP(%client)
{
	%rawip = %client.getAddress();
	if(%rawip $= "local")
		return %rawip;

	//strip the "IP:"
	%finalip = getSubStr(%rawip, 3, 20);
	//find ":"
	%portstart = strstr(%finalip ,":");
	//strip off the port number
	%finalip = getSubStr(%finalip, 0, %portstart);

	return %finalip;
}

function GameConnection::onConnectRequest( %client, %netAddress, %name )
{
	echo("Connect request from: " @ %netAddress);

	%client.name = %name;
	
	//check ban list
	%ip = getRawIP(%client);
	%i = 0;
	for(%i = 0; %i <= $Ban::numBans; %i++)
	{
		echo("checking banlist ", %i);
		if(%ip $= $Ban::ip[%i])
		{
			return "You are banned.";
		}
	}

	if($Server::PlayerCount >= $pref::Server::MaxPlayers)
		return "CR_SERVERFULL";

	return "";
}

//-----------------------------------------------------------------------------
// This script function is the first called on a client accept
//
function GameConnection::onConnect( %client, %name )
{
	%client.connected = 1;
	commandToClient(%client, 'updatePrefs');
   // Send down the connection error info, the client is
   // responsible for displaying this message if a connection
   // error occures.
   messageClient(%client,'MsgConnectionError',"",$Pref::Server::ConnectionError);

   // Send mission information to the client
   sendLoadInfoToClient( %client );

   // Simulated client lag for testing...
   // %client.setSimulatedNetParams(0.1, 30);

   // Get the client's unique id:
   // %authInfo = %client.getAuthInfo();
   // %client.guid = getField( %authInfo, 3 );
   %client.guid = 0;
   addToServerGuidList( %client.guid );
   
   // Set admin status
   if (%client.getAddress() $= "local") {
      %client.isAdmin = true;
      %client.isSuperAdmin = true;
      %client.isXAdmin = true;
}
   else {
      %client.isAdmin = false;
      %client.isSuperAdmin = false;
      %client.isXAdmin = false;
      //Set all options to false < They were set to true automatically...
      %client.XadminNoob = false;
      %client.XAdminBurn = false;
      %client.XAdminSlap = false;
      %client.XAdminChgname = false;
      %client.XAdminRights = false;
      %client.XAdminSvrmsg = false;
      %client.XAdminAdmmsg = false;
      %client.XAdminKickAll = false;
      %client.XAdminMuteAll = false;
      %client.XAdminBanAll = false;
      %client.XAdminCop = false;
      %client.XAdminRob = false;
      %client.XAdminGoto = false;
      %client.XAdminBring = false;
   }

   // Save client preferences on the connection object for later use.
   %client.gender = "Male";
   %client.armor = "Light";
   %client.race = "Human";
   %client.skin = addTaggedString( "base" );
   %client.setPlayerName(%name);
   %client.score = 0;

   // 
   $instantGroup = ServerGroup;
   $instantGroup = MissionCleanup;
   echo("CADD: " @ %client @ " " @ %client.getAddress());

   // Inform the client of all the other clients
   %count = ClientGroup.getCount();
   for (%cl = 0; %cl < %count; %cl++) {
      %other = ClientGroup.getObject(%cl);
      if ((%other != %client)) {
         // These should be "silent" versions of these messages...
         messageClient(%client, 'MsgClientJoin', "", 
               %other.name,
               %other,
               %other.sendGuid,
               %other.score, 
               %other.isAIControlled(),
               %other.isAdmin, 
               %other.isSuperAdmin);
      }
   }

   // Inform the client we've joined up
   messageClient(%client,
      'MsgClientJoin', '\c2Welcome to Blockland %1.', 
      %client.name, 
      %client,
      %client.sendGuid,
      %client.score,
      %client.isAiControlled(), 
      %client.isAdmin, 
      %client.isSuperAdmin);

   // Inform all the other clients of the new guy
   messageAllExcept(%client, -1, 'MsgClientJoin', '\c1%1 joined the game.', 
      %client.name, 
      %client,
      %client.sendGuid,
      %client.score,
      %client.isAiControlled(), 
      %client.isAdmin, 
      %client.isSuperAdmin);

   // If the mission is running, go ahead download it to the client
   if ($missionRunning)
      %client.loadMission();
   $Server::PlayerCount++;
}

//-----------------------------------------------------------------------------
// A player's name could be obtained from the auth server, but for
// now we use the one passed from the client.
// %realName = getField( %authInfo, 0 );
//
function GameConnection::setPlayerName(%client,%name)
{
   %client.sendGuid = 0;

   // Minimum length requirements
   %name = stripTrailingSpaces( strToPlayerName( %name ) );
   if ( strlen( %name ) < 3 )
      %name = "Poser";

   // Make sure the alias is unique, we'll hit something eventually
   if (!isNameUnique(%client, %name))
   {
      %isUnique = false;
      for (%suffix = 1; !%isUnique; %suffix++)  {
         %nameTry = %name @ "." @ %suffix;
         %isUnique = isNameUnique(%client, %nameTry);
      }
      %name = %nameTry;
   }

   // Tag the name with the "smurf" color:
   %client.nameBase = %name;
   %client.name = addTaggedString("\cp\c8" @ %name @ "\co");
}

function isNameUnique(%client, %name)
{
   %count = ClientGroup.getCount();
   for ( %i = 0; %i < %count; %i++ )
   {
      %test = ClientGroup.getObject( %i );
	  if(%client != %test)
	  {
		  %rawName = stripChars( detag( getTaggedString( %test.name ) ), "\cp\co\c6\c7\c8\c9" );
		  if ( strcmp( %name, %rawName ) == 0 )
			 return false;
	  }
   }
   return true;
}

//-----------------------------------------------------------------------------
// This function is called when a client drops for any reason
//
function GameConnection::onDrop(%client, %reason)
{
	if(%client.connected == 1)
	{
	        %client.onClientLeaveGame();

		removeFromServerGuidList( %client.guid );
		messageAllExcept(%client, -1, 'MsgClientDrop', '\c1%1 has left the game.', %client.name, %client);

		removeTaggedString(%client.name);
		echo("CDROP: " @ %client @ " " @ %client.getAddress());


		$Server::PlayerCount--;

		// Reset the server if everyone has left the game
		if( $Server::PlayerCount == 0 && $Server::Dedicated && $Pref::Server::ResetOnEmpty)
			schedule(0, 0, "resetServerDefaults");
	}	
}


//-----------------------------------------------------------------------------

function GameConnection::startMission(%this)
{
   // Inform the client the mission starting
   commandToClient(%this, 'MissionStart', $missionSequence);
}


function GameConnection::endMission(%this)
{
   // Inform the client the mission is done
   commandToClient(%this, 'MissionEnd', $missionSequence);
}


//--------------------------------------------------------------------------
// Sync the clock on the client.

function GameConnection::syncClock(%client, %time)
{
   commandToClient(%client, 'syncClock', %time);
}


//--------------------------------------------------------------------------
// Update all the clients with the new score

function GameConnection::incScore(%this,%delta)
{
   %this.score += %delta;
   messageAll('MsgClientScoreChanged', "", %this.score, %this);
}
