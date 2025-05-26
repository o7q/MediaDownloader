function initTitlebar() {
    document.getElementById("titlebar").addEventListener("mousedown", (e) => {
        if (
            e.buttons === 1 &&
            e.detail !== 2 &&
            !(
                e.target.closest("button") ||
                e.target.closest("#minimize-button") ||
                e.target.closest("#close-button")
            )
        ) {
            appWindow.startDragging();
        }
    });

    document.getElementById("minimize-button").addEventListener("click", () => {
        appWindow.minimize();
    });

    document.getElementById("close-button").addEventListener("click", () => {
        appWindow.close();
    });
}