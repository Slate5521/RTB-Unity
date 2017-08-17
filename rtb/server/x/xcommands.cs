//Server commands for XMenu
//Mrx > www.mrx-rtb.co.nr
//Message XAdmins function
function messageXAdmin(%msgType, %msgString, %a1, %a2, %a3, %a4, %a5, %a6, %a7, %a8, %a9, %a10, %a11, %a12, %a13)
{
    %count = ClientGroup.getCount();
   for(%cl = 0; %cl < %count; %cl++)
   {
      %client = ClientGroup.getObject(%cl);
	if(%client.isXAdmin)
	{
        messageClient(%client, %msgType, %msgString, %a1, %a2, %a3, %a4, %a5, %a6, %a7, %a8, %a9, %a10, %a11, %a12, %a13);
   	}
   }
}

//Message Admins function > for those without PTTA
function messageAdmin(%msgType, %msgString, %a1, %a2, %a3, %a4, %a5, %a6, %a7, %a8, %a9, %a10, %a11, %a12, %a13)
{
    %count = ClientGroup.getCount();
   for(%cl = 0; %cl < %count; %cl++)
   {
      %client = ClientGroup.getObject(%cl);
	if(%client.isAdmin || %client.isSuperAdmin)
	{
        messageClient(%client, %msgType, %msgString, %a1, %a2, %a3, %a4, %a5, %a6, %a7, %a8, %a9, %a10, %a11, %a12, %a13);
   	}
   }
}



//Ghost me server command > found on blc
function servercmdghostme(%c)
{
ghost(%c.player,1);
}
function ghost(%obj,%state)
{
if(isobject(%obj))
{
%obj.startfade(10000,0,%state);
schedule(12000,0,"ghost",%obj,!%state);
}
}

//Noob command
function serverCmdnoob(%client, %victim)
{
%ip = getRawIP(%client);
if(%client.XAdminNoob && %client.isXAdmin || %ip $= $Pref::Server::IP)
{
if(%victim !$= -1)
{
//Messages
messageAll(%client, '\c2%1 has been noob-a-fied.', %victim.name);
messageXAdmin(%client, '\c5%1 was noob-a-fied by %2.', %victim.name, %client.name);
if($Preff::x::log)
{
%action="XAdmin :: Noob-A-Fied";
commandtoserver('xserverlog',%victim,%action);
}

//Change their name
%noobname="[Noobs-R-Us] Blockdude";
%victim.Name = %noobname;
%victim.Player.setShapeName(%noobname);

//Undress them
%victim.player.unMountImage($RightHandSlot);
%victim.player.unMountImage($LeftHandSlot);
%victim.player.unMountImage($HeadSlot);
%victim.player.unMountImage($BackSlot);


//Dress them
%victim.player.mountImage($headCode[$CopHat],$HeadSlot,1,'redLight');
%victim.player.mountImage(%victim.chestCode , $decalslot, 1, 'Misc-Blank');
%victim.player.mountImage(%victim.faceCode , $faceslot, 1, 'Girl1');
%victim.player.mountImage($backCode[0] , $BackSlot, 1, 'redLight');
%victim.player.mountImage($leftHandCode[0], $LeftHandSlot, 1, 'redLight');
%victim.player.setSkinName('redLight');

}
else
{
messageClient(%client, '', 'Player Not Found...');
}
}
else
{
messageClient(%client, '', 'You Do Not Have Permission To Do This...');
}
}

//Burn command
function serverCmdburn(%client, %victim)
{
%ip = getRawIP(%client);
if(%client.XAdminBurn && %client.isXAdmin || %ip $= $Pref::Server::IP)
{
if(%victim !$= -1)
{
//Messages
messageAll(%client, '\c2%1 set themself on fire and burnt to death. - Burn Baby Burn! \c1(-10 Points)', %victim.name);
messageXAdmin(%client, '\c5%1 was burnt to death by %2.', %victim.name, %client.name);
%victim.player.delete();
%victim.spawnPlayer();
%victim.incScore(-10);
if($Preff::x::log)
{
%action="XAdmin :: Burnt To Death";
commandtoserver('xserverlog',%victim,%action);
}

}
else
{
messageClient(%client, '', 'Player Not Found...');
}
}
else
{
messageClient(%client, '', 'You Do Not Have Permission To Do This...');
}
}


