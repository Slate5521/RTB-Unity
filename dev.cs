function devExec() { 
	exec("dev.cs");
}

function dev_checkUnusedScripts(%path, %extension) {
	%pattern = %path @ "/*." @ %extension;
	
	%unusedScripts = "";
	for(%file = findFirstFile(%pattern); 
			isFile(%file); 
			%file = findNextFile(%pattern)) {
			
		// file path + name without extension
		%baseFilePath = filePath(%file) @ "/" @ fileBase(%file);
		
		if(!isFile(%baseFilePath @ ".dso")) {
			%unusedScripts = %unusedScripts @ "\n" @ %file;
		}
	}
	
	if(%unusedScripts $= "") {
		echo("No unused (" @ %extension @ ") files found in" SPC %pat ;)
	} else {
		echo("Unused scripts found:" %unusedScripts);
	}
}