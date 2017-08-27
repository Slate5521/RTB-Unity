function devExec() { 
	exec("dev.cs");
}

function dev_checkUnusedScripts(%path, %extension) {
	%pattern = %path @ "/*." @ %extension;
	echo(%pattern);
	%unusedScripts = "";
	for(%file = findFirstFile(%pattern); 
			isFile(%file); 
			%file = findNextFile(%pattern)) {
			
		if(!isFile(%file @ ".dso")) {
			%unusedScripts = %unusedScripts @ "\n" @ %file;
		}
	}
	
	if(%unusedScripts $= "") {
		echo("No unused (" @ %extension @ ") files found in" SPC %path);
	} else {
		echo("Unused scripts found:" SPC %unusedScripts);
	}
}