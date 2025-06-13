import { invoke } from "@tauri-apps/api/core";

import { IPCDownloadConfig } from "../../common/download-config";
import { generateIPCDownloadConfig } from "../download-config-gen/generate";
import { download_queue } from "../main";

export function initDownloadButton() {
    document.getElementById("output-download-button")?.addEventListener("click", () => {
        startDownloadAsync();
    });
}

export async function startDownloadAsync() {
    let queueCheckbox = document.getElementById("output-queue-checkbox-enable") as HTMLInputElement | null;
    const shouldDownloadQueue = queueCheckbox?.checked;

    let consoleTextarea = document.getElementById("output-console-textarea") as HTMLTextAreaElement | null;
    if (consoleTextarea) consoleTextarea.value = "";

    if (shouldDownloadQueue) {
        for (const downloadConfig of download_queue) {
            await invoke("download", { config: downloadConfig });
        };
    }
    else {
        const downloadConfig: IPCDownloadConfig = generateIPCDownloadConfig();

        await invoke("download", { config: downloadConfig });
    }

}