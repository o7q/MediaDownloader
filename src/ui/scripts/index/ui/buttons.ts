import { startDownloadAsync } from '../download';
import { openConsoleWindow } from '../console';
import { openDialogAsync } from '../dialog';

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

    document.getElementById("output-console-open-button")?.addEventListener("click", async () => {
        openConsoleWindow();
    });
}