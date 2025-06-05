import { open } from '@tauri-apps/plugin-dialog';
import { startDownloadAsync } from '../download';

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
}