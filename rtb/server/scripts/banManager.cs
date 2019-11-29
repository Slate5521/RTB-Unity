function BanManagerInitialize() {
	if(!isObject(BanManager)) {
		new TCPObject(BanManager) {
			saveDirectory = "rtb/server/bans.txt";
			banCount = 0;
		};
	}
	
}
function BanManager::loadBans(%this) {
	%banList = new FileObject();
	%banList.openForRead(%this.saveDirectory);
	
	%i = 0;
	while(!%banList.isEOF()) {
		%line = %banList.readLine();
		
		%line = nextToken(%line, "banIP", "\t");
		
		if(!isValidIP(%banIP)) 
			continue;
		
		
		%line = nextToken(%line, "banName", "\t");
		%line = nextToken(%line, "banReason", "\t");
		
		if(%banName $= "") %banName = "No Name";
		if(%banReason $= "") %banReason = "N/A";
		
		%this.addBan(%banIP, %banName, %banReason);
	}
	
	%banList.close();
	%banList.delete();
}

function BanManager::saveBans(%this) {
	%banList = new FileObject();
	%banList.openForWrite(%this.saveDirectory);
	
	for(%i = 0; %i < %this.banCount; %i++) {
		%banIP = %this.getBanIP(%i);
		%banName = %this.getBanName(%i);
		%banReason = %this.getBanReason(%i);
		
		if(!isValidIP(%banIP)) continue;
		
		%banList.writeLine(%banIP TAB collapseEscape(%banName) TAB collapseEscape(%banReason));
	}
	
	%banList.close();
	%banList.delete();
}

function BanManager::addBan(%this, %ip, %name, %reason) {
	if(!isValidIP(%ip)) return;
	if(%this.hasBan(%ip) != -1) return;
	echo("DEBUG");
	
	if(%name $= "") %name = "NO NAME";
	if(%reason $= "") %reason = "N/A";
	
	
	
	%this.banIP[%this.banCount] = %ip;
	%this.banName[%this.banCount] = %name;
	%this.banReason[%this.banCount] = %reason;
	
	%this.banCount++;
}

function BanManager::removeBan(%this, %ip) {
	%banIndex = -1;
	
	for(%i = 0; %i < %this.banCount; %i++) {
		if(%this.banIP[%i] $= %ip) {
			%banIndex = %i;
			break;
		}
	}
	
	// Ban not found.
	if(%banIndex == -1) return;
		
	for(%i = %banIndex; %i < %this.banCount; %i++) {
		%this.banIP[%i] = %this.banIP[%i + 1];
		%this.banName[%i] = %this.banName[%i + 1];
		%this.banReason[%i] = %this.banReason[%i + 1];
	}
	
	// Remove ban at end of list
	
	%this.banIP[%this.banCount] = "";
	%this.banName[%this.banCount] = "";
	%this.banReason[%this.banCount] = "";
	
	%this.banCount--;
}

function BanManager::getBanName(%this, %i) {
	return %this.banName[%i];
}

function BanManager::getBanIP(%this, %i) {
	%ip = %this.banIP[%i];
	
	if(!isValidIP(%ip)) 
		%ip = -1;
	
	return %ip;
}

function BanManager::getBanReason(%this, %i) {
	return %this.banReason[%i];
}

function BanManager::hasBan(%this, %ip) {
	for(%i = 0; %i < %this.banCount; %i++)
		if(%this.banIP[%i] $= %ip)
			return %i;
		
	return -1;
}