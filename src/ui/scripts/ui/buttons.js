function initButtons() {
    document.getElementById("output-download-button").addEventListener("click", () => {
        startDownloadAsync();
    });

    document.getElementById("output-path-button").addEventListener("click", () => {
        openPathDialogAsync();
    });
}