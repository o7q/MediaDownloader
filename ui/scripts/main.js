const invoke = window.__TAURI__.core.invoke;
const appWindow = window.__TAURI__.window.getCurrentWindow();

document.addEventListener("DOMContentLoaded", () => {
    initTitlebar();
    initButtons();
});