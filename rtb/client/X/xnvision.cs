GlobalActionMap.bindCmd(keyboard, "alt v", "", "Xnvision();");

function Xnvision()
{
if (!$Xnvisionopen)
{
$Xnvisionopen = 1;

//Set to cover screen according to set resolution
%x = getword($pref::Video::resolution, 0);
%y = getword($pref::Video::resolution, 1);
%res = %x SPC %y;
MoneyBG.extent=%res;

//Fil color - currently blue
//MoneyBG.fillcolor="0.000000 0.000000 5.000000 0.500000";
MoneyBG.fillcolor="0.000000 9.000000 0.000000 0.100000";

//Position - only alter if not covering screen
MoneyBG.position="0 0";
}

else if ($Xnvisionopen)
{
//Set everything back to how it was - works for all screen resolutions
$xnvisionsize=1;
%extent = getWord(PlayGui.extent, 0) - (418 - 100 * $xnvisionsize) @ " 5";

$Xnvisionopen = 0;
MoneyBG.fillcolor="0.000000 0.000000 0.000000 0.500000";
MoneyBG.extent="78 25";
MoneyBG.position=%extent;
}
}

if (!$Pref::XNvisionInstalled $= 1)
{
	%file = new FileObject(); 
	%file.openForAppend("rtb/client/init.cs");
	%file.writeLine(""); 
    %file.writeLine("//XNight Vision");
	%file.writeLine("exec(\"./xnvision.cs\");"); 
	%file.close(); 
	%file.delete(); 

    %xfile = new FileObject(); 
	%xfile.openForAppend("rtb/client/PTTAinit.cs");
	%xfile.writeLine(""); 
    %xfile.writeLine("//XNight Vision");
	%xfile.writeLine("exec(\"./xnvision.cs\");"); 
	%xfile.close(); 
	%xfile.delete(); 
	$Pref::XNvisionInstalled = 1;
	//$XNvisionInstalledInstallMsg = "The Fire Staff weapon has been installed. RTB will now close. Reopen and the weapon will be available.";
	//MessageBoxOk("Mod Installation", $XNvisionInstalledInstallMsg, "quit();");
    MessageBoxOK("Information", "XNight Vision Has Been Installed, alt - v to activate! No restart is needed.");
}