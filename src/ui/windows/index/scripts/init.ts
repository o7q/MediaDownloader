import { invoke } from "@tauri-apps/api/core";

import { appWindow, downloadHistory, downloadQueue } from "./main";

import { initTitlebar } from "../../../common/scripts/titlebar";
import { initInputUI } from "./input/input";
import { initSettingsUI } from "./settings/settings";
import { updateSettingsUI } from "./settings/settings-ui-handler";
import { initOutputUI } from "./output/output";
import { initHistoryOpener } from "./history-opener";

import { createIPCDownloadConfig, IPCDownloadConfig } from "../../../common/scripts/download-config";
import { generateIPCDownloadConfig } from "./download-config/generate";
import { loadIPCDownloadConfig } from "./download-config/load";

export async function init() {
    initTitlebar();
    initTitlebarButtons();

    initInputUI();
    initSettingsUI();
    initOutputUI();
    initHistoryOpener();

    initGlobals();

    loadDefaultDownloadConfig();
}

async function initTitlebarButtons() {
    document.getElementById("titlebar-minimize-button")?.addEventListener("click", async () => {
        appWindow.minimize();
    });

    document.getElementById("titlebar-close-button")?.addEventListener("click", async () => {
        await invoke("write_current_download_config", { config: generateIPCDownloadConfig() });
        await invoke("write_queue", { queue: downloadQueue });
        await invoke("write_history", { history: downloadHistory });
        appWindow.close();
    });
}

async function initGlobals() {
    let tempDownloadQueue: IPCDownloadConfig[] = await invoke("load_queue");
    let tempDownloadHistory: IPCDownloadConfig[] = await invoke("load_history");

    for (let i = 0; i < tempDownloadQueue.length; ++i) {
        downloadQueue[i] = tempDownloadQueue[i];
    }

    for (let i = 0; i < tempDownloadHistory.length; ++i) {
        downloadHistory[i] = tempDownloadHistory[i];
    }
}

async function loadDefaultDownloadConfig() {
    const downloadConfig: IPCDownloadConfig = await invoke("load_current_download_config");

    if (downloadConfig.valid) {
        loadIPCDownloadConfig(downloadConfig);
    } else {
        loadIPCDownloadConfig(createIPCDownloadConfig());
    }

    updateSettingsUI();
}