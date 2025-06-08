import { WebviewWindow } from "@tauri-apps/api/webviewWindow";

export function openConsoleWindow() {
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
}