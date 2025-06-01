function initTextboxes() {
    initUrlTextbox();
    initNameTextbox();
}

function initUrlTextbox() {
    const inputUrlTextbox = document.getElementById("input-url-textbox");
    const inputUrlText = document.getElementById("input-url-text");
    inputUrlTextbox.addEventListener("input", () => {
        if (isUrlPlaylist(inputUrlTextbox.value)) {
            inputUrlText.textContent = "URL (Playlist Detected)";
        }
        else {
            inputUrlText.textContent = "URL";
        }
    });
}

function initNameTextbox() {
    const outputNameTextbox = document.getElementById("output-name-textbox");
    const outputNameText = document.getElementById("output-name-text");
    outputNameTextbox.addEventListener("input", () => {
        if (outputNameTextbox.value === "") {
            outputNameText.textContent = "Name (Auto)";
        }
        else {
            outputNameText.textContent = "Name";
        }
    });
}