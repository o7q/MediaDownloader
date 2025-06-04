import { initTitlebar } from './scripts/ui/titlebar';
import { initButtons } from './scripts/ui/buttons';
import { initTextboxes } from './scripts/ui/textboxes';

document.addEventListener("DOMContentLoaded", () => {
    initTitlebar();
    initButtons();
    initTextboxes();
});