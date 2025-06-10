import { startDownloadAsync } from '../download';
import { openConsoleWindow } from '../mini-console';
import { openDialogAsync } from '../dialog';
import { generateIPCDownloadConfig } from '../download_config/generate';
import { addQueueItemAsync } from '../queue';

export function initButtons() {
    document.getElementById("output-download-button")?.addEventListener("click", () => {
        startDownloadAsync();
    });

    document.getElementById("output-path-button")?.addEventListener("click", async () => {
        let file = await openDialogAsync();

        const pathTextbox = document.getElementById("output-path-textbox") as HTMLInputElement | null;

        if (!pathTextbox) return;

        pathTextbox.value = file.toString();
    });

    document.getElementById("output-queue-add-button")?.addEventListener("click", async () => {
        addQueueItemAsync(generateIPCDownloadConfig());
    });

    document.getElementById("output-console-open-button")?.addEventListener("click", async () => {
        openConsoleWindow();
    });
}