import { initTitlebar } from '../common/titlebar';
import { initConsole } from './listener';

document.addEventListener("DOMContentLoaded", () => {
    initTitlebar();

    initConsole();
});