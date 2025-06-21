import { emit, listen } from "@tauri-apps/api/event";
import { getCurrentWindow } from "@tauri-apps/api/window";
export const appWindow = getCurrentWindow();

import { initUI } from "../../../common/scripts/ui";
import { initTitlebar } from "../../../common/scripts/titlebar";

document.addEventListener("DOMContentLoaded", async () => {
    initUI();
    initTitlebar();

    document.getElementById("history-load-selected-button")?.addEventListener("click", () => {
        const select = document.getElementById("history-select") as HTMLSelectElement;
        const selectedOptions = select.selectedOptions;
        if (selectedOptions.length < 1) return;

        const originalIndex = parseInt(selectedOptions[0].getAttribute("data-index") || "-1", 10);

        if (originalIndex > -1) {
            emit("history-load", originalIndex);
        }
    });

    const removedIndices: number[] = [];
    document.getElementById("history-remove-selected-button")?.addEventListener("click", () => {
        const select = document.getElementById("history-select") as HTMLSelectElement;

        if (!select) return;

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

    const unlistenHistoryRequestReturn = await listen<string[]>("history-request-return", (event) => {
        const select = document.getElementById("history-select");

        for (let i = event.payload.length - 1; i >= 0; --i) {
            const option = document.createElement("option");
            option.text = event.payload[i];
            option.setAttribute("data-index", i.toString());
            select?.appendChild(option);
        }
    });

    document.getElementById("history-saveclose-button")?.addEventListener("click", () => {
        emit("history-remove", removedIndices);
        unlistenHistoryRequestReturn();
        appWindow.close();
    });

    document.getElementById("titlebar-minimize-button")?.addEventListener("click", () => {
        appWindow.minimize();
    });

    document.getElementById("titlebar-close-button")?.addEventListener("click", () => {
        unlistenHistoryRequestReturn();
        appWindow.close();
    });

    emit("history-request");

    listen("global-close", () => {
        appWindow.close();
    });
});
