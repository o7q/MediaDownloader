const { open } = window.__TAURI__.dialog;

async function openPathDialogAsync() {
    const file = await open({
        directory: true,
    });

    document.getElementById("output-path-textbox").value = file;
}