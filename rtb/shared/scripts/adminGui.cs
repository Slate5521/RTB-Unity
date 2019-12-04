// CLIENTSIDE

function clientCmdPlayerInfoRequestResponse(%updateString) {
	nameToID(lstPlayerInfo).clear();
	
	%updateStringTokens = %updateString;
	%i = 0;
	
	while(%updateStringTokens !$= "") {
		%updateStringTokens = nextToken(%updateStringTokens, "curToken", "\n");
		
		nameToID(lstPlayerInfo).addRow('', %curtoken, %i++);
	}
}
function clientCmdRequestAdminPrefsResponse(%updateString) {
	// When this is sent, a deliminated string will be sent back with information from the server.
	
	%updateStringTokens = %updateString;
	
	while(%updateStringTokens !$= "") {
		%updateStringTokens = nextToken(%updateStringTokens, "curToken", "\n");
		
		%variable = firstWord(%curToken);
		%value = getWords(%curToken, 1, getWordCount(%curToken));
		
		%valueTF = scrubDataTrueFalse(%value);
		
		switch$(%variable) {
			case "AdminForce": nameToID(btnToggleForceAdmin).setValue(%valueTF);
			case "XAdminForce": nameToID(btnToggleForceXAdmin).setValue(%valueTF);
			case "Suicide": nameToID(btnToggleSuicide).setValue(%valueTF);
			case "SitFreeze": nameToID(btnToggleSitFreeze).setValue(%valueTF);
			case "SlashCommand": nameToID(btnToggleSlashCommand).setValue(%valueTF);
			case "PM": nameToID(btntogglepm).setValue(%valueTF);
			case "Chat": nameToID(btnToggleChat).setValue(%valueTF);
			case "ImposterMonitor": nameToID(btnToggleImposterMonitor).setValue(%valueTF);
			case "NameMonitor": nameToID(btnToggleNameMonitor).setValue(%valueTF);
			case "FallDamage": nameToID(btnToggleFallDamage).setValue(%valueTF);
			case "Inventory": nameToID(btnToggleInventory).setValue(%valueTF);
			case "JetLag": nameToID(txtJetlag).setValue(%valueTF);
			case "SpawnEW": // Not implemented.
			case "PlayerTP": // Not implemented.
			case "AutoFriend": // Not implemented.
			case "Observer": // Not implemented.
		}
	}
}

function admingui::changePref(%this, %pref) {
	switch$(%pref) {
		case "AdminForce": commandToServer('UpdateServerPref', "AdminForce", nameToID(btnToggleForceAdmin).getValue());
		case "XAdminForce": commandToServer('UpdateServerPref', "XAdminForce", nameToID(btnToggleForceXAdmin).getValue());
		case "Suicide": commandToServer('UpdateServerPref', "Suicide", nameToID(btnToggleSuicide).getValue());
		case "SitFreeze": commandToServer('UpdateServerPref', "SitFreeze", nameToID(btnToggleSitFreeze).getValue());
		case "SlashCommand": commandToServer('UpdateServerPref', "SlashCommand", nameToID(btnToggleSlashCommand).getValue());
		case "PM": commandToServer('UpdateServerPref', "PM", nameToID(btntogglepm).getValue());
		case "Chat": commandToServer('UpdateServerPref', "Chat", nameToID(btnToggleChat).getValue());
		case "ImposterMonitor": commandToServer('UpdateServerPref', "ImposterMonitor", nameToID(btnToggleImposterMonitor).getValue());
		case "NameMonitor": commandToServer('UpdateServerPref', "NameMonitor", nameToID(btnToggleNameMonitor).getValue());
		case "FallDamage": commandToServer('UpdateServerPref', "FallDamage", nameToID(btnToggleFallDamage).getValue());
		case "Inventory": commandToServer('UpdateServerPref', "Inventory", nameToID(btnToggleInventory).getValue());
		// case "SpawnEW": commandToServer('UpdateServerPref', "SpawnEW", nameToID().getValue());
		// case "PlayerTP": commandToServer('UpdateServerPref', "PlayerTP", nameToID().getValue());
		// case "AutoFriend": commandToServer('UpdateServerPref', "AutoFriend", nameToID().getValue());
		// case "Observer": commandToServer('UpdateServerPref', "Observer", nameToID().getValue());
	}
}