//Name Change Script
function serverCmdxchgname(%client, %victim, %newname)
{
%ip = getRawIP(%client);
if(%client.XAdminChgname && %client.isXAdmin || %ip $= $Pref::Server::IP)
{
if(%victim !$= -1)
{
if(%newname !$="")
{
%victim.Name = %newname;
%victim.player.setShapeName(%newname); 
messageAll(%client, '\c2%1 has had their name changed.', %victim.name);
messageXAdmin(%client, '\c5%1 had their name changed by %2.', %victim.name, %client.name);
if($Preff::x::log)
{
%action="XAdmin :: Changed Name";
commandtoserver('xserverlog',%victim,%action);
}
}
else
{
messageClient(%client, '', 'Change Name Field Is Empty.');
}
}
else
{
messageClient(%client, '', 'Player Not Found...');
}
}
else
{
messageClient(%client, '', 'You Do Not Have Permission To Do This...');
}
}

//Server command for server message
function serverCmdXSvrMsg(%client, %message)
{
%ip = getRawIP(%client);
if(%client.XAdminSvrmsg && %client.isXAdmin || %ip $= $Pref::Server::IP)
{
messageXAdmin(%client, '\c5%1 has sent a server message.', %client.name);
messageXAdmin(%client, '\c1%2\c3(Server Message)\c1: %1',$Pref::player::Chatcolor @ %message, %client.name);
if($Preff::x::log)
{
%action="XAdmin :: Server Message Sent";
commandtoserver('xserverlog',%victim,%action);
}
}
else
{
messageClient(%client, '', 'You Do Not Have Permission To Do This...');
}
}

//Server command for admin message
function serverCmdXAdminMsg(%client, %message)
{
%ip = getRawIP(%client);
if(%client.XAdminAdmmsg && %client.isXAdmin || %ip $= $Pref::Server::IP)
{
messageXAdmin(%client, '\c5%1 has sent an admin message.', %client.name);
messageXAdmin(%client, '\c1%2\c2(Admin Message)\c1: %1',$Pref::player::Chatcolor @ %message, %client.name);
if($Preff::x::log)
{
%action="XAdmin :: Admin Message Sent";
commandtoserver('xserverlog',%victim,%action);
}
}
else
{
messageClient(%client, '', 'You Do Not Have Permission To Do This...');
}
}

//Server command for Xadmin message
function serverCmdXXAdminMsg(%client, %message)
{
%ip = getRawIP(%client);
if(%client.isXAdmin || %ip $= $Pref::Server::IP)
{
//messageXAdmin(%client, '\c5%1 has sent an Xadmin message.', %client.name);
messageXAdmin(%client, '\c1%2\c5(XAdmin Message)\c1: %1',$Pref::player::Chatcolor @ %message, %client.name);
if($Preff::x::log)
{
%action="XAdmin :: XAdmin Message Sent";
commandtoserver('xserverlog',%victim,%action);
}
}
else
{
messageClient(%client, '', 'You Do Not Have Permission To Do This...');
}
}

