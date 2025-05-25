const { contextBridge, ipcRenderer } = require("electron");

contextBridge.exposeInMainWorld("windowControls", {
    minimizeWindow: () => ipcRenderer.send("minimize-window"),
    closeWindow: () => ipcRenderer.send("close-window")
});

contextBridge.exposeInMainWorld("downloader", {
    download: (downloadSettings) => ipcRenderer.invoke("download-url", downloadSettings),
    convert: (convertSettings) => ipcRenderer.invoke("convert", convertSettings),
    finalize: () => ipcRenderer.invoke("finalize")
});