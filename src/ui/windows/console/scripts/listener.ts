import { listen } from "@tauri-apps/api/event";
import { IPCLoggerEvent } from "../../../common/scripts/logger"

export function initConsole() {
    let consoleTextarea = document.getElementById("console-textarea") as HTMLTextAreaElement | null;

    if (!consoleTextarea) return;

    document.getElementById("console-clear-button")?.addEventListener("click", async () => {
        consoleTextarea.value = "";
    });

    listen<IPCLoggerEvent>("log", (event) => {
        consoleTextarea.value += event.payload.text + '\n';
        consoleTextarea.scrollTop = consoleTextarea.scrollHeight;
    });
}