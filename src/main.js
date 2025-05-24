const { app, BrowserWindow } = require('electron');

const createWindow = () => {
    const win = new BrowserWindow({
        width: 500,
        height: 250,
        frame: false,
        titleBarStyle: 'hidden'
    });

    win.loadFile('index.html');
}

app.whenReady().then(() => {
    createWindow();
});