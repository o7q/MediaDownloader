const tauri_invoke = window.__TAURI__.core.invoke;
const tauri_appWindow = window.__TAURI__.window.getCurrentWindow();
const tauri_open = window.__TAURI__.dialog.open;

document.addEventListener("DOMContentLoaded", () => {
    initTitlebar();
    initButtons();
    initTextboxes();
});