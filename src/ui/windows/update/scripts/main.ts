import { emit, listen } from "@tauri-apps/api/event";
import { getCurrentWindow } from "@tauri-apps/api/window";
export const appWindow = getCurrentWindow();

import { initUI } from "../../../common/scripts/ui";
import { initTitlebar } from "../../../common/scripts/titlebar";
import { IPCUpdateMetadata } from "../../../common/scripts/update";

document.addEventListener("DOMContentLoaded", async () => {
    initUI();
    initTitlebar();

    const unlistenUpdateRequestReturn = await listen<IPCUpdateMetadata>("update-request-return", (event) => {
        console.log(event.payload);

        const versionText = document.getElementById("version-text") as HTMLParagraphElement | null;
        const descriptionText = document.getElementById("description-text") as HTMLParagraphElement | null;

        if (!versionText || !descriptionText) return;

        versionText.textContent = `Version: ${event.payload.version}`;
        descriptionText.innerHTML = `${event.payload.description.replace(/\n/g, "<br>")}`;
    });

    document.getElementById("titlebar-minimize-button")?.addEventListener("click", () => {
        appWindow.minimize();
    });

    document.getElementById("titlebar-close-button")?.addEventListener("click", () => {
        unlistenUpdateRequestReturn();
        appWindow.close();
    });

    emit("update-request");

    document.getElementById("yes-button")?.addEventListener("click", () => {
        emit("update-yes");
        unlistenUpdateRequestReturn();
        appWindow.close();
    });

    document.getElementById("no-button")?.addEventListener("click", () => {
        unlistenUpdateRequestReturn();
        appWindow.close();
    });

    document.getElementById("dontshow-button")?.addEventListener("click", () => {
        emit("update-dontshow");
        unlistenUpdateRequestReturn();
        appWindow.close();
    });
});