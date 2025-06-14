import { emit, listen } from "@tauri-apps/api/event";
import { getCurrentWindow } from "@tauri-apps/api/window";
export const appWindow = getCurrentWindow();

import { initTitlebar } from "../../../common/scripts/titlebar";

document.addEventListener("DOMContentLoaded", async () => {
    initTitlebar();

    document.getElementById("queue-load-selected-button")?.addEventListener("click", () => {
        const select = document.getElementById("queue-select") as HTMLSelectElement;

        if (select.options.length < 1) {
            return;
        }

        emit("queue-load", select.selectedOptions[0].index);
    });

    document.getElementById("queue-remove-selected-button")?.addEventListener("click", () => {
        const select = document.getElementById("queue-select") as HTMLSelectElement;

        const removedIndices: number[] = [];

        for (let i = select.options.length - 1; i >= 0; i--) {
            if (select.options[i].selected) {
                removedIndices.push(i);
                select.remove(i);
            }
        }

        emit("queue-remove", removedIndices);
    });

    const unlistenQueueRequestReturn = await listen<string[]>("queue-request-return", (event) => {
        const select = document.getElementById("queue-select");
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
        unlistenQueueRequestReturn();
        appWindow.close();
    });

    emit("queue-request");
});
