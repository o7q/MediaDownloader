import { emit, listen } from "@tauri-apps/api/event";
import { getCurrentWindow } from "@tauri-apps/api/window";
export const appWindow = getCurrentWindow();

import { initTitlebar } from "../../../common/scripts/titlebar";

document.addEventListener("DOMContentLoaded", async () => {
    initTitlebar();

    document.getElementById("history-load-selected-button")?.addEventListener("click", () => {
        const select = document.getElementById("history-select") as HTMLSelectElement;

        if (select.options.length < 1) {
            return;
        }

        emit("history-load", select.selectedOptions[0].index);
    });

    document.getElementById("history-remove-selected-button")?.addEventListener("click", () => {
        const select = document.getElementById("history-select") as HTMLSelectElement;

        const removedIndices: number[] = [];

        for (let i = select.options.length - 1; i >= 0; i--) {
            if (select.options[i].selected) {
                removedIndices.push(i);
                select.remove(i);
            }
        }

        emit("history-remove", removedIndices);
    });

    const unlistenHistoryRequestReturn = await listen<string[]>("history-request-return", (event) => {
        const select = document.getElementById("history-select");
        for (let i = 0; i < event.payload.length; ++i) {
            const option = document.createElement("option");
            option.text = event.payload[i];
            select?.appendChild(option);
        }
    });

    document.getElementById("titlebar-minimize-button")?.addEventListener("click", () => {
        appWindow.minimize();
    });

    document.getElementById("titlebar-close-button")?.addEventListener("click", () => {
        unlistenHistoryRequestReturn();
        appWindow.close();
    });

    emit("history-request");
});
