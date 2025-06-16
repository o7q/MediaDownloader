import { getCurrentWindow } from "@tauri-apps/api/window";
export const appWindow = getCurrentWindow();

import { initUI } from "../../../common/scripts/ui";
import { initTitlebar } from "../../../common/scripts/titlebar";
import { initConsole } from "./listener";

document.addEventListener("DOMContentLoaded", () => {
    initUI();
    initTitlebar();

    document.getElementById("titlebar-minimize-button")?.addEventListener("click", () => {
        appWindow.minimize();
    });

    document.getElementById("titlebar-close-button")?.addEventListener("click", () => {
        appWindow.close();
    });

    initConsole();
});