<div align="center">
    <table>
        <tr>
            <td>
                <img src="docs/images/icon.png" width="125px">
            </td>
            <td>
                <strong>MediaDownloader</strong>
                <br>
                A simple, <i>lightweight</i> 🍃 GUI wrapper for yt-dlp.
                <br>
                <img src="https://img.shields.io/github/downloads/o7q/MediaDownloader/total?logo=github&label=Downloads&color=%232fd653">
                <img src="https://img.shields.io/github/languages/code-size/o7q/MediaDownloader?logo=github&label=Code%20Size&color=%23b65cff">
                <br>
                <strong><a href="">Download</a></strong>
            </td>
        </tr>
    </table>
    <img src="docs/images/interface.png" style="width: 400px;">
</div>

## ❔ What is it?

A **simple** and **lightweight** GUI wrapper for [yt-dlp](https://github.com/yt-dlp/yt-dlp) and [FFmpeg](https://ffmpeg.org).

It provides a simple abstraction for basic yt-dlp and FFmpeg features while giving full access to each API via custom argument injections, all nicely packaged in a self-contained, cross-platform binary.

## 💽 How do I get it?

By grabbing a binary from the 👉 [downloads page](https://github.com/o7q/MediaDownloader/releases).

## 🔨 How do I build it?

You can follow these steps:
- Follow the Tauri prerequisites tutorial:
  - https://tauri.app/start/prerequisites

- Download & extract the MediaDownloader [source code](https://github.com/o7q/MediaDownloader/archive/refs/heads/main.zip)

- Navigate into the source code and run following commands:
    ```
    npm install
    ```
    ```
    npm run tauri-build
    ```
    **OR** *(for development)*:
    ```
    npm run tauri-dev
    ```

The built binary can be found in `src/app/target/release`.

---

Built with [**Tauri**](https://tauri.app)
