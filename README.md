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
                <img alt="GitHub Downloads (all assets, all releases)" src="https://img.shields.io/github/downloads/o7q/MediaDownloader/total?label=Downloads&color=23B65C">
                <img src="https://img.shields.io/github/languages/code-size/o7q/MediaDownloader?logo=github&label=Code%20Size&color=%23b65cff">
                <br>
                <strong><a href="https://github.com/o7q/MediaDownloader/releases">Download</a></strong>
            </td>
        </tr>
    </table>
    <img src="docs/images/interface.png" style="width: 400px;">
</div>

---

## ❔ What is it?

A **simple** and **lightweight** GUI wrapper for [yt-dlp](https://github.com/yt-dlp/yt-dlp) and [FFmpeg](https://ffmpeg.org).

It provides a simple abstraction for basic yt-dlp and FFmpeg features while giving full access to each API via custom argument injections, all nicely packaged in a self-contained, cross-platform binary.

---

## 💽 How do I get it?

By grabbing a binary from the 👉 [downloads page](https://github.com/o7q/MediaDownloader/releases).

### 💿 How do I run it?

<details>
<summary><strong>Windows</strong></summary>

Simply run `MediaDownloader.exe`. It will automatically install all dependencies into the `MediaDownloader/bin` directory.

</details>

<details>
<summary><strong>Debian/Ubuntu</strong></summary>

Simply run `MediaDownloader_linux`. It will automatically install all dependencies into the `MediaDownloader/bin` directory.

You may need to run the following command:
```
sudo chmod +x MediaDownloader_linux
```

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
<summary><strong>How do I use the custom arguments option?</strong></summary>

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

</details>

<details>
<summary><strong>How do I specify trim values?</strong></summary>

- Trim values should be in the format of a timestamp \
  *Examples:*
  - `0:00` and `0:10`
  - `1:00` and `1:30`
  - `10` and `15`
  - `52:32` and `1:20:21`
- You can use the `<<` and `>>` options to tell the trimmer to trim from the very start or end

</details>

<details>
<summary><strong>How do I specify bitrate values?</strong></summary>

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
