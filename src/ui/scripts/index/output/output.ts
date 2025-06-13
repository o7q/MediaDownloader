import { openDialogAsync } from "../utils";
import { initMiniConsole, openConsoleWindow } from "./console";
import { initQueue } from "./queue";
import { initDownloadButton } from "./download";

export function initOutput() {
    const outputNameTextbox = document.getElementById("output-name-textbox") as HTMLInputElement | null;
    const outputNameText = document.getElementById("output-name-text") as HTMLInputElement | null;

    if (!outputNameTextbox || !outputNameText) return;

    outputNameTextbox?.addEventListener("input", () => {
        if (outputNameTextbox.value === "") {
            outputNameText.textContent = "Name (Auto)";
        }
        else {
            outputNameText.textContent = "Name";
        }
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

    initQueue();
    initDownloadButton();
    initMiniConsole();
}