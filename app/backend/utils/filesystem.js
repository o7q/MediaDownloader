const fs = require("node:fs");
const path = require("node:path");

function createFile(path, content) {
    try {
        fs.writeFileSync(path, content);
        return { success: true };
    } catch (e) {
        return { success: false, error: e.message };
    }
}

function createDirectory(path) {
    try {
        if (!fs.existsSync(path)) {
            fs.mkdirSync(path);
        }
        return { success: true };
    } catch (e) {
        console.error(e);
        return { success: false, error: e.message };
    }
}

function getFiles(folderPath) {
    const files = [];

    fs.readdirSync(folderPath).forEach(file => {
        const filePath = path.join(folderPath, file);
        files.push(filePath);
    });

    return files;
}

module.exports = { createFile, createDirectory, getFiles };