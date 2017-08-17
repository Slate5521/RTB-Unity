//Xservergui.cs > Copyright 2008 > MrX > http://www.mrx-rtb.co.nr/
//Server GUI Functions
//Kick all non admins from server
function kickallserver()
{
commandtoserver('xkickallplayers');
}

//Mute all non admins
function Xmuteall()
{
commandtoserver('xmuteallplayers');
}


//Ban all non admins
function Xbanall()
{
commandtoserver('xbanallplayers');
}

//Server message
function xsvrmsg()
{
%message = xsvrmsg.getValue();
commandtoserver('xsvrmsg',%message);
xsvrmsg.setValue("");
}

//Admin Message
function xadminmsg()
{
%message = xadminmessage.getValue();
commandtoserver('xAdminmsg',%message);
xadminmessage.setValue("");
}

//XAdmin Message
function xxadminmsg()
{
%message = xxadminmessage.getValue();
commandtoserver('xxAdminmsg',%message);
xxadminmessage.setValue("");
}

//Position teleporting
function xupdatetp()
{
$Preff::x::XTPXAdmin = XTPXadmin.getValue();
$Preff::x::XTPAll = XTPAll.getValue();
$Preff::x::XTPOff = XTPOff.getValue();
commandtoserver('xupdatetpopt');
}

//Leave game message
function xleavegame()
{
MessageBoxYesNo( "Leave Game", "Exit from this game?", "xdisconnect();", "");
}

//Own disconnect function > needed for leave game message
function xdisconnect()
{
xupdateprefs();
commandtoserver('messagesent',$Preff::x::XLeaveGameMsg);
schedule(100, 0, disconnect);
}