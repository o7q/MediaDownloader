import { getCurrentWindow } from '@tauri-apps/api/window';

import { initTitlebar } from '../common/titlebar';
import { initButtons } from './ui/buttons';
import { initTextboxes } from './ui/textboxes';

export const appWindow = getCurrentWindow();

document.addEventListener("DOMContentLoaded", () => {
    initTitlebar();
    initButtons();
    initTextboxes();
});