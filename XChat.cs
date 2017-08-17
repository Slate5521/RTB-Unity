//Xchat.cs > Copyright 2008 > MrX > http://www.mrx-rtb.co.nr/
//Chat GUI Functions

//Assign alt z to open the player
moveMap.bind(keyboard, "alt z", toggleXChatGui);

//Function to toggle the gui
//function toggleXChatGUI()
//{
//    checkXChatGuiOpen();
//    if (!$XChatguiOpen)
//    {
//    canvas.pushDialog(XChatGui);
//    $XChatguiOpen = 1;
//    return;
//    }
//    else if ($XChatguiOpen)
//    {
//    canvas.popDialog(XChatGui);
//    $XChatguiOpen = 0;
//    return;
//    }
//}

//For opening...
function toggleXChatGUI (%val)
{
	if(%val)
	{	
		canvas.pushDialog(XChatGui);
    }
}

//For saving...
function xsavechat()
{
//Record Chat
$preff::x::recordchat = RecordChat.getValue();

//Auto Response
$Preff::x::RESP = Auto_Response.getValue();

//Chat Tags
$Preff::x::tags = Chat_Tags.getValue();

//Slash commands
$Preff::x::commands = slash_commands.getValue();

//Reversed text
$Preff::x::XChatReversed = reversed_text.getValue();

//Auto response message
$Preff::x::respmsg = Auto_Response_Message.getValue();

//Message for auto response
$Preff::x::respmsg1 = xafkmsg.getValue();

//Tag Value 1
$Preff::x::tagval1 = xtagval1.getValue();

//Tag Value 2
$Preff::x::tagval2 = xtagval2.getValue();

//Colour options
$Preff::x::XChatRed = XChatRed.getValue();
$Preff::x::XChatGreen = XChatGreen.getValue();
$Preff::x::XChatWhite = XChatWhite.getValue();
$Preff::x::XChatGrey = XChatGrey.getValue();
$Preff::x::XChatBlue = XChatBlue.getValue();
$Preff::x::XChatYellow = XChatYellow.getValue();
$Preff::x::XChatRandom = XChatRandom.getValue();

export( "$Preff::x::*", "rtb/client/x/xprefs.cs", false );

//Save Chat
MessageBoxOK("XChat", "XChat Settings Updated!!");
}

//For slash commands...
function xping()
{
%xping=serverconnection.getping();
chathud.addline("Server Ping: " @ %xping);
}

//For slash commands...
function xport()
{
%xip=serverconnection.getaddress();
chathud.addline("Server " @ %xip);
}

//For slash commands...
function serverlist()
{
openclose("joinservergui");
commandtoserver('setstatus',"Looking At Servers...");
}

//For console... get back using play(); after viewng servers
function play()
{
openclose("playgui","joinservergui");
commandtoserver('setstatus',$Pref::player::Status);
}

//Slash Command Stuff
function  slashcommandcheck(%text)
{
$xtext=%text;
if(getSubStr(%text, 0, 1) !$= "/") 
{
commandToServer('messageSent',$Pref::player::Chatcolor @ %text);
}
else
{
//Away from keyboard
if (getSubStr(%text, 0, 4) $= "/afk")
{ 
%afkaction = getWord(%text, 1);
%afkaction2 = getSubStr(%text, 4, strlen(%text)-4);
$Preff::x::AFK=1;       
xafk(300000);
commandtoserver('setstatus',"Away doing something...");
//commandToServer('messageSent',"\c0«=WAR=» \c1: " @ $Pref::player::Chatcolor @ "Away From Keyboard...");
commandToServer('messageSent',"Away From Keyboard... - " @ %afkaction2);
}

//Be right back
else if (getSubStr(%text, 0, 5) $= "/brb")
{ 
$Preff::x::AFK=1;          
commandtoserver('setstatus',"Be Right Back");
//commandToServer('messageSent',"\c0«=WAR=» \c1: " @ $Pref::player::Chatcolor @ "Be Right Back.");
commandToServer('messageSent',"Be Right Back.");
}

//Back
else if (getSubStr(%text, 0, 5) $= "/back")
{  
$Preff::x::AFK=0;         
commandtoserver('setstatus',$Pref::player::Status);
//commandToServer('messageSent',"\c0«=WAR=» \c1: " @ $Pref::player::Chatcolor @ "Back.");
commandToServer('messageSent',"Back.");
}

//View server list
else if (getSubStr(%text, 0, 7) $= "/server")
{        
serverlist();
}

//Get server ping
else if (getSubStr(%text, 0, 5) $= "/ping")
{        
xping();
}

//Get server IP / port
else if (getSubStr(%text, 0, 5) $= "/port")
{        
xport();
}

//Turn auto response off
else if (getSubStr(%text, 0, 8) $= "/respoff")
{        
$Preff::x::RESP=0;  
chathud.addline("Auto Response Off");
}

//Turn auto response on
else if (getSubStr(%text, 0, 7) $= "/respon")
{        
$Preff::x::RESP=1; 
chathud.addline("Auto Response On"); 
}

//Turn chat tags on
else if (getSubStr(%text, 0, 7) $= "/tagson")
{ 
$Preff::x::tags = 1;       
chathud.addline("Tags On");
MessageHud.close();
return;
}

//Turn chat tags off
else if (getSubStr(%text, 0, 8) $= "/tagsoff")
{ 
$Preff::x::tags = 0;       
chathud.addline("Tags Off");
}

else if (getSubStr(%text, 0, 5) $= "/exit")
{ 
xleavegame();
}

else
{
//If not / command is found just send a normal message
%text=getSubStr(%text, 1, strlen(%text)-1);
commandToServer('messageSent', %text);
}
}
}

//Afk stuff
function xafk(%xd)
{
if($Preff::x::AFK && $Preff::x::respmsg)
{
commandtoserver('messagesent',$Preff::x::respmsg1);
schedule(%xd*1000,0,xafk,%xd);
}
}

//Reversed text - found on BLC
function xreversed(%text)
{
%text2="";
for(%i=0;%i<strlen(%text);%i++)
{
%text2= getsubstr(%text,%i,1) @ %text2;
}
echo(%text2);
$xreversed = %text2;
}

//Random chat color function > Based on the one by solar
function xrandomchatcolor()
{
%xrnd=getrandom(0,5);
if(%xrnd==0)$Pref::player::Chatcolor="\c0";
if(%xrnd==1)$Pref::player::Chatcolor="\c1";
if(%xrnd==2)$Pref::player::Chatcolor="\c2";
if(%xrnd==3)$Pref::player::Chatcolor="\c3";
if(%xrnd==4)$Pref::player::Chatcolor="\c4";
if(%xrnd==5)$Pref::player::Chatcolor="\c5";
return;
}

//Set color to that chosen
function xchatcolor()
{
//Red
if($Preff::x::XChatRed)
{
$Pref::player::Chatcolor="\c3";
}
if($Preff::x::XChatGreen)
{
$Pref::player::Chatcolor="\c2";
}
if($Preff::x::XChatWhite)
{
$Pref::player::Chatcolor="\c0";
}
if($Preff::x::XChatGrey)
{
$Pref::player::Chatcolor="\c4";
}
if($Preff::x::XChatBlue)
{
$Pref::player::Chatcolor="\c5";
}
if($Preff::x::XChatYellow)
{
$Pref::player::Chatcolor="\c1";
}
return;
}

//Clear $msg and $name when called < for auto response
function clearspam()
{
$msg = "";
$name = "";
}