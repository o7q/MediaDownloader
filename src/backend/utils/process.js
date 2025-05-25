const { spawn } = require('node:child_process');

function startProcess(path, args) {
    return new Promise((resolve, reject) => {
        const child = spawn(path, args, { stdio: 'ignore' });

        child.on('close', (exitCode) => {
            if (exitCode === 0) {
                resolve(exitCode);
            } else {
                reject(new Error(`Process exited with code ${exitCode}`));
            }
        });

        child.on('error', (error) => {
            reject(error);
        });
    });
}

module.exports = { startProcess };