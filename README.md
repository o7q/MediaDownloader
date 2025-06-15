<div align="center">
    <table>
        <tr>
            <td>
                <img src="docs/images/icon.png" width="125px">
            </td>
            <td>
                <strong>MediaDownloader</strong>
                <br>
                A modern, lightweight 🍃 GUI wrapper for yt-dlp.
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

# MediaDownloader

---

## What is it?

A simple, modern, and extremely lightweight GUI wrapper for [yt-dlp](https://github.com/yt-dlp/yt-dlp) and [FFmpeg](https://ffmpeg.org). \
It provides a simple abstraction for basic yt-dlp and FFmpeg features while giving full access to each API via custom argument injections.

## How do I use it?

You can use MediaDownloader on any platform by simply grabbing a binary from the [downloads page](https://github.com/o7q/MediaDownloader/releases).

## How do I build it?

You can follow these steps:

- Ensure you have **Node.js** and **Rust** installed
  - https://nodejs.org
  - https://www.rust-lang.org

- Download & extract the MediaDownloader [source code](https://github.com/o7q/MediaDownloader/archive/refs/heads/main.zip).
- Navigate into the source code and run following commands:
    ```
    npm install
    ```
    ```
    npm run tauri-build
    ```

---

Built with [**Tauri**](https://tauri.app)
