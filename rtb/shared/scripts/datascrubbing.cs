function scrubDataTrueFalse(%var) {
	if(%var == 0 || %var == 1)
		return %var;
}

	
function isValidIP(%ip) {	
	if(%ip == -1) return false;
	if(strLen(%ip) < 7) return false;
	if(strPos(%ip, ".") == -1) return false;
	
	for(%i = 0; %i < 4; %i++) {
		%ip = nextToken(%ip, "curStanza", ".");
		
		if(!isNumber(%curStanza) || %curStanza < 0 || %curstanza > 255) 
			return false;
	}
	
	return true;
}

function isNumber(%var) {
	return strLen(stripChars(%var, "0123456789")) == 0;
}