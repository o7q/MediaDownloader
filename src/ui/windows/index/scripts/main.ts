import { getCurrentWindow } from "@tauri-apps/api/window";
export const appWindow = getCurrentWindow();

import { init } from "./init";
import { createIPCUserConfig, IPCUserConfig } from "../../../common/scripts/user-config";
import { IPCDownloadConfig } from "../../../common/scripts/download-config";

interface Global {
    userConfig: IPCUserConfig;
    downloadQueue: IPCDownloadConfig[];
    downloadHistory: IPCDownloadConfig[];
}

export let GLOBAL: Global = {
    userConfig: createIPCUserConfig(),
    downloadQueue: [],
    downloadHistory: []
}

document.addEventListener("DOMContentLoaded", () => {
    init();
});