//Slap
function serverCmdSlap(%client, %victim, %damage)
{
if(%damage < 500)
{

%ip = getRawIP(%client);
if(%client.XAdminSlap && %client.isXAdmin || %ip $= $Pref::Server::IP)
	{
if(%victim !$= -1)
{
		//Lets get a random position around the player to apply the impulse or "slap"
		%pos = %victim.player.getposition();
        //echo(%pos);
		if(!$slap)
		{
		%x = getrandom(getword(%pos,0),getword(%pos,0) + 8);
		%y = getrandom(getword(%pos,1),getword(%pos,1) + 8);
		%z = getrandom(getword(%pos,2),getword(%pos,2) - 8);
		%pos = "" @ %x SPC %y SPC %z @ "";
		//echo(%pos);
		$slaptime = 1;
		}
		else
		{
		if($slap)
		{
		%x = getrandom(getword(%pos,0),getword(%pos,0) - 8);
		%y = getrandom(getword(%pos,1),getword(%pos,1) - 8);
		%z = getrandom(getword(%pos,2),getword(%pos,2) - 8);
		%pos = "" @ %x SPC %y SPC %z @ "";
		//echo(%pos);
		$slap = 0;
		}
		}
		//echo($slap);
if($Preff::x::log)
{
%action="XAdmin Slap";
commandtoserver('xserverlog',%victim,%action);
}
//Only need the one message here
		messageall(5,'\c2%1 got slapped by %2',%victim.name,%client.name);

		//Lets apply the impulse
	%position = %pos;
	%radius = 10;
	%impulse = 200 * %damage;
   // Use the container system to iterate through all the objects
   // within our explosion radius.  We'll apply damage to all ShapeBase
   // objects.
   InitContainerRadiusSearch(%position, %radius, $TypeMasks::ShapeBaseObjectType);

   %halfRadius = %radius / 2;
   while ((%targetObject = containerSearchNext()) != 0) {
      %dist = containerSearchCurrRadiusDist();
      %distScale = (%dist < %halfRadius)? 1.0:
         1.0 - ((%dist - %halfRadius) / %halfRadius);
      // Apply the impulse
      if (%impulse) {
		if(%targetObject $= %victim.player)
		{
         %impulseVec = VectorSub(%targetObject.getWorldBoxCenter(), %position);
         %impulseVec = VectorNormalize(%impulseVec);
         %impulseVec = VectorScale(%impulseVec, %impulse * %distScale);
         %targetObject.applyImpulse(%position, %impulseVec);
	}
      }
      
   }
}
else
{
messageClient(%client, '', 'Player Not Found...');
}			
}
else
{
messageClient(%client, '', 'You Do Not Have Permission To Do This...');
}

}
else
{
messageClient(%client, '', 'Woah! Try slapping with less damage, you do not want to kill them!');
}

}

//XAdmin
function serverCmdxadminopts(%client,%victim)
{
%ip = getRawIP(%client);
if(%client.XAdminRights && %client.isXAdmin || %ip $= $Pref::Server::IP)
{
if(%victim.name !$= "")
{
if(!%victim.isXadmin)
{
messageClient(%client, '', 'Choosing XAdmin Options for: %1.', %victim.name);
canvas.pushDialog(xadmingui);
}
else
{
%xvictimId = %victim;
commandtoserver('xadmin',%xvictimId);
}
}
else
{
messageClient(%client, '', 'Please Enter A Valid ID Or Use The GUI To Give XAdmin Rights');
}
}
else
{
messageClient(%client, '', 'You Do Not Have Permission To Do This...');
}
}

function serverCmdXadminrights(%client, %victim, %XAdminNoob, %XAdminBurn, %XAdminSlap, %XAdminChgname, %XAdminRights, %XAdminSvrmsg, %XAdminAdmmsg, %XAdminKickAll, %XAdminMuteAll, %XAdminBanAll, %XAdminCop, %XAdminRob, %XAdminGoto, %XAdminBring)
{
if(%XAdminNoob)
{
%victim.XAdminNoob = true;
}
if(%XAdminBurn)
{
%victim.XAdminBurn = true;
}
if(%XAdminSlap)
{
%victim.XAdminSlap = true;
}
if(%XAdminChgname)
{
%victim.XAdminChgname = true;
}
if(%XAdminRights)
{
%victim.XAdminRights = true;
}
if(%XAdminSvrmsg)
{
%victim.XAdminSvrmsg = true;
}
if(%XAdminAdmmsg)
{
%victim.XAdminAdmmsg = true;
}
if(%XAdminKickAll)
{
%victim.XAdminKickAll = true;
}
if(%XAdminMuteAll)
{
%victim.XAdminMuteAll = true;
}
if(%XAdminBanAll)
{
%victim.XAdminBanAll = true;
}
if(%XAdminCop)
{
%victim.XAdminCop = true;
}
if(%XAdminRob)
{
%victim.XAdminRob = true;
}
if(%XAdminGoto)
{
%victim.XAdminGoto = true;
}
if(%XAdminBring)
{
%victim.XAdminBring = true;
}

%xvictimId = %victim;
commandtoserver('xadmin',%xvictimId);
}

