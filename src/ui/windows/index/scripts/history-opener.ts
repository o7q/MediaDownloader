import { WebviewWindow } from "@tauri-apps/api/webviewWindow";

import { downloadHistory } from "./main";
import { loadIPCDownloadConfig } from "./download-config/load";

export function initHistoryOpener() {
    document.getElementById("titlebar-history-edit-button")?.addEventListener("click", async () => {
        openHistoryWindow();
    });
}

export async function openHistoryWindow() {
    const names = downloadHistory.map(item => item.output.name);

    const webview = new WebviewWindow("historyWindow", {
        url: "history.html",
        title: "MediaDownloader History",
        width: 450,
        height: 300,
        minWidth: 450,
        minHeight: 300,
        decorations: false
    });

    const unlistenHistoryRequest = await webview.listen("history-request", () => {
        webview.emit("history-request-return", names);
    });

    const unlistenHistoryLoad = await webview.listen<number>("history-load", (event) => {
        loadIPCDownloadConfig(downloadHistory[event.payload]);
    });

    const unlistenHistoryRemove = await webview.listen<number[]>("history-remove", (event) => {
        const sortedIndices = [...event.payload].sort((a, b) => b - a);

        sortedIndices.forEach(index => {
            if (index >= 0 && index < downloadHistory.length) {
                downloadHistory.splice(index, 1);
            }
        });
    });

    const unlistenClose = await webview.onCloseRequested(async () => {
        unlistenClose();

        unlistenHistoryRequest();
        unlistenHistoryLoad();
        unlistenHistoryRemove();
    });
}