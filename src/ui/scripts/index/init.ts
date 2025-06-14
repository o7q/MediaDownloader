import { invoke } from "@tauri-apps/api/core";
import { initTitlebar } from "../common/titlebar";
import { appWindow, download_history, download_queue } from "./main";
import { initInput } from "./input/input";
import { initOutput } from "./output/output";
import { createIPCDownloadConfig, IPCDownloadConfig } from "../common/download-config";
import { generateIPCDownloadConfig } from "./download-config-gen/generate";
import { loadIPCDownloadConfig } from "./download-config-gen/load";
import { initHistory } from "./history-opener";

export async function init() {
    initTitlebar();
    initHistory();

    let tempDownloadQueue: IPCDownloadConfig[] = await invoke("load_queue");
    let tempDownloadHistory: IPCDownloadConfig[] = await invoke("load_history");

    for (let i = 0; i < tempDownloadQueue.length; ++i) {
        download_queue[i] = tempDownloadQueue[i];
    }

    for (let i = 0; i < tempDownloadHistory.length; ++i) {
        download_history[i] = tempDownloadHistory[i];
    }

    document.getElementById("titlebar-history-button")?.addEventListener("click", async () => {
        appWindow.minimize();
    });

    document.getElementById("titlebar-minimize-button")?.addEventListener("click", async () => {
        appWindow.minimize();
    });

    document.getElementById("titlebar-close-button")?.addEventListener("click", async () => {
        await invoke("write_current_download_config", { config: generateIPCDownloadConfig() });
        await invoke("write_queue", { queue: download_queue });
        await invoke("write_history", { history: download_history });
        appWindow.close();
    });

    initInput();
    initOutput();

    const downloadConfig: IPCDownloadConfig = await invoke("load_current_download_config");

    if (downloadConfig.valid) {
        loadIPCDownloadConfig(downloadConfig);
    } else {
        loadIPCDownloadConfig(generateIPCDownloadConfig());
    }
}