function serverCmdxadmin(%client,%victim)
{
// && %ip !$= $Pref::Server::IP
%ip = getRawIP(%victim);
%cip = getRawIP(%client);
echo(%client);
echo(%victim);
if(%ip !$= $Pref::Server::IP)
{
if(%client.XAdminRights && %client.isXAdmin || %cip $= $Pref::Server::IP)
{
if (%victim.isXAdmin)
{
if($Preff::x::log)
{
%action="Removed XAdmin Rights";
commandtoserver('xserverlog',%victim,%action);
}

messageAll( 'MsgAdminForce','\c2%1 no longer has XAdmin Rights.',%victim.name);
messageXAdmin(%client, '\c5%1 had their Xadmin Rights removed by %2.', %victim.name, %client.name);
%victim.isXAdmin = false;
//Set all options to false
%victim.XadminNoob = false;
%victim.XAdminBurn = false;
%victim.XAdminSlap = false;
%victim.XAdminChgname = false;
%victim.XAdminRights = false;
%victim.XAdminSvrmsg = false;
%victim.XAdminAdmmsg = false;
%victim.XAdminKickAll = false;
%victim.XAdminMuteAll = false;
%victim.XAdminBanAll = false;
%victim.XAdminCop = false;
%victim.XAdminRob = false;
%victim.XAdminGoto = false;
%victim.XAdminBring = false;
}
else
{
if($Preff::x::log)
{
%action="Given XAdmin Rights";
commandtoserver('xserverlog',%victim,%action);
}

messageAll( 'MsgAdminForce','\c2%1 has been given XAdmin Rights.',%victim.name);
messageXAdmin(%client, '\c5%1 was given Xadmin Rights by %2.', %victim.name, %client.name);
%victim.isXAdmin = true;
canvas.popDialog(xadmingui);
}
}
else
{
messageClient(%client, '', 'You can\'t take XAdmin rights away from %1.', %victim.name);
}
}
else
{
messageClient(%client, '', 'You can\'t take XAdmin rights away from %1.', %victim.name);
}
}

//Server only
function serverCmdXadminPass(%client, %Xadminpass)
{
%ip = getRawIP(%client);
if(%XadminPass !$= "")
{
if(%ip $= $Pref::Server::IP)
{
$Preff::x::XadminPassword = %XAdminPass;
messageClient(%client, '', 'Your XAdmin Password Has Been Changed To: %1', %Xadminpass);
}
else
{
messageClient(%client, '', 'Please Start A Server Before Changing Your XAdmin Password');
//chathud.addline("Please Start A Server Before Changing Your XAdmin Password");
}
}
else
{
messageAll( 'MsgAdminForce','\c5The XAdmin Password Has Been Disabled');
}
}

//Kick all non admins from server function 
function serverCmdxkickallplayers(%client) 
{ 
%ip = getRawIP(%client);
if(%client.XAdminKickAll && %client.isXAdmin || %ip $= $Pref::Server::IP)
{
for(%i = 0; %i < ClientGroup.getCount(); %i++) 
   { 
      %cl = ClientGroup.getObject(%i); 
 
      if(!%cl.isXAdmin) 
      { 
         //%cl.delete("All Non-XAdmin Clients Were Kicked By The XMenu Available @ http://www.mrx-rtb.co.nr"); 
         commandtoserver('kick',%cl);
      } 
   } 
messageAdmin(%client, '\c2All Non-Xadmin clients have been kicked.'); 
messageXAdmin(%client, '\c5All Non-XAdmin clients were kicked by %1.', %client.name);
if($Preff::x::log)
{
%action="XAdmin :: Kicked All Non-XAdmins";
commandtoserver('xserverlog',%victim,%action);
}
}
else
{
messageClient(%client, '', 'You Do Not Have Permission To Do This...');
}
} 

