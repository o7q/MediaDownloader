function isUrlPlaylist(url) {
    const playlistKeywords = ["/playlist?", "&list=", "?list=", "/sets"];
    for (const keyword of playlistKeywords) {
        if (url.includes(keyword)) {
            return true;
        }
    }
    return false;
}

async function openPathDialogAsync() {
    const file = await tauri_open({
        directory: true,
    });

    document.getElementById("output-path-textbox").value = file;
}