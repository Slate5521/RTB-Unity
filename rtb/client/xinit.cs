//Function to open gui on xgui();
function xgui()
{
	if (!$xguiOpen)
	{
	canvas.pushDialog(xgui);
	$xguiOpen = 1;
	}
	else if ($xguiOpen)
	{
	canvas.popDialog(xgui);
	$xguiOpen = 0;
	}
}

function xgui::onSleep(%this)
{
xupdateprefs();
}

function xpersonalgui::onSleep(%this)
{
xupdateprefs();
}

function xservergui::onSleep(%this)
{
xupdateprefs();
}

function xchatgui::onSleep(%this)
{
xupdateprefs();
}

//Cursor stuff
 //moveMap.bindcmd(keyboard, "alt m", "", "turncursoron();");
moveMap.bind(keyboard, "alt m", turncursoron);

function turncursoron(%val)
{
	if(%val)
	{	
   cursoron();
   //moveMap.bindcmd(keyboard, "alt m", "", "turncursoroff();");
moveMap.bind(keyboard, "alt m", turncursoroff);
    }
}

function turncursoroff(%val)
{
	if(%val)
	{	
   cursoroff();
   //moveMap.bindcmd(keyboard, "alt m", "", "turncursoron();");
    moveMap.bind(keyboard, "alt m", turncursoron);
    }
}

//Set status to that in preference
%status = $Pref::player::Status;
commandtoserver('setstatus',%status);

//Assign keyboard
moveMap.bindCmd(keyboard, "ctrl z", "", "OpenClose(xgui);");

//Load the XFiles
//Version & Update stuff
exec("./x/xversion.cs");

//Initate all scrips & Gui's
//Load Mrx's scripts
exec("./x/x.cs");
exec("./x/xhacks.cs");

//Load up the default prefs
exec("./x/xdefaultprefs.cs");

//Load updated prefs > will overwrite defaults
exec("./x/xprefs.cs");

//Music player
exec("./x/XmusicGUI.gui");
exec("./x/Xmusic.cs");

//Chat Stuff
exec("./x/XChat.cs");
exec("./x/XChatGUI.gui");

//Main Gui functions
exec("./x/xgui.cs");
exec("./x/xpersonalgui.cs");
exec("./x/xservergui.cs");

//Main Gui Files
exec("./x/xgui.gui");
exec("./x/xpersonalgui.gui");
exec("./x/xservergui.gui");
exec("./x/xadmingui.gui");

//XNVision
exec("./x/xnvision.cs");

//Check for updates
xupdatecheck();

function xupdateprefs()
{
export( "$Preff::x::*", "rtb/client/x/xprefs.cs", false );
error("XMenu Preferences Updated");
}

//Preference update
xupdateprefs();



