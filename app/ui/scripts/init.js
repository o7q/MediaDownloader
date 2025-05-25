document.addEventListener("DOMContentLoaded", () => {
    initTitlebar();
    initButtons();
});

function initTitlebar() {
    document.getElementById("min-button").addEventListener("click", () => {
        window.windowControls.minimizeWindow();
    });

    document.getElementById("close-button").addEventListener("click", () => {
        window.windowControls.closeWindow();
    });
}

function initButtons() {
    document.getElementById("download-button").addEventListener("click", async () => {
        const downloadSettings = {
            url: document.getElementById("url-textbox").value,
            name: ""
        };

        await window.downloader.download(downloadSettings);
    });
}