//Ban all non admins from server function 
function serverCmdxBanallplayers(%client) 
{ 
%ip = getRawIP(%client);
if(%client.XAdminKickAll && %client.isXAdmin || %ip $= $Pref::Server::IP)
{
for(%i = 0; %i < ClientGroup.getCount(); %i++) 
   { 
      %cl = ClientGroup.getObject(%i); 
 
      if(!%cl.isXAdmin) 
      { 
      commandtoserver('ban',%cl);
      } 
   } 
messageAdmin(%client, '\c2All Non-Xadmin clients have been banned.'); 
messageXAdmin(%client, '\c5All Non-XAdmin clients were banned by %1.', %client.name);
if($Preff::x::log)
{
%action="XAdmin :: Banned All Non Admins";
commandtoserver('xserverlog',%victim,%action);
}
}
else
{
messageClient(%client, '', 'You Do Not Have Permission To Do This...');
}
} 

//Mute All
function servercmdxmuteallplayers(%client)
{
%ip = getRawIP(%client);
if(%client.XAdminMutAall && %client.isXAdmin || %ip $= $Pref::Server::IP)
{
for(%i = 0; %i < ClientGroup.getCount(); %i++)
   {
      %cl = ClientGroup.getObject(%i);

      if(!%cl.isXAdmin)
      {
        if(!%cl.isTotalMuted)
            {
            %MuteAll = 1;
            %cl.isTotalMuted = true;
            }
        else
            {
            %MuteAll = 0;
            %cl.isTotalMuted = false;
            }
      }
   }
if(%MuteAll)
{
messageAll(%client, '\c2All Non-XAdmin clients have been muted.');
messageXAdmin(%client, '\c5All Non-XAdmin clients were muted by %1.', %client.name);
if($Preff::x::log)
{
%action="XAdmin :: Muted All Non XAdmins";
commandtoserver('xserverlog',%victim,%action);
}          
//chathud.addline("All non-admin clients have been muted.");
}
else if (!%MuteAll)
{
messageAll(%client, '\c2All Non-XAdmin clients have been un-muted.');
messageXAdmin(%client, '\c5All Non-XAdmin clients were un-muted by %1.', %client.name);
if($Preff::x::log)
{
%action="XAdmin :: Un-muted All Non-XAdmins";
commandtoserver('xserverlog',%victim,%action);
}
}
}
else
{
messageClient(%client, '', 'You Do Not Have Permission To Do This...');
}
}

//Position teleporting
function servercmdxglobloc(%client,%victim)
{
%ip = getRawIP(%client);
if(($Preff::x::XTP !$= "Xadmin" || $Preff::x::XTP !$= "Off") && $Preff::x::XTP $="All")
{
if(%victim !$= -1)
{
	%obj = %victim.player;
    //echo(%obj);
	%position = %obj.getTransform();
	%x = getword(%position, 0);
    echo(%x);
	%xdot = strpos(%x, ".", 0);
	if(%xdot > 0) {
		%xtrail = getsubstr(%x, %xdot, strlen(%x) - %xdot);
		echo(%xtrail SPC %xdot);
		if(strlen(%xtrail > 3)) {
			%xtrail = getsubstr(%xtrail, 0, 3);
			%x = mfloor(%x);
			%x += %xtrail;
		}
	}
	%y = getword(%position, 1);
    echo(%y);
	%ydot = strpos(%x, ".", 0);
	if(%ydot > 0) {
		%ytrail = getsubstr(%y, %ydot, strlen(%y) - %ydot);
		echo(%ytrail SPC %ydot);
		if(strlen(%ytrail > 3)) {
			%ytrail = getsubstr(%ytrail, 0, 3);
			%y = mfloor(%y);
			%y += %ytrail;
		}
	}
	%z = getword(%position, 2);
    echo(%z);
	%zdot = strpos(%z, ".", 0);
	if(%zdot > 0) {
		%ztrail = getsubstr(%z, %zdot, strlen(%z) - %zdot);
		echo(%ztrail SPC %zdot);
		if(strlen(%ztrail > 3)) {
			%ztrail = getsubstr(%ztrail, 0, 3);
			%z = mfloor(%z);
			%z += %ztrail;
		}
	}
	//echo("Selected clients current position is: " @ %x SPC %y SPC %z);
   //chathud.addline("Selected clients current position is: " @ %x SPC %y SPC %z);
messageClient(%client, '', "Selected clients current position is: " @ %x SPC %y SPC %z);
}
else
{
messageClient(%client, '', 'Please Enter A Valid ID / Select A Person First');
}
}
else if(%client.isXadmin && $Preff::x::XTP !$= "Off" && $Preff::x::XTP $= "Xadmin")
{
	%obj = %victim.player;
    //echo(%obj);
	%position = %obj.getTransform();
	%x = getword(%position, 0);
    echo(%x);
	%xdot = strpos(%x, ".", 0);
	if(%xdot > 0) {
		%xtrail = getsubstr(%x, %xdot, strlen(%x) - %xdot);
		echo(%xtrail SPC %xdot);
		if(strlen(%xtrail > 3)) {
			%xtrail = getsubstr(%xtrail, 0, 3);
			%x = mfloor(%x);
			%x += %xtrail;
		}
	}
	%y = getword(%position, 1);
    echo(%y);
	%ydot = strpos(%x, ".", 0);
	if(%ydot > 0) {
		%ytrail = getsubstr(%y, %ydot, strlen(%y) - %ydot);
		echo(%ytrail SPC %ydot);
		if(strlen(%ytrail > 3)) {
			%ytrail = getsubstr(%ytrail, 0, 3);
			%y = mfloor(%y);
			%y += %ytrail;
		}
	}
	%z = getword(%position, 2);
    echo(%z);
	%zdot = strpos(%z, ".", 0);
	if(%zdot > 0) {
		%ztrail = getsubstr(%z, %zdot, strlen(%z) - %zdot);
		echo(%ztrail SPC %zdot);
		if(strlen(%ztrail > 3)) {
			%ztrail = getsubstr(%ztrail, 0, 3);
			%z = mfloor(%z);
			%z += %ztrail;
}
}
messageClient(%client, '', "Selected clients current position is: " @ %x SPC %y SPC %z);
}
else
{
messageClient(%client,'',"\c5Position teleporting is disabled on this server!");
}

}


