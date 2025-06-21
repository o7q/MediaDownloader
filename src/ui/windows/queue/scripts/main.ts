import { emit, listen } from "@tauri-apps/api/event";
import { getCurrentWindow } from "@tauri-apps/api/window";
export const appWindow = getCurrentWindow();

import { initUI } from "../../../common/scripts/ui";
import { initTitlebar } from "../../../common/scripts/titlebar";

document.addEventListener("DOMContentLoaded", async () => {
    initUI();
    initTitlebar();

    document.getElementById("queue-load-selected-button")?.addEventListener("click", () => {
        const select = document.getElementById("queue-select") as HTMLSelectElement;

        if (select.options.length < 1) {
            return;
        }

        emit("queue-load", select.selectedOptions[0].index);
    });

    const removedIndices: number[] = [];
    document.getElementById("queue-remove-selected-button")?.addEventListener("click", () => {
        const select = document.getElementById("queue-select") as HTMLSelectElement;

        for (let i = select.options.length - 1; i >= 0; i--) {
            const option = select.options[i];
            if (select.options[i].selected) {
                const originalIndex = parseInt(option.getAttribute("data-index") || "-1", 10);
                if (originalIndex !== -1) {
                    removedIndices.push(originalIndex);
                }
                select.remove(i);
            }
        }
    });

    const unlistenQueueRequestReturn = await listen<string[]>("queue-request-return", (event) => {
        const select = document.getElementById("queue-select");

        for (let i = event.payload.length - 1; i >= 0; --i) {
            const option = document.createElement("option");
            option.text = event.payload[i];
            option.setAttribute("data-index", i.toString());
            select?.appendChild(option);
        }
    });

    document.getElementById("titlebar-minimize-button")?.addEventListener("click", () => {
        appWindow.minimize();
    });

    document.getElementById("titlebar-close-button")?.addEventListener("click", () => {
        emit("queue-remove", removedIndices);
        unlistenQueueRequestReturn();
        appWindow.close();
    });

    emit("queue-request");

    listen("global-close", () => {
        appWindow.close();
    });
});
