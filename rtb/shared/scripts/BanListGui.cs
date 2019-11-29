// CLIENTSIDE

function banListGui::onWake(%this) {
	// Clear and receive ban list
	
	%this.clearBanList();
	commandtoserver('getBanList');
}

function banListGui::clearBanList(%this) {
	nameToID(sclColBanName).clear();
	nameToID(sclColBanIP).clear();
	nameToID(sclColBanReason).clear();
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

function banListGui::removeBan(%this, %banID) {
	nameToID(sclColBanName).removeRow(%banID);
	nameToID(sclColBanIP).removeRow(%banID);
	nameToID(sclColBanReason).removeRow(%banID);
}

function BanListGui::unban() {
	%ip = nametoID(sclColBanIP).getRowText(nameToID(sclBanList).selectedID);
	
	if(!isValidIP(%ip))
	   return;
	
	commandtoserver('RemoveBan', %ip);
}

function BanListGui::newBan() {
	%banIP     = nameToID(txtBanIP).getValue();
	if(!isValidIP(%banIP)) return;
	%banName   = nameToID(txtBanName).getValue();
	%banReason = nameToID(txtBanReason).getValue();
	
	commandToServer('banIp', %banIP, %banName, %banReason);
}

function BanListGui::onIndexChanged(%this, %caller) {
	if(!isObject(nameToID(%caller))) 
		return;
	
	%id = nameToID(%caller).getSelectedID();
	
	nameToID(sclBanList).selectedId = %id;
	
	if(nameToID(%caller) != nameToID(sclColBanName))
		nameToID(sclColBanName).setSelectedById(%id);
	
	nameToID(sclColBanIP).clearSelection();
	nameToID(sclColBanReason).clearSelection();
}

// SERVERSIDE