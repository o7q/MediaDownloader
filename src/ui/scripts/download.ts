import { invoke } from '@tauri-apps/api/core';
import { generateIPCConfig, IPCConfig } from './config/generate';

export async function startDownloadAsync() {
    const ipcConfig: IPCConfig = generateIPCConfig();

    const download_name = await download(ipcConfig);

    const outputNameTextbox = document.getElementById("output-name-textbox") as HTMLInputElement;

    if (outputNameTextbox && download_name) {
        outputNameTextbox.value = download_name;
    }

    await convert(ipcConfig);
}

async function download(ipcConfig: IPCConfig): Promise<string> {
    return await invoke("download", { ipcConfig: ipcConfig });
}

async function convert(ipcConfig: IPCConfig) {
    await invoke("convert", { ipcConfig: ipcConfig });
}