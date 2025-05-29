const invoke = window.__TAURI__.core.invoke;
const appWindow = window.__TAURI__.window.getCurrentWindow();

// const { open } = window.__TAURI__.dialog;

document.addEventListener("DOMContentLoaded", () => {

    initTitlebar();
    initButtons();

    //     document.getElementById("output-download-button").addEventListener("click", async () => {
    //         // Open a selection dialog for image files
    //         const selected = await dialog.open({
    //             multiple: true,
    //             filters: [{
    //                 name: 'Image',
    //                 extensions: ['png', 'jpeg']
    //             }]
    //         });
    //         if (Array.isArray(selected)) {
    //             // user selected multiple files
    //         } else if (selected === null) {
    //             // user cancelled the selection
    //         } else {
    //             // user selected a single file
    //         }
    //     });
});