import { open } from '@tauri-apps/plugin-dialog';
import { startDownloadAsync } from '../download';
import { WebviewWindow } from '@tauri-apps/api/webviewWindow';

export function initButtons() {
    document.getElementById("output-download-button")?.addEventListener("click", () => {
        startDownloadAsync();
    });

    document.getElementById("output-path-button")?.addEventListener("click", async () => {
        const file = await open({
            directory: true,
        });

        const pathTextbox = document.getElementById("output-path-textbox") as HTMLInputElement | null;

        if (!pathTextbox || !file) return;

        pathTextbox.value = file;
    });

    document.getElementById("output-console-open-button")?.addEventListener("click", async () => {
        const webview = new WebviewWindow("consoleWindow", {
            url: "console.html",
            title: "MediaDownloader Console",
            width: 750,
            height: 500,
            minWidth: 450,
            minHeight: 300,
            decorations: false
        });

        webview.once('tauri://created', function () {
            console.log("Window created successfully");
        });

        webview.once('tauri://error', function (e) {
            console.log("Error creating window:", e);
        });
    });
}