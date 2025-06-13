import { isUrlPlaylist } from "../utils";

export function initInput() { 
    const inputUrlTextbox = document.getElementById("input-url-textbox") as HTMLInputElement | null;
    const inputUrlText = document.getElementById("input-url-text") as HTMLInputElement | null;

    if (!inputUrlTextbox || !inputUrlText) return;

    document.getElementById("input-url-textbox")?.addEventListener("input", () => {
        if (isUrlPlaylist(inputUrlTextbox.value)) {
            inputUrlText.textContent = "URL (Playlist Detected)";
        }
        else {
            inputUrlText.textContent = "URL";
        }
    });
}