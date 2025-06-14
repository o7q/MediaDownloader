import { getCurrentWindow } from "@tauri-apps/api/window";
export const appWindow = getCurrentWindow();

import { init } from "./init";
import { IPCDownloadConfig } from "../../../common/scripts/download-config";

export let downloadQueue: IPCDownloadConfig[] = [];
export let downloadHistory: IPCDownloadConfig[] = [];

document.addEventListener("DOMContentLoaded", () => {
    init();
});