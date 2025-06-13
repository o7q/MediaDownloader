import { getCurrentWindow } from "@tauri-apps/api/window";
export const appWindow = getCurrentWindow();

import { init } from "./init";
import { IPCDownloadConfig } from "../common/download-config";

export let download_queue: IPCDownloadConfig[] = [];
export let download_history: IPCDownloadConfig[] = [];

document.addEventListener("DOMContentLoaded", () => {
    init();
});