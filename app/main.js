const { app, BrowserWindow } = require("electron");
const path = require("path");

const { registerWindowEvents } = require("./preload/events/window.js");
const { registerSystemEvents } = require("./preload/events/system.js");
const { registerDebugEvents } = require("./preload/events/debug.js");

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
            preload: path.join(__dirname, "./preload/preload.js")
        }
    });

    window.loadFile("./renderer/index.html");

    registerWindowEvents(window);
    registerSystemEvents();
    registerDebugEvents();
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