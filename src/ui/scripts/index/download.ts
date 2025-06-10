import { invoke } from '@tauri-apps/api/core';
import { IPCDownloadConfig } from './download_config/interface';
import { generateIPCDownloadConfig } from './download_config/generate';

export async function startDownloadAsync() {
    let consoleTextarea = document.getElementById("output-console-textarea") as HTMLTextAreaElement | null;
    if (consoleTextarea) consoleTextarea.value = "";

    const ipcConfig: IPCDownloadConfig = generateIPCDownloadConfig();

    await invoke("download", { config: ipcConfig });
}