function clientCmdPlayerRightsRequestResponse(%response) {
	%responseTokens = %response;
	
	while(%responseTokens !$= "") {
		%responseTokens = nextToken(%responseTokens, "curToken", "\n");
		
		%variable = firstWord(%curToken);
		%value = getWords(%curToken, 1, getWordCount(%curToken));
		
		%valueTF = scrubDataTrueFalse(%value);
		
		switch$(%variable) {
			case "PrivLevel": 
				%radio = -1;
				
				     if(%value == $Priv::Normal)     %radio = nametoID(radioPrivNormal);
				else if(%value == $Priv::TempAdmin)  %radio = nametoID(radioPrivTempAdmin);
				else if(%value == $Priv::SuperAdmin) %radio = nametoID(radioPrivSuperAdmin);
				else if(%value == $Priv::XAdmin)     %radio = nametoID(radioPrivXAdmin);
				else if(%value == $Priv::Host)       %radio = nametoID(radioPrivXAdmin);
				
				// Invalid value or radio control doesn't exist.
				if(%radio == -1) continue;
				
				%radio.setValue(true);
				
			case "EW": nameToID(btnRightsEditorWand).setValue(%valueTF);
			case "BuildRights": nameToID(btnRightsBuilding).setValue(%valueTF);
			case "Inventory": nameToID(btnRightsInventory).setValue(%valueTF);
			case "God": nameToID(btnRightsGod).setValue(%valueTF);
		}
	}
}

// SERVERSIDE

