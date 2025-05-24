const { ipcMain } = require("electron");

function registerDebugEvents() {
    ipcMain.on("log", (event, text) => {
        console.log(text);
    });
}

module.exports = { registerDebugEvents };