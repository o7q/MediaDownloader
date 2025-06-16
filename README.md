<<<<<<< dev
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

---
=======
# Update
MediaDownloader is currently being re-written in Rust using the [**Tauri**](https://tauri.app) framework, enabling cross-platform builds, better stability, and more features!

If you are interested, you can track its progress [**here**](https://github.com/o7q/MediaDownloader/tree/dev)!

<img src="assets/images/banner.png">

![Total Downloads](https://img.shields.io/github/downloads/o7q/MediaDownloader/total?logo=github&label=Total%20Downloads&color=%232fd653)
![Code Size](https://img.shields.io/github/languages/code-size/o7q/MediaDownloader?logo=github&label=Code%20Size&color=%23b65cff)
>>>>>>> main

## ❔ What is it?

A **simple** and **lightweight** GUI wrapper for [yt-dlp](https://github.com/yt-dlp/yt-dlp) and [FFmpeg](https://ffmpeg.org).

It provides a simple abstraction for basic yt-dlp and FFmpeg features while giving full access to each API via custom argument injections, all nicely packaged in a self-contained, cross-platform binary.

---

## 💽 How do I get it?

By grabbing a binary from the 👉 [downloads page](https://github.com/o7q/MediaDownloader/releases).

<details>
<summary><strong>Windows</strong></summary>

Simply run `MediaDownloader.exe`. It will automatically install all depenencies into the `MediaDownloader/bin` directory.

</details>

<details>
<summary><strong>Debian/Ubuntu</strong></summary>

To use MediaDownloader on Debian/Ubuntu. You need to install **yt-dlp** and **FFmpeg** manually.

- Install yt-dlp:
  - I recommend uninstalling any other yt-dlp before continuing:
    - ```
      sudo apt remove yt-dlp
      ```
  - Download yt-dlp from:
    - https://github.com/yt-dlp/yt-dlp/releases
  - Rename the downloaded binary to `yt-dlp`
  - Place `yt-dlp` in your `/usr/local/bin` directory:
    ```
    sudo cp /<YOUR PATH TO>/yt-dlp /usr/local/bin/yt-dlp
    ```
    ```
    sudo chmod +x /usr/local/bin/yt-dlp
    ```

- Install FFmpeg:
  ```
  sudo apt install ffmpeg
  ```

You can verify you installed everything correctly by running `yt-dlp` and `ffmpeg` in the terminal.

`MediaDownloader_linux` should now work!

</details>

---

## 🔨 How do I build it?

By following these steps:
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

## 📖 FAQ

<details>
<summary><strong>View</strong></summary>

### How do I use the custom arguments option?
- Every argument should be separated by a newline (`\n`) \
  *Examples:*
    ```
    -x
    --audio-format
    mp3
    ```

    ```
    -b:v
    10M
    -b:a
    320K
    ```

### How do I specify trim values?
- Trim values should be in the format of a timestamp \
  *Examples:*
  - `0:00` and `0:10`
  - `1:00` and `1:30`
  - `10` and `15`
  - `52:32` and `1:20:21`
  
### How do I specify bitrate values?
- Bitrate values should be a number, followed by a byte abbreviation \
  *Examples:*
  - `1G` (for gigabits)
  - `10M` (for megabits)
  - `320k` (for kilobits)

</details>

---

## ❗ Help me

If you have an issue or question:
- You can contact me on Discord (*my username is **o7q***)
- You can create an issue on the [issues page](https://github.com/o7q/MediaDownloader/issues).

---

Built with [**Tauri**](https://tauri.app)
