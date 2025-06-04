import { open } from '@tauri-apps/plugin-dialog';
import { startDownloadAsync } from '../download';

export function initButtons() {
    const downloadButton = document.getElementById("output-download-button") as HTMLButtonElement | null;
    const pathButton = document.getElementById("output-path-button") as HTMLButtonElement | null;

    if (!downloadButton || !pathButton) return;

    downloadButton.addEventListener("click", () => {
        startDownloadAsync();
    });

    pathButton.addEventListener("click", async () => {
        const file = await open({
            directory: true,
        });

        const pathTextbox = document.getElementById("output-path-textbox") as HTMLInputElement | null;

        if (!pathTextbox || !file) return;

        pathTextbox.value = file;
    });
}