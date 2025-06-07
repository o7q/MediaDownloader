import { listen } from "@tauri-apps/api/event";
import { isUrlPlaylist } from "../utils";
import { IPCLoggerEvent } from "../../common/logger";

export function initTextboxes() {
    initUrlTextbox();
    initNameTextbox();
    initConsoleTextarea();
}

function initUrlTextbox() {
    const inputUrlTextbox = document.getElementById("input-url-textbox") as HTMLInputElement | null;
    const inputUrlText = document.getElementById("input-url-text") as HTMLInputElement | null;

    if (!inputUrlTextbox || !inputUrlText) return;

    inputUrlTextbox.addEventListener("input", () => {
        if (isUrlPlaylist(inputUrlTextbox.value)) {
            inputUrlText.textContent = "URL (Playlist Detected)";
        }
        else {
            inputUrlText.textContent = "URL";
        }
    });
}

function initNameTextbox() {
    const outputNameTextbox = document.getElementById("output-name-textbox") as HTMLInputElement | null;
    const outputNameText = document.getElementById("output-name-text") as HTMLInputElement | null;

    if (!outputNameTextbox || !outputNameText) return;

    outputNameTextbox.addEventListener("input", () => {
        if (outputNameTextbox.value === "") {
            outputNameText.textContent = "Name (Auto)";
        }
        else {
            outputNameText.textContent = "Name";
        }
    });
}

function initConsoleTextarea() {
    console.log("dd");
    let consoleTextarea = document.getElementById("output-console-textarea") as HTMLTextAreaElement | null;

    if (!consoleTextarea) return;

    listen<IPCLoggerEvent>("log", (event) => {
        consoleTextarea.value += '\n' + event.payload.text;
        consoleTextarea.scrollTop = consoleTextarea.scrollHeight;
    });
}