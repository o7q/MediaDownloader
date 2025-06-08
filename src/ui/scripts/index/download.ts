import { invoke } from '@tauri-apps/api/core';
import { IPCConfig } from './config/config';
import { generateIPCConfig } from './config/generate';

export async function startDownloadAsync() {
    let consoleTextarea = document.getElementById("output-console-textarea") as HTMLTextAreaElement | null;
    if (consoleTextarea) consoleTextarea.value = "";

    const ipcConfig: IPCConfig = generateIPCConfig();

    await invoke("download", { config: ipcConfig });
}