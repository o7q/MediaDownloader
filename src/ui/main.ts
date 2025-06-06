import { listen } from '@tauri-apps/api/event';
import { getCurrentWindow } from '@tauri-apps/api/window';

import { initTitlebar } from './scripts/ui/titlebar';
import { initButtons } from './scripts/ui/buttons';
import { initTextboxes } from './scripts/ui/textboxes';

export const appWindow = getCurrentWindow();

interface IPCLoggerEvent {
    text: string;
};

document.addEventListener("DOMContentLoaded", () => {
    initTitlebar();
    initButtons();
    initTextboxes();

    listen<IPCLoggerEvent>("log", (event) => {
        console.log(
            `${event.payload.text}`
        );
    });
});