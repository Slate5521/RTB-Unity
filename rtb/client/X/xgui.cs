//Xgui.cs > Copyright 2008 > MrX > http://www.mrx-rtb.co.nr/
//Player Gui functions

//Noob function
function noob()
{
%victimId = lstxmenuPlayerList.getSelectedId();
commandtoserver('noob',%victimId);
}

//Burn function
function burn()
{
%victimId = lstxmenuPlayerList.getSelectedId();
commandtoserver('burn',%victimId);
}

//Cop function
function xcop()
{
%victimId = lstxmenuPlayerList.getSelectedId();
commandtoserver('xcop',%victimId);
}

//Robber function
function xrob()
{
%victimId = lstxmenuPlayerList.getSelectedId();
commandtoserver('xrob',%victimId);
}

//Goto function
function xadmingoto()
{
%victimId = lstxmenuPlayerList.getSelectedId();
commandtoserver('xgoto',%victimId);
}

//Bring function
function xadminbring()
{
%victimId = lstxmenuPlayerList.getSelectedId();
commandtoserver('xbring',%victimId);
}

//Pay function
function xpay()
{
%victimId = lstxmenuPlayerList.getSelectedId();
%xamount = xamount.getValue();
commandtoserver('PlayerGiveMoney',%victimId,%xamount);
}

//Slap function
function slap()
{
%victimId = lstxmenuPlayerList.getSelectedId();
%dmg = slapdmg.getValue();
commandtoserver('slap',%victimId, %dmg);
}

//Change name
function xchgname()
{
%victimId = lstxmenuPlayerList.getSelectedId();
if(%victimId < 1)
{
MessageBoxOK("Error", "Please Select A Person First");
return;
}
%setname = xtxtsetname.getValue();
commandtoserver('xchgname',%victimId,%setname);
}

//XAdmin Rights
function xadminrightsopt()
{
%victimId = lstxmenuPlayerList.getSelectedId();
if(%victimId !$= -1)
{
commandtoserver('xadminopts',%victimId);
}
else
{
MessageBoxOK("XMenu", "Please Select A Person First");
}
}

function xadminrightsapply()
{
%XAdminNoob = $preff::x::noobafie;
%XAdminBurn = $Preff::x::burn;
%XAdminSlap = $Preff::x::slap;
%XAdminChgname = $Preff::x::chgname;
%XAdminRights = $Preff::x::xrights;
%XAdminSvrmsg = $Preff::x::svrmsg;
%XAdminAdmmsg = $Preff::x::admmsg;
%XAdminKickAll = $Preff::x::xkickall;
%XAdminMuteAll = $Preff::x::xmuteall;
%XAdminBanAll = $Preff::x::xbanall;
%XAdminCop = $Preff::x::xcop;
%XAdminRob = $Preff::x::xrobber;
%XAdminGoto = $Preff::x::xgoto;
%XAdminBring = $Preff::x::xbring;

%xvictimId = lstxmenuPlayerList.getSelectedId();
commandtoserver('Xadminrights',%xvictimId, %XAdminNoob, %XAdminBurn, %XAdminSlap, %XAdminChgname, %XAdminRights, %XAdminSvrmsg, %XAdminAdmmsg, %XAdminKickAll, %XAdminMuteAll, %XAdminBanAll, %XAdminCop, %XAdminRob, %XAdminGoto, %XAdminBring);
}

function xadminpass()
{
%XAdminPass = xadminpass.getValue();
commandtoserver('Xadminpass',%XAdminPass);
}

//PM stuff
function xsendpm()
{
%message= xtxtpm.getValue();
%victimId = lstxmenuPlayerList.getSelectedId();
if(%victimId !$= -1)
{
if(%message !$= "")
{
xtxtpm.setValue("");
commandtoServer('sendMessage',%victimId,%message);
commandToServer('stopTalking');
chathud.addline("Message Sent!");
}
else
{
chathud.addline("Please Enter A Message...");
}
}
else
{
chathud.addline("Please Select A Person First...");
}
}

//Player ID Function
function xgetid()
{
%victimId = lstxmenuPlayerList.getSelectedId();
if(%victimId !$= -1)
{
//echo("The Id for the selected client is: " @ %victimId);
chathud.addline("The Id for the selected client is: " @ %victimId);
}
else
{
chathud.addline("Please select a person first...");
}
}

//Player Location function
function xglobloc()
{
%victimId = lstxmenuPlayerList.getSelectedId();
commandtoserver('xglobloc',%victimId);
}