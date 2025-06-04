import { isUrlPlaylist } from "../utils";

export function initTextboxes() {
    initUrlTextbox();
    initNameTextbox();
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