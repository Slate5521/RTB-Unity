$Preff::x::CurrentVersion = "1.0";
$Preff::x::Version = "Version: " @ $Preff::x::CurrentVersion;

function xupdatecheck()
{
%t=new HTTPObject(UpdateChecker);
%t.get("mrx.rtb.googlepages.com:80","/xmenuversion.txt");
NewsList.entryCount = 0;
}

function UpdateChecker::onLine(%this,%line)
{
	if(%line > $Preff::x::CurrentVersion)
	{
		%newversion = getword(%line,1);
		Error("XMenu Update needed!!");
        MessageBoxOK("XMenu", "A New Version Of Xmenu Is Now Available, Get It At: www.mrx-rtb.co.nr");
	}
//Schedule(1,0,"xupdatecheck");
}

