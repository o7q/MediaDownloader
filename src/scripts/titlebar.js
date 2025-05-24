const { ipcRenderer } = require('electron');

function initTitlebar() {
    document.getElementById('min-button').addEventListener('click', () => {
        ipcRenderer.send('minimize-window');
    });

    document.getElementById('close-button').addEventListener('click', () => {
        ipcRenderer.send('close-window');
    });
}