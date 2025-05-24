const { ipcMain } = require("electron");
const { execFile } = require("child_process");
const fs = require("fs");

function registerIpcEvents(window) {
    registerWindowEvents(window);
    registerSystemEvents();
    registerDebugEvents();
}

function registerWindowEvents(window) {
    ipcMain.on("minimize-window", () => {
        window.minimize();
    });

    ipcMain.on("close-window", () => {
        window.close();
    });
}

function registerSystemEvents() {
    ipcMain.on("start-process", (event, file, args) => {
        execFile(file, args, (error, stdout, stderr) => {
            if (error) {
                console.error(`Execution error: ${error.message}`);
                return;
            }

            if (stderr) {
                console.warn(`stderr: ${stderr}`);
            }

            console.log(`stdout: ${stdout}`);
        });
    });
}

function registerDebugEvents() {
    ipcMain.on("log", (event, text, text2) => {
        console.log(text, text2);
    });
}

module.exports = { registerIpcEvents };