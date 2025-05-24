document.addEventListener("DOMContentLoaded", () => {
    initTitlebar();
    initButtons();

    createDirectories();
});

async function createDirectories() {

}

function initButtons() {
    document.getElementById("download-button").addEventListener("click", () => {
        downloadStart();
    });
}

function initTitlebar() {
    document.getElementById("min-button").addEventListener("click", () => {
        window.windowControls.minimizeWindow();
    });

    document.getElementById("close-button").addEventListener("click", () => {
        window.windowControls.closeWindow();
    });
}