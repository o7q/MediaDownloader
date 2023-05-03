<img src="assets/images/banner.png">

# [<b>>> Download Latest</b>](https://github.com/o7q/MediaDownloader/releases/download/v3.10.0.0/MediaDownloader.v3.10.0.0.zip)
### Welcome! MediaDownloader is a simple, lightning-fast, GUI based tool that removes the hassle of using yt-dlp through a command-line.

---

<img src="assets/images/program.png">

---

# Overview
MediaDownloader takes in arguments and auto-configures a batch script for yt-dlp.\
FFmpeg is then used for further media processing if needed.

### **Powered by**
yt-dlp: https://github.com/yt-dlp/yt-dlp \
FFmpeg: https://ffmpeg.org

---

<!-- # Usage

## **Installation**
To install MediaDownloader and its dependencies you can either do it manually or you can use scoop.

- **Normal Installation** \
**1.** Go to https://o7q.github.io/MediaDownloader \
**2.** Click `Download <version>`

- **Scoop Installation (currently outdated)**

**1.** Open `cmd.exe` and run this command:
```powershell
powershell -noe "iex(irm tl.ctt.cx);Get utils/mediadownloader"
```
**2.** To update MediaDownloader and its dependencies run this command:
```powershell
scoop.cmd update *
```

<br> -->

## **Interface**

<details>
<summary><b>File Output</b></summary>

- **Name Input** Specify a name for the output file
- **Change Path Button** Change the location the media file is downloaded to
- **Open Path Button** Opens the selected download location in Windows Explorer
- **Clear Path Button** Clears the selected path

</details>

<details>
<summary><b>Download Options</b></summary>

- **Download Button** Downloads the URL with the specified arguments
- **Basic Options**
- **URL Input** Specify the URL of website for MediaDownloader to download
- **Format Dropdown** Specify the format for downloaded media to be converted to
- **Format Info Button** Displays all media types found on the specified URL's web server
- **Trim Length Inputs** Trims the download to a specific length with a start and end timestamp. Examples of valid times would be: `0:00 - 0:10` | `1:25 - 2:30` | `2:30:40 - 3:05:15`
- **Save Options Checkbox** Saves all options to config files stored in the `mediadownloader\config` directory

</details>

<details>
<summary><b>Advanced Download Options</b></summary>

- **Encoder Bitrate Options** Bitrate settings for the encoder - (affects downloads only when ffmpeg is used in the process! - for example, when using either timeframe, CPU, or GPU options, these bitrate settings will apply)
    - **Video Bitrate** Bitrate for video - Examples: "100M" | "900K" (M = MB/s, K = KB/s)
    - **Audio Bitrate** Bitrate for audio - Examples: "320K" | "10K" (M = MB/s, K = KB/s)
- **gif Options**
    - **Resolution** `R = X Resolution` (will preserve aspect ratio)
    - **Framerate** `F = Framerate`
- **Encode Video Options**
    - **Encode Video (GPU) Checkbox** Uses the supported GPU to encode videos (configured for Nvidia by default) Examples for encoders would be: Nvidia = `h264_nvenc` | AMD = `h264_amf`
    - **Encode Video (CPU) Checkbox** Uses the CPU to encode videos (this can fix issues when importing into some video editors. **warning:** this option can be very slow depending on your hardware)
- **yt-dlp Arguments Input** Specify arguments to send to yt-dlp (double-click on the textbox to open the yt-dlp GitHub repository page)
    - **Log Output Options** Controls how MediaDownloader displays the download process
        - **Display Checkbox** Displays the ongoing download log
        - **Keep Checkbox** Keeps the log open even after MediaDownloader finishes downloading

</details>

<br>

## **Formats**

<details>
<summary><b>Video</b></summary>

- **mp4**
- **mkv**
- **webm**

</details>

<details>
<summary><b>Audio</b></summary>

- **mp3**
- **wav**
- **ogg**
- **flac**
- **opus**

</details>

<details>
<summary><b>Image</b></summary>

- **gif**
- **png sequence**
- **jpg sequence**

</details>

<details>
<summary><b>Audio Visualizers</b></summary>

- **vectorscope**
- **spectogram**
- **histogram**
- **showcqt**
- **showfreqs**
- **waves**

</details>

---

**MediaDownloader** \
Written in C# with .NET Framework 4.8