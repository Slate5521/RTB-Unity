//Sound profiles
new AudioDescription(XMusicDesc)
{
   volume   = 1.0;
   isLooping= false;
   is3D     = false;
   type     = $GuiAudioType;
};

new AudioProfile(XMusic)
{
   filename = "rtb/music/x.wav";
   description = "XMusicDesc";
   preload = true;
};
$xmusicguiOpen=0;
// GUI Functions

//Assign F6 to open the player
//GlobalActionMap.bindCmd(keyboard, "f6", "", "toggleXMusicGui();");
moveMap.bind(keyboard, "f6", toggleXMusicGui);

//Function to toggle the gui
//function toggleXMusicGUI()
//{
//    checkXMusicGuiOpen();
//    if (!$xmusicguiOpen)
//    {
//    canvas.pushDialog(XMusicGui);
//    $xmusicguiOpen = 1;
//    return;
//    }
//    else if ($xmusicguiOpen)
//    {
//    canvas.popDialog(XMusicGui);
//    $xmusicguiOpen = 0;
//    return;
//    }
//}

function toggleXMusicGUI (%val)
{
	if(%val)
	{	
		canvas.pushDialog(XMusicGui);
    }
}


//Do some stuff when the gui is opened
function XMusicGUI::onWake(%this)
{
   //Clear the list
   XMusicList.clear();
   //Search for available files and add them - sorted in the order they are added
   for(%file = findFirstFile("rtb/music/*.wav"); %file !$= ""; %file = findNextFile("rtb/music/*.wav"))
   {
      %numRow++;
      %fileName = strReplace(%file, "rtb/music/", "");
      %fileName = strReplace(%fileName, ".wav", "");
      XMusicList.addRow(%numRow, %fileName);
      XMusicList.sort($numRow, false);
      XMusicList.scrollVisible(1);
   }
    $XNumRow = %numRow;
//If the user is still playing music, select the current track
if(!$XMusic::Off)
{
XMusicList.setSelectedById($xmusicid);
}
    $XMusic::Off = 0;
}

function XNewMusic()
{
   //Get the id of the selected track
   %id = XMusicList.getSelectedID();
   //If id < 1 then no track is selected :: Inform the user of this
   if(%id < 1)
   {
      MessageBoxOK("Error", "Please Select A File To Play");
      return;
   }
   $xmusicID = %id;
   //Set the file name
   %fileName = XMusicList.getRowTextById(%id);
   //Stop $curXMusic
   alxStop($curXMusic);
   //Update the filename
   XMusic.fileName = "rtb/music/" @ %fileName @ ".wav";
   //Play new music
   $curXMusic = alxPlay(XMusic);
   //Call XNextMusic();
   XNextMusic(%id);
}

function XNextMusic(%id)
{
//If user has not stopped music
if(!$XMusic::Off)
{
//Get the current ID
%id = XMusicList.getSelectedID();
//If there is no music playing
if (!alxIsPlaying($curXMusic))
   {
//Add one to %id
%id++;

//If %id + 1 is > total songs listed then %id =1 (go back to the start)
if(%id > $XNumRow)
	{
		%id = 1;
	}
 $xmusicID = %id;
      //Get the file name
      %fileName = XMusicList.getRowTextById(%id);
      //Update the file name
      XMusic.fileName = "rtb/music/" @ %fileName @ ".wav";
      //Update $curXMusic
      $curXMusic = alxPlay(XMusic);
      //Play $curXMuisc
      alxPlay($curXMusic);
      //Add one to $xmusicID
     
      //Select track
      XMusicList.setSelectedById($xmusicid);
}
//If there is a song playing, run XNextMusic();
Schedule(1,0,"XNextMusic",%id);

}
}

function XNextTrack()
{
//Get current ID
%id = $xmusicID;

//If user has not played any music yet
if(%id < 1)
{
      MessageBoxOK("Error", "Please Play Some Music First");
      return;
}

//Stop $curXMusic
alxStop($curXMusic);

//Add one to the id
%id++;

//XMusicList.setSelectedRow(%id);
//$XmuiscID = $XmusicID+1;   echo($XmusicID); 

//Add one to $xmusicID
$xmusicID = $xmusicID+1;

//If %id + 1 is > total songs listed then %id =1 (go back to the start)
if(%id > $XNumRow)
	{
		%id = 1;
	}
      //Update selection
      XMusicList.setSelectedById(%id);
      //Update file name
      %fileName = XMusicList.getRowTextById(%id);
      XMusic.fileName = "rtb/music/" @ %fileName @ ".wav";
      //Update $curXMusic
      $curXMusic = alxPlay(XMusic);
      //Play $curXMusic
      alxPlay($curXMusic);
$xmusicID = %id;

//}
}

function XPrevTrack()
{
//Get current ID
%id = $xmusicID;

//If user has not played any music yet
if(%id < 1)
{
      MessageBoxOK("Error", "Please Play Some Music First");
      return;
}
//%id2 = XMusicList.getSelectedID();

//Stop $curXMusic
alxStop($curXMusic);

//Take one from the id
%id--;

//XMusicList.setSelectedRow(%id);
//$XmuiscID = $XmusicID+1;   echo($XmusicID); 

//Take one from $xmusicID
$xmusicID = $xmusicID-1;

//If %id + 1 is > total songs listed then %id =1 (go back to the start)
if(%id < 1)
	{
		%id = $XNumRow;
	}
      //Update selection
      XMusicList.setSelectedById(%id);
      //Update file name
      %fileName = XMusicList.getRowTextById(%id);
      XMusic.fileName = "rtb/music/" @ %fileName @ ".wav";
      //Update $curXMusic
      $curXMusic = alxPlay(XMusic);
      //Play $curXMusic
      alxPlay($curXMusic);
$xmusicID = %id;

//}
}

function stopXMusic()
{
$XMusic::Off=1; 
$xmusicID= -1;
//Stop $curXMusic
alxStop($curXMusic);
}
