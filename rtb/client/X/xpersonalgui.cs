//Xpersonalgui.cs > Copyright 2008 > MrX > http://www.mrx-rtb.co.nr/
//Personal GUI Functions

//Status function
function xsetstatus()
{
%status = txtsetstatus.getValue();
if(%status !$= "")
{
$Pref::player::Status = %status;
commandtoserver('setstatus',%status);
commandToClient(%client, 'updatePrefs');
}
else
{
chathud.addline("Please Enter A Status...");
}
}

//Open Website function
function xweb()
{
%url = txtweb.getValue();
if(%url !$= "")
{
gotowebpage(%url);
txtweb.setValue("");
}
else
{
chathud.addline("Please Enter A Site...");
}
}

//Matrix Button
function xmatrix()
{
if($timescale !$= "0.3")
{
$timescale=0.3;
}
else
{
$timescale=1;
}
}

//Quit button
function xquit()
{
xupdateprefs();
MessageBoxYesNo( "Exit?", "Are You Sure You Want To Exit?", "quit();", "");
}

//Update spawn message
function xspawn()
{
MessageBoxOK("Information", "Spawn Message Updated!");
%spawn=txtspawn.getvalue();
$Preff::x::Spawnmsg = %spawn;
}

//Clear bricks stuff 
function xclear()
{
commandtoServer('clearOwnBricks');
MessageBoxYesNo( "Destroy Bricks", "Are You Sure You Want To Clear ALL Your Bricks?", "xclearconfirmed();", "");
}

function xclearconfirmed()
{
commandtoServer('messagesent',"Yes");
chathud.addline("Your Bricks Have Been Cleared");
}

//Teleport to position
function xtelepos(%client, %x, %y, %z)
{
%x= xteleposx.getValue();
%y= xteleposy.getValue();
%z= xteleposz.getValue();
 
        if (%x !$="x" && %y !$="y" && %z !$="z")
        {
        commandtoserver('tp',%x,%y,%z);
        }
        else
        {
        chathud.addline("Please Enter A Valid Position");
        }
}