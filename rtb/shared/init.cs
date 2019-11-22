function initShared() {
	echo("\n--------- Initializing FPS: Shared ---------");
	
	exec("./scripts/datascrubbing.cs");
	exec("./scripts/adminGui.cs");
	exec("./scripts/BanListGui.cs");
}
