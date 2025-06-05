import { getCurrentWindow } from '@tauri-apps/api/window';

import { initTitlebar } from './scripts/ui/titlebar';
import { initButtons } from './scripts/ui/buttons';
import { initTextboxes } from './scripts/ui/textboxes';

export const appWindow = getCurrentWindow();

document.addEventListener("DOMContentLoaded", () => {
    initTitlebar();
    initButtons();
    initTextboxes();
});