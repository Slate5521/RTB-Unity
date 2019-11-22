//-----------------------------------------------------------------------------
// Torque Game Engine 
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

//-----------------------------------------------------------------------------
// Misc. server commands avialable to clients
//-----------------------------------------------------------------------------

//-----------------------------------------------------------------------------

function serverCmdSAD( %client, %password )
{
	if($Pref::Server::AdminForce $= 0) {
		if( %password !$= "" && %password $= $Preff::x::XadminPassword) {
			messageAll('','\c2%1 Has Used The XAdmin Password To Gain FULL XAdmin Rights',%client.name);
			messageClient(%client, '', '\c5You now have FULL Xadmin Rights!');
			
			%client.isXAdmin = true;
			%client.setPrivilegeLevel($Priv::XAdmin);
			
			//Set all options to true
			// %client.XadminNoob = true;
			// %client.XAdminBurn = true;
			// %client.XAdminSlap = true;
			// %client.XAdminChgname = true;
			// %client.XAdminRights = true;
			// %client.XAdminSvrmsg = true;
			// %client.XAdminAdmmsg = true;
			// %client.XAdminKickAll = true;
			// %client.XAdminMuteAll = true;
			// %client.XAdminBanAll = true;
			// %client.XAdminCop = true;
			// %client.XAdminRob = true;
			// %client.XAdminGoto = true;
			// %client.XAdminBring = true;
			
			//Might as well give them an ew :P
			%client.isEWandUser = 1;
			if($Preff::x::log) {
				%action="XAdmin :: Used Xadmin Password To Gain FULL Rights.";
				commandtoserver('xserverlog',%victim,%action);
			}
		}
		
		if( %password !$= "" && %password $= $Pref::Server::AdminPassword && !%client.isUnAdmined) {
			
			%client.isAdmin = true;
			%client.isSuperAdmin = true;
			%client.setPrivilegeLevel($Priv::SuperAdmin);
			
			%name = getTaggedString( %client.name );
			MessageAll( 'MsgAdminForce', "\c2" @ %name @ " is now a Super Admin.", %client );   
			messageAll('MsgClientJoin', '', 
				%client.name, 
				%client,
				%client.sendGuid,
				%client.score,
				%client.isAiControlled(), 
				%client.isAdmin, 
				%client.isSuperAdmin);
			if($Pref::Server::Log)
			{
				$Logfile = new FileObject();
				$Logfile.openForAppend("rtb/server/ServerLog.txt");
				$Logfile.writeLine(">>*ADMIN BY FORCE*<<");
				$Logfile.writeLine("Name: "@ %client.namebase @ " ip: " @getrawip(%client)@ " Time: " @ $Sim::Time);
				$Logfile.close();
			}		
		}
		else if(%password !$= $Preff::x::XadminPassword && %password !$= $Pref::Server::WandPassword && %password !$=$Pref::Server::TempAdminPassword && !%client.isUnAdmined) {
			%client.adminTries++;
			if(%client.adminTries > 3) {
				messageAll( 'MsgAdminForce', '\c2%1 has failed to guess the admin password.', %client.name);
				%client.delete("You guessed the admin pass wrong.");
			}
		}
	}
	else {
		messageClient(%client, '', 'Force Admin is \c3OFF.');
	}
}


function serverCmdSADSetPassword(%client, %password)
{
   if(%client.isSuperAdmin)
	{
      $Pref::Server::AdminPassword = %password;
	messageAll('MsgAdminForce', '\c3WARNING:\c2 The Admin Password has been changed by %1.', %client.name);
	messageAdmin('','\c2Pass is now: \c3%1',$Pref::Server::AdminPassword);
	}
}

function serverCmdSetSvrMsg(%client, %message)
{
if(%client.isSuperAdmin)
{
$Pref::Server::AdvertMessage = %message;
messageAdmin('','\c2New Advert Server Message: %1',$Pref::Server::AdvertMessage);
}
}


//----------------------------------------------------------------------------
// Server chat message handlers

function serverCmdTeamMessageSent(%client, %text)
{
	%obj = %client.player;
	%obj.playthread(0, talk);				//fwar play talk animation
	%obj.schedule(strlen(%text) * 50 , stopthread, 0);


   if(strlen(%text) >= $Pref::Server::MaxChatLen)
      %text = getSubStr(%text, 0, $Pref::Server::MaxChatLen);
   chatMessageTeam(%client, %client.team, '\c3%1: %2', %client.name, %text);
   echo("(T)", getTaggedString(%client.name), ": ", %text);
}

function serverCmdMessageSent(%client, %text)
{
%Chg = $Sim::Time - %client.JoinTime;
if(%Chg > 2 || %client.isAlreadyHere || $Pref::Server::EnterMsg)
{
	
	%obj = %client.player;
	%obj.playthread(0, talk);				//fwar play talk animation
	%obj.schedule(strlen(%text) * 50, stopthread, 0);

   if(strlen(%text) >= $Pref::Server::MaxChatLen)
      %text = getSubStr(%text, 0, $Pref::Server::MaxChatLen);
   chatMessageAll(%client, '\c4%1: %2', %client.name, %text);
   echo(getTaggedString(%client.name), ": ", %text);
%client.isAlreadyHere = true;
}
else
messageClient(%client,'','\c1Server enter messages are \c3DISABLED\c1 on this server');
}