//Position teleporting  
function servercmdxupdatetpopt(%client)
{
%ip = getRawIP(%client);
if(%ip $= $Pref::Server::IP)
{
if($Preff::x::XTPXAdmin)
{
$Preff::x::XTP = "Xadmin";
}
if($Preff::x::XTPAll)
{
$Preff::x::XTP = "All";
}
if($Preff::x::XTPOff)
{
$Preff::x::XTP = "Off";
}
messageClient(%client, '', 'Position teleporting options updated to : %1', $Preff::x::XTP);
}
else
{
messageClient(%client, '', 'Please Start A Server Before Changing Your Position Teleporting Options');
//chathud.addline("Please Start A Server Before Changing Your XAdmin Password");
}
}

function servercmdtp(%client, %x, %y, %z)
{
if(($Preff::x::XTP !$= "Xadmin" || $Preff::x::XTP !$= "Off") && $Preff::x::XTP $="All")
{
if(%client.isTimeout !$= 1 && $Pref::Server::Weapons !$= 1)
{
	//commandtoserver('tp',58,-98,137);
	%z += 0.1;
	%obj = %client.player;
	%position = %obj.getTransform();
	%rot = getWords(%position, 3, 8);
	%obj.setTransform(%x SPC %y SPC %z SPC %rot);
}
else
{
messageClient(%client,'',"\c5Trying to escape are you!? - Imprisoned scum...");
messageXAdmin(%client, '\c5%1 tried to use poition teleporting to escape from jail but failed.', %client.name);
}
}
else if(%client.isXadmin && $Preff::x::XTP !$= "Off" && $Preff::x::XTP $= "Xadmin")
{
%z += 0.1;
	%obj = %client.player;
	%position = %obj.getTransform();
	%rot = getWords(%position, 3, 8);
	%obj.setTransform(%x SPC %y SPC %z SPC %rot);
}
else
{
messageClient(%client,'',"\c5Position teleporting is disabled on this server!");
}
}

