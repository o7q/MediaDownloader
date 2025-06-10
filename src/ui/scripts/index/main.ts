import { getCurrentWindow } from '@tauri-apps/api/window';

import { initTitlebar } from '../common/titlebar';
import { initButtons } from './ui/buttons';
import { initTextboxes } from './ui/textboxes';
import { initMiniConsole } from './mini-console';

export const appWindow = getCurrentWindow();

document.addEventListener("DOMContentLoaded", () => {
    initTitlebar();
    initButtons();
    initTextboxes();

    initMiniConsole();
});