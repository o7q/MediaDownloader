function initTitlebar() {
    document.getElementById("titlebar").addEventListener("mousedown", (e) => {
        if (
            e.buttons === 1 &&
            e.detail !== 2 &&
            !(
                e.target.closest("button") ||
                e.target.closest("#titlebar-minimize-button") ||
                e.target.closest("#titlebar-close-button")
            )
        ) {
            appWindow.startDragging();
        }
    });

    document.getElementById("titlebar-minimize-button").addEventListener("click", () => {
        appWindow.minimize();
    });

    document.getElementById("titlebar-close-button").addEventListener("click", () => {
        appWindow.close();
    });
}