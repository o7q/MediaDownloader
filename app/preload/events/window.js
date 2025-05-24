const { ipcMain } = require("electron");

function registerWindowEvents(window) {
    ipcMain.on("minimize-window", () => {
        window.minimize();
    });

    ipcMain.on("close-window", () => {
        window.close();
    });
}

module.exports = { registerWindowEvents };