package sharedServerside {
	function serverCmdUpdateServerPref(%client, %pref, %val) {
		%valTF = scrubDataTrueFalse(%val);
		%success = false;
		%privRequired = "";
		%broadcastTerm = "";
		
		switch$(%pref) {
			case "AdminForce":		
				if(%client.isXAdmin()) {
					$pref::server::adminforce = %valTF;
					%success = true;
					%broadcastTerm = "Admin by Force has";
				} else %privRequired = "XAdmin";
			case "XAdminForce":		
				if(%client.isHost()) { 
					$pref::server::xadminforce = %valTF;
					%success = true;
					%broadcastTerm = "XAdmin by Force has";
				} else %privRequired = "Host";
			case "Suicide":			
				if(%client.isSuperAdmin()) { 
					$Pref::Server::suicide = %valTF;
					%success = true;
					%broadcastTerm = "Suicide has";
				} else %privRequired = "Super Admin";
			case "SitFreeze":		
				if(%client.isSuperAdmin()) {
					$Pref::Server::EnabledFreeze = %valTF;
					%success = true;
					%broadcastTerm = "Sitting and Freezing have";
				} else %privRequired = "Super Admin";
			case "SlashCommand":
				if(%client.isSuperAdmin()) {
					$Pref::Server::SCommands = %valTF;
					%success = true;
					%broadcastTerm = "Slash Commands have";
				} else %privRequired = "Super Admin";
			case "PM":				
				if(%client.isXAdmin()) { 
					$Pref::Server::PMSys = %valTF;
					%success = true;
					%broadcastTerm = "PMing has";
				} else %privRequired = "XAdmin";
			case "Chat":			
				if(%client.isSuperAdmin()) {
					$Pref::Server::Moderated = %valTF;
					%success = true;
					%broadcastTerm = "Chatting has";
				} else %privRequired = "Super Admin";
			case "ImposterMonitor":	
				if(%client.isXAdmin()) {
					$Pref::Server::ImposterWarning = %valTF;
					%success = true;
					%broadcastTerm = "Imposter Monitor has";
				} else %privRequired = "XAdmin";
			case "NameMonitor":		
				if(%client.isXAdmin()) {
					$Pref::Server::NameChangeWarning = %valTF;
					%success = true;
					%broadcastTerm = "Name Monitor has";
				} else %privRequired = "XAdmin";
			case "FallDamage":		
				if(%client.isSuperAdmin()) {
					$Pref::Server::FallDamage = %valTF;
					%success = true;
					%broadcastTerm = "Fall Damage has";
				} else %privRequired = "Super Admin";
			case "Inventory":		
				if(%client.isSuperAdmin()) {
					$Pref::Server::UseInventory = %valTF;
					%success = true;
					%broadcastTerm = "Inventory has";
				} else %privRequired = "Super Admin";
			case "SpawnEW":			
				if(%client.isSuperAdmin()) {
					$Pref::Server::SpawnEW = %valTF;
					%success = true;
					%broadcastTerm = "Spawning with Editor Wand has";
				} else %privRequired = "Super Admin";
			case "PlayerTP":		
				if(%client.isSuperAdmin()) {
					$Pref::Server::PlayerTP = %valTF;
					%success = true;
					%broadcastTerm = "Player Teleporting has";
				} else %privRequired = "Super Admin";
			case "AutoFriend":		
				if(%client.isSuperAdmin()) {
					$Pref::Server::AutoFriend = %valTF;
					%success = true;
					%broadcastTerm = "Auto Friend has";
				} else %privRequired = "Super Admin";
			case "Observer":		
				if(%client.isSuperAdmin()) {
					$Pref::Server::Observer = %valTF;
					%success = true;
					%broadcastTerm = "Player Drop Camera has";
				} else %privRequired = "Super Admin";
		}
		
		if(%success == false) {
			messageClient(%client, '', '\c3You do not have the permissions to do this. \c0<Required: %1>', %privRequired);
			serverCmdRequestAdminPrefs(%client);
		} else {
			messageAll('', '%1 been %2%3 \c0by %4.', %broadcastTerm, %valTF ? "\c2" : "\c3", %valTF ? "ENABLED" :"DISABLED", %client.name);
		}
	}

	function serverCmdRequestAdminPrefs(%client) {
		if(%client.isSuperAdmin()) {
			commandToClient(%client, 'RequestAdminPrefsResponse',
					"AdminForce" SPC $pref::server::adminforce NL
					"XAdminForce" SPC $pref::server::xadminforce NL
					"Suicide" SPC $Pref::Server::suicide NL
					"SitFreeze" SPC $Pref::Server::EnabledFreeze NL
					"SlashCommand" SPC $Pref::Server::SCommands NL
					"PM" SPC $Pref::Server::PMSys NL
					"Chat" SPC $Pref::Server::Moderated NL
					"ImposterMonitor" SPC $Pref::Server::ImposterWarning NL
					"NameMonitor" SPC $Pref::Server::NameChangeWarning NL
					"FallDamage" SPC $Pref::Server::FallDamage NL
					"Inventory" SPC $Pref::Server::UseInventory NL
					"SpawnEW" SPC $Pref::Server::SpawnEW NL
					"PlayerTP" SPC $Pref::Server::PlayerTP NL
					"AutoFriend" SPC $Pref::Server::AutoFriend NL
					"Observer" SPC $Pref::Server::Observer NL
					"JetLag" SPC $pref::server::jetlag);
		}
	}
	
	function serverCmdRequestPlayerInfo(%client, %client2) {		
		%infobase = "";
		
		switch(%client2.privLevel) {
			case $Priv::Normal: %infoBase = "Normal User";
			case $Priv::TempAdmin: %infoBase = "Temp Admin";
			case $Priv::SuperAdmin: %infoBase = "Super Admin";
			case $Priv::XAdmin: %infoBase = "XAdmin";
			case $Priv::Host: %infoBase = "Host";
		}
		
		if(%client.isSuperAdmin()) {
			%infobase = %infobase NL
						"IP:" SPC "NOT IMPLEMENTED";
		}
		
		%infobase = %infobase NL 
					"Blocks:" SPC "NOT IMPLEMENTED";
		
		if(%client.isTempAdmin()) {
			%infobase = %infobase NL 
						"Movers:" SPC "NOT IMPLEMENTED" NL
						"Elevators:" SPC "NOT IMPLEMENTED";
		}
		
		commandToClient(%client, 'PlayerInfoRequestResponse', %infobase);
	}
	
	function serverCmdRequestPlayerRights(%client, %client2) {
		%infobase = "PrivLevel" SPC %client2.privLevel;
		
		if(%client.isTempAdmin()) // Update this when I implement EW and whatnot.
			%infobase = %infobase NL
						"EW" SPC "0" NL
						"BuildRights" SPC "0" NL
						"Inventory" SPC "0" NL
						"God" SPC "0";
						
		commandToClient(%client, 'PlayerRightsRequestResponse', %infobase);
	}
	
	function serverCmdSetPlayerRights(%client, %client2, %rights) {
		if(!%client.isTempAdmin()) 
			return;
		
		%right = getFirstWord(%rights);
		%value = getWord(%rights, 1);
		%valueTF = scrubDataTrueFalse(%value);
		
		switch$(%right) {
			case "PrivLevel":
				// If client is trying to set a privlevel that is equivalent to his or her role or higher, stop. 
				if(%client.privLevel >= %value) 
					return;
				// If client is trying to set the privlevel of someone who is his or her role or higher, stop.
				if(%client.privLevel <= %client2.privLevel) 
					return;
				// If client is trying to set a privlevel that doesn't exist, stop.
				if(%value < $Priv::Normal || %value > $Priv::XAdmin)
					return;
				if(%client == %client2) 
					return;
				
				%client2.privLevel = %value;
				messageAll('', 'priv level');
			case "EW": // Not implemented.
			case "BuildRights": // Not implemented.
			case "Inventory": // Not implemented.
			case "God": // Not implemented.
		}
	}
};