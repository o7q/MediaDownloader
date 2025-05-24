function initTitlebar() {
    document.getElementById("min-button").addEventListener("click", () => {
        window.windowControls.minimizeWindow();
    });

    document.getElementById("close-button").addEventListener("click", () => {
        window.windowControls.closeWindow();
    });
}