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

    const downloadButton = document.getElementById("output-download-button") as HTMLButtonElement | null;

    if (!await invoke("bootstrap_check")) {
        if (downloadButton) downloadButton.disabled = true;
        await invoke("bootstrap_install")
        if (downloadButton) downloadButton.disabled = false;
    }
}

async function initTitlebarButtons() {
    document.getElementById("titlebar-reset-button")?.addEventListener("click", async () => {
        loadIPCDownloadConfig(createIPCDownloadConfig());
        updateSettingsUI();
    });

    document.getElementById("titlebar-minimize-button")?.addEventListener("click", async () => {
        appWindow.minimize();
    });

    document.getElementById("titlebar-close-button")?.addEventListener("click", async () => {
        await invoke("data_write_download_config", { config: generateIPCDownloadConfig() });
        await invoke("data_write_queue", { queue: downloadQueue });
        await invoke("data_write_history", { history: downloadHistory });
        appWindow.close();
    });
}

async function initGlobals() {
    let tempDownloadQueue: IPCDownloadConfig[] = await invoke("data_load_queue");
    let tempDownloadHistory: IPCDownloadConfig[] = await invoke("data_load_history");

    for (let i = 0; i < tempDownloadQueue.length; ++i) {
        downloadQueue[i] = tempDownloadQueue[i];
    }

    for (let i = 0; i < tempDownloadHistory.length; ++i) {
        downloadHistory[i] = tempDownloadHistory[i];
    }
}

async function loadDefaultDownloadConfig() {
    const downloadConfig: IPCDownloadConfig = await invoke("data_load_download_config");

    if (downloadConfig.valid) {
        loadIPCDownloadConfig(downloadConfig);
    } else {
        loadIPCDownloadConfig(createIPCDownloadConfig());
    }

    updateSettingsUI();
}