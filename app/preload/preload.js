const { contextBridge, ipcRenderer } = require("electron");

contextBridge.exposeInMainWorld("windowControls", {
    minimizeWindow: () => ipcRenderer.send("minimize-window"),
    closeWindow: () => ipcRenderer.send("close-window")
});

contextBridge.exposeInMainWorld("system", {
    createFile: (path, data) => ipcRenderer.invoke("create-file", path, data),
    createFolder: (path) => ipcRenderer.invoke("create-folder", path),
    startProcess: (path, args) => ipcRenderer.send("start-process", path, args)
});

contextBridge.exposeInMainWorld("debug", {
    log: (text) => ipcRenderer.send("log", text)
});