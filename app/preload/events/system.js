const { ipcMain } = require("electron");
const { spawn } = require('child_process');
const fs = require("node:fs");

function registerSystemEvents() {
    ipcMain.on('start-process', (event, file, args) => {
        const child = spawn(file, args);

        child.stdout.on('data', (data) => {
            process.stdout.write(data);
        });

        child.stderr.on('data', (data) => {
            process.stdout.write(data);
        });

        child.on('error', (error) => {
            console.error(`Execution error: ${error.message}`);
        });

        child.on('close', (code) => {
            console.log(`Process exited with code ${code}`);
        });
    });

    ipcMain.handle("create-file", async (event, path, data) => {
        try {
            fs.writeFileSync(path, data);
            return { success: true };
        } catch (e) {
            return { success: false, error: e.message };
        }
    });

    ipcMain.handle('create-folder', async (event, path) => {
        try {
            if (!fs.existsSync(path)) {
                fs.mkdirSync(path);
            }
            return { success: true };
        } catch (e) {
            console.error(e);
            return { success: false, error: e.message };
        }
    });
}

module.exports = { registerSystemEvents };