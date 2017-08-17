//Some extra stuff with the XMenu > Gui not added for these functions, you will have to use console :P

//This one is by qwertyuiopas
function xrow(%l,%h)
{
if(%h>0)
{
for(%i=0;%i<%l;%i++)
{
$XRowl1 = schedule(%i*200,0,"commandtoserver",'plantbrick');
$XRowl2 = schedule(%i*200+100,0,"commandToServer",'shiftBrick', 1, 0, 0);
}
%h--;
$XRowh1 = schedule(%l*200+200,0,"commandToServer",'shiftBrick', -%l, 0, 3);
$XRowh2 =schedule(%l*200+300,0,"xrow",%l,%h);
}
}

//cancel($XAutoSave);

//With large numbers some get left out > Careful not to build to fast...
function xstairsup(%total)
{
if(%total>0)
    {
	for(%i = 0; %i < %total; %i++)
	{
		$XStairsup1 = schedule(%i*200,0,"commandtoserver",'plantbrick');
        $XStairsup2 = schedule(%i*200+100,0,"commandToServer",'shiftBrick', 1, 0, 3);
	}
    }
}

//Face backwards to the direction you want the stairs to go down
function xstairsdown(%total)
{
if(%total>0)
    {
	for(%i = 0; %i < %total; %i++)
	{
		$XStairsdown1 = schedule(%i*200,0,"commandtoserver",'plantbrick');
        $XStairsdown2 = schedule(%i*200+100,0,"commandToServer",'shiftBrick', -1, 0, -3);
	}
    }
}

//Cloak
function xCloakMe()
{
commandtoserver('catme');
canvas.pushdialog(optionsDlg);
canvas.popDialog(optionsDlg);
}