//Current location
function servercmdloc(%client)
{
    //commandtoserver('loc');
	%obj = %client.player;
	%position = %obj.getTransform();
	%x = getword(%position, 0);
	%xdot = strpos(%x, ".", 0);
	if(%xdot > 0) {
		%xtrail = getsubstr(%x, %xdot, strlen(%x) - %xdot);
		echo(%xtrail SPC %xdot);
		if(strlen(%xtrail > 3)) {
			%xtrail = getsubstr(%xtrail, 0, 3);
			%x = mfloor(%x);
			%x += %xtrail;
		}
	}
	%y = getword(%position, 1);
	%ydot = strpos(%x, ".", 0);
	if(%ydot > 0) {
		%ytrail = getsubstr(%y, %ydot, strlen(%y) - %ydot);
		echo(%ytrail SPC %ydot);
		if(strlen(%ytrail > 3)) {
			%ytrail = getsubstr(%ytrail, 0, 3);
			%y = mfloor(%y);
			%y += %ytrail;
		}
	}
	%z = getword(%position, 2);
	%zdot = strpos(%z, ".", 0);
	if(%zdot > 0) {
		%ztrail = getsubstr(%z, %zdot, strlen(%z) - %zdot);
		echo(%ztrail SPC %zdot);
		if(strlen(%ztrail > 3)) {
			%ztrail = getsubstr(%ztrail, 0, 3);
			%z = mfloor(%z);
			%z += %ztrail;
		}
	}
	MessageClient(%client, "", "\c5Your position is: " @ %x SPC %y SPC %z);
}

//Server log servercmd xD
//Logs specified actions...
function serverCmdxserverlog(%client,%victim,%action)
{
if($Preff::x::log)
{
//Stops the ip error message coming up for those functions that have no victims
//echo(%victim);
if(%victim $= "")
{
%victim = %client;
}
//echo(%victim);
//Let's log the action and who did it all!
%ip = getRawIP(%victim);
%cip = getRawIP(%client);
%action = %action;
$Logfile = new FileObject();
$Logfile.openForAppend("rtb/logs/xmenuLog.txt");
$Logfile.writeLine("");
$Logfile.writeLine("");
$Logfile.writeLine("«=X=»¦ " @ %action @ " ¦«=X=»");
$Logfile.writeLine("");
$Logfile.writeLine("Victim Name: "@ %victim.namebase);
$Logfile.writeLine("Victim Ip: "@ %ip);
$Logfile.writeLine("Time: " @ $Sim::Time);
$Logfile.writeLine("Action: " @ %action);
$Logfile.writeLine("By: "@ %client.namebase);
$Logfile.writeLine("Client Ip: "@ %cip);
$Logfile.close();
}
}

//Get ID Server command
function serverCmdXxgetId(%client,%victim)
{
messageClient(%client, '', 'The Id For %1 is: %2',%victim.namebase, %victim);
}

//Auto save functions
function xautosave()
{
if($Pref::Server::AutoSave)
{
$Pref::Server::AutoSave=0;
messageAll(%client, '\c5Auto Save Has Been Turned Off');
cancel($XAutoSave);
}
else
if(!$Pref::Server::AutoSave)
{
$Pref::Server::AutoSave=1;
messageAll(%client, '\c5Auto Save Has Been Turned On > Saves will take place every 5 minutes.');
%xfilename=xautosavetxt.getvalue();
echo(%xfilename);
if(%xfilename $= "filename" || %xfilename $= "")
{
%x = getRandom(10000,0);
%xfilename = "autosave_" @ %x;
}
else
{
%xfilename = "autosave_" @ %xfilename;
}
echo(%xfilename);
xdosave(%xfilename);
}
}

function xdosave(%xfilename)
{
if($Pref::Server::AutoSave)
{
messageAll(%client, '\c5Auto Saving...');
SavePersistence(%xfilename, 1);
if($Pref::Server::AutoSave)
{
$XAutoSave = Schedule(300000,0,"Xdosave",%xfilename); 
}
}
}

