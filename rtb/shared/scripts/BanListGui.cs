// CLIENTSIDE

function banListGui::onWake(%this) {
	// Clear and receive ban list
	nameToID(sclColBanName).clear();
	nameToID(sclColBanIP).clear();
	nameToID(sclColBanReason).clear();
	
	commandtoserver('getBanList');
}

function banListGui::addBan(%this, %BanID, %BanName, %BanIP, %BanReason) {
	if(%BanID == -1) {
		nameToID(sclColBanName).addRow(0, "You do not have the permissions to view the ban list. <Required: Super Admin>");
		return;
	}
	
	nameToID(sclColBanName).addRow(%BanID, %BanName);
	nameToID(sclColBanIP).addRow(%BanID, %BanIP);
	nameToID(sclColBanReason).addRow(%BanID, %BanReason);
}


// SERVERSIDE