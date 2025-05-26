const invoke = window.__TAURI__.core.invoke;

const { getCurrentWindow } = window.__TAURI__.window;
const appWindow = getCurrentWindow();

document.addEventListener("DOMContentLoaded", () => {
    initTitlebar();
    initButtons();
});

function initTitlebar() {

}

function initButtons() {
    document.getElementById("minimize-button").addEventListener("click", () => {
        appWindow.minimize();
    });

    document.getElementById("close-button").addEventListener("click", () => {
        appWindow.close();
    });

    document.getElementById("download-button").addEventListener("click", () => {
        let url = document.getElementById("url-textbox").value;
        invoke("download", { url: url });
    });
}