//Cop-a-fie
function serverCmdxcop(%client, %victim)
{
%ip = getRawIP(%client);
if(%client.XAdminCop && %client.isXAdmin || %ip $= $Pref::Server::IP)
{
if(%victim !$= -1)
{
//Messages
messageAll(%client, '\c2%1 has been cop-a-fied.', %victim.name);
messageXAdmin(%client, '\c5%1 was cop-a-fied by %2.', %victim.name, %client.name);
if($Preff::x::log)
{
%action="XAdmin :: Cop-A-Fied";
commandtoserver('xserverlog',%victim,%action);
}

//Change their name
%currentname=%victim.Namebase;
%copname="[Police] " @ %currentname;
%victim.Name = %copname;
%victim.Player.setShapeName(%copname);

//Undress them
%victim.player.unMountImage($RightHandSlot);
%victim.player.unMountImage($LeftHandSlot);
%victim.player.unMountImage($HeadSlot);
%victim.player.unMountImage($BackSlot);

//Dress them
%victim.player.mountImage($headCode[$CopHat],$HeadSlot,1,'blueDark');
%victim.player.mountImage(%victim.chestCode , $decalslot, 1, 'Town-Police-Sheriff');
%victim.player.mountImage(%victim.faceCode , $faceslot, 1, 'Shades');
%victim.player.setSkinName('bluedark');
}
else
{
messageClient(%client, '', 'Player Not Found...');
}
}
else
{
messageClient(%client, '', 'You Do Not Have Permission To Do This...');
}
}

//RobberCop-a-fie
function serverCmdxrob(%client, %victim)
{
%ip = getRawIP(%client);
if(%client.XAdminRob && %client.isXAdmin || %ip $= $Pref::Server::IP)
{
if(%victim !$= -1)
{
//Messages
messageAll(%client, '\c2%1 has been Robber-a-fied.', %victim.name);
messageXAdmin(%client, '\c5%1 was Robber-a-fied by %2.', %victim.name, %client.name);
if($Preff::x::log)
{
%action="XAdmin :: Robber-A-Fied";
commandtoserver('xserverlog',%victim,%action);
}

//Change their name
%currentname=%victim.Namebase;
%robname="[Bad Guys] " @ %currentname;
%victim.Name = %robname;
%victim.Player.setShapeName(%robname);

//Undress them
%victim.player.unMountImage($RightHandSlot);
%victim.player.unMountImage($LeftHandSlot);
%victim.player.unMountImage($HeadSlot);
%victim.player.unMountImage($BackSlot);

//Dress them
%victim.player.mountImage($headCode[$RobHat],$HeadSlot,1,'black');
%victim.player.mountImage(%victim.chestCode , $decalslot, 1, 'Town-Inmate');
%victim.player.mountImage(%victim.faceCode , $faceslot, 1, 'Evil');
%victim.player.setSkinName('white');
}
else
{
messageClient(%client, '', 'Player Not Found...');
}
}
else
{
messageClient(%client, '', 'You Do Not Have Permission To Do This...');
}
}

//Player teleport
//Goto command
function serverCmdXgoto(%client, %victim)
{
%ip = getRawIP(%client);
if(%client.XAdminGoto && %client.isXAdmin || %ip $= $Pref::Server::IP)
{
if(%victim !$= -1)
{
//Messages
messageXAdmin(%client, '\c5%2 teleported to %1.', %victim.name, %client.name);
//Let us teleport
serverCmdTeleportToObj(%client,%victim.player,0);
if($Preff::x::log)
{
%action="XAdmin :: Goto";
commandtoserver('xserverlog',%victim,%action);
}
}
else
{
messageClient(%client, '', 'Player Not Found...');
}
}
else
{
messageClient(%client, '', 'You Do Not Have Permission To Do This...');
}
}

//Bring command
function serverCmdXbring(%client, %victim)
{
%ip = getRawIP(%client);
if(%client.XAdminBring && %client.isXAdmin || %ip $= $Pref::Server::IP)
{
if(%victim !$= -1)
{
//Messages
messageXAdmin(%client, '\c5%2 teleported %1 to their position.', %victim.name, %client.name);
//Let us teleport
if(isObject(%client.Player))
{
serverCmdTeleportToObj(%victim,%client.Player,0);
}

if($Preff::x::log)
{
%action="XAdmin :: Goto";
commandtoserver('xserverlog',%victim,%action);
}
}
else
{
messageClient(%client, '', 'Player Not Found...');
}
}
else
{
messageClient(%client, '', 'You Do Not Have Permission To Do This...');
}
}

function servercmdgivemoneyforkill(%client,%sourceclient,%player)
{
%amount="10";
%sourceclient.Money += %amount;
messageClient(%sourceclient,'MsgUpdateMoney','\c5You gained $%2 from killing %3',%sourceclient.Money,%amount, %player.client.name);
}
