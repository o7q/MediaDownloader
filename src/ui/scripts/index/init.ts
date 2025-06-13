import { invoke } from "@tauri-apps/api/core";
import { initTitlebar } from "../common/titlebar";
import { appWindow, download_queue } from "./main";
import { initInput } from "./input/input";
import { initOutput } from "./output/output";
import { createIPCDownloadConfig, IPCDownloadConfig } from "../common/download-config";
import { generateIPCDownloadConfig } from "./download-config-gen/generate";
import { loadIPCDownloadConfig } from "./download-config-gen/load";

export async function init() {
    initTitlebar();

    let tempDownloadQueue: IPCDownloadConfig[] = await invoke("load_queue");

    for (let i = 0; i < tempDownloadQueue.length; ++i) {
        download_queue[i] = tempDownloadQueue[i];
    }

    document.getElementById("titlebar-minimize-button")?.addEventListener("click", async () => {
        appWindow.minimize();
    });

    document.getElementById("titlebar-close-button")?.addEventListener("click", async () => {
        await invoke("write_queue", { queue: download_queue });
        await invoke("write_current_download_config", { config: generateIPCDownloadConfig() });
        appWindow.close();
    });

    initInput();
    initOutput();

    const downloadConfig: IPCDownloadConfig = await invoke("load_current_download_config");

    if (downloadConfig.valid) {
        loadIPCDownloadConfig(downloadConfig);
    } else
    {
        loadIPCDownloadConfig(generateIPCDownloadConfig());
    }
}