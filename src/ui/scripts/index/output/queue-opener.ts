import { WebviewWindow } from "@tauri-apps/api/webviewWindow";

import { IPCDownloadConfig } from "../../common/download-config";
import { download_queue } from "../main";
import { generateIPCDownloadConfig } from "../download-config-gen/generate";
import { loadIPCDownloadConfig } from "../download-config-gen/load";

export function initQueue() {
    document.getElementById("output-queue-add-button")?.addEventListener("click", async () => {
        download_queue.push(generateIPCDownloadConfig());
    });

    document.getElementById("output-queue-edit-button")?.addEventListener("click", async () => {
        openQueueWindow();
    });

    document.getElementById("output-queue-checkbox-enable")?.addEventListener("change", async (event) => {
        const checkbox = event.target as HTMLInputElement;

        const button = document.getElementById("output-download-button") as HTMLButtonElement | null;
        if (checkbox.checked) {
            if (button) {
                button.innerText = "Download Queue";
            }
        } else {
            if (button) {
                button.innerText = "Download";
            }
        }
    });
}

export async function openQueueWindow() {
    const names = download_queue.map(item => item.output.name);

    const webview = new WebviewWindow("queueWindow", {
        url: "queue.html",
        title: "MediaDownloader Queue",
        width: 450,
        height: 300,
        minWidth: 450,
        minHeight: 300,
        decorations: false
    });

    const unlistenQueueRequest = await webview.listen("queue-request", () => {
        webview.emit("queue-request-return", names);
    });

    const unlistenQueueLoad = await webview.listen<number>("queue-load", (event) => {
        loadIPCDownloadConfig(download_queue[event.payload]);
    });

    const unlistenQueueRemove = await webview.listen<number[]>("queue-remove", (event) => {
        const sortedIndices = [...event.payload].sort((a, b) => b - a);

        sortedIndices.forEach(index => {
            if (index >= 0 && index < download_queue.length) {
                download_queue.splice(index, 1);
            }
        });
    });

    const unlistenClose = await webview.onCloseRequested(async () => {
        unlistenClose();

        unlistenQueueRequest();
        unlistenQueueLoad();
        unlistenQueueRemove();
    });
}