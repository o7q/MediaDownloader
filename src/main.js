const { app, BrowserWindow, ipcMain } = require('electron');
const path = require('path');

let window;

const createWindow = () => {
    window = new BrowserWindow({
        width: 500,
        height: 250,
        frame: false,
        titleBarStyle: 'hidden',
        icon: path.join(__dirname, 'assets/icon.ico'),
        webPreferences: {
            nodeIntegration: true,
            contextIsolation: false
        }
    });

    window.loadFile('index.html');

    ipcMain.on('minimize-window', () => {
        window.minimize();
    });

    ipcMain.on('close-window', () => {
        window.close();
    });
}

app.whenReady().then(() => {
    createWindow();
});