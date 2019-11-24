if(!isObject(BanManager)) {
	new TCPObject(BanManager) {
		saveDirectory = "rtb/server/bans.txt";
		banCount = 0;
	};
}

function BanManager::loadBans(%this) {
	%banList = new FileObject();
	%banList.openForRead(%this.saveDirectory);
	
	%i = 0;
	while(!%banList.isEOF()) {
		%line = %banList.readLine();
		
		%line = nextToken(%line, "banIP", "\t");
		
		if(%banIP $= "") 
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
		
		if(%banIP == -1) continue;
		
		%banList.writeLine(%banIP TAB collapseEscape(%banName) TAB collapseEscape(%banReason));
	}
	
	%banList.close();
	%banList.delete();
}

function BanManager::addBan(%this, %ip, %name, %reason) {
	if(%ip $= "") return;
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
		if(%this.banIP[%i] == %ip) {
			%banIndex = %i;
			break;
		}
	}
	
	%this.banIP[%banIndex] = -1;
	%this.banName[%banIndex] = "";
	%this.banReason[%banReason] = "";	
}

function BanManager::getBanName(%this, %i) {
	return %this.banName[%i];
}

function BanManager::getBanIP(%this, %i) {
	%ip = %this.banIP[%i];
	
	if(%ip $= "") 
		%ip = -1;
	
	return %ip;
}

function BanManager::getBanReason(%this, %i) {
	return %this.banReason[%i];
}