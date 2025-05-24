const { contextBridge, ipcRenderer } = require("electron");

contextBridge.exposeInMainWorld("windowControls", {
    minimizeWindow: () => ipcRenderer.send("minimize-window"),
    closeWindow: () => ipcRenderer.send("close-window")
});

contextBridge.exposeInMainWorld("system", {
    createFile: (path) => ipcRenderer.send("create-file", path),
    createFolder: (path) => ipcRenderer.send("create-folder", path),
    startProcess: (path, args) => ipcRenderer.send("start-process", path, args)
});

contextBridge.exposeInMainWorld("debug", {
    log: (text) => ipcRenderer.send("log", text)
});