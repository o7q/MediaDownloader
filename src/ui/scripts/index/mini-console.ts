import { WebviewWindow } from "@tauri-apps/api/webviewWindow";
import { listen } from "@tauri-apps/api/event";
import { IPCLoggerEvent } from "../common/logger";

export function initMiniConsole() {
    let consoleTextarea = document.getElementById("output-console-textarea") as HTMLTextAreaElement | null;

    if (!consoleTextarea) return;

    listen<IPCLoggerEvent>("log", (event) => {
        consoleTextarea.value += '\n' + event.payload.text;
        consoleTextarea.scrollTop = consoleTextarea.scrollHeight;
    });
}

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