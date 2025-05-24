const { app, BrowserWindow } = require("electron");
const path = require("path");
const { registerIpcEvents } = require("./scripts/events.js");

const createWindow = () => {
    const window = new BrowserWindow({
        width: 500,
        height: 250,
        minWidth: 400,
        minHeight: 200,
        frame: false,
        titleBarStyle: "hidden",
        icon: path.join(__dirname, "assets/icon.ico"),
        webPreferences: {
            preload: path.join(__dirname, "./scripts/preload.js")
        }
    });

    window.loadFile("./index.html");

    registerIpcEvents(window);
}

app.whenReady().then(() => {
    createWindow();
});

app.on("window-all-closed", () => {
    if (process.platform !== "darwin") {
        app.quit();
    }
});

app.on("activate", () => {
    if (BrowserWindow.getAllWindows().length === 0) {
        createWindow();
    }
});