<img src="assets/images/banner.png">

![Total Downloads](https://img.shields.io/github/downloads/o7q/MediaDownloader/total?logo=github&label=Total%20Downloads&color=%232fd653)
![Code Quality](https://img.shields.io/codefactor/grade/github/o7q/MediaDownloader/main?logo=github&label=Code%20Quality&color=%2315bf87)
![Code Size](https://img.shields.io/github/languages/code-size/o7q/MediaDownloader?logo=github&label=Code%20Size&color=%23b65cff)

# [<b>>> Download Latest</b>](https://github.com/o7q/MediaDownloader/releases/latest/download/MediaDownloader.exe)
### Welcome! MediaDownloader is a lightweight, lightning-fast, GUI abstraction for yt-dlp and FFmpeg.

---

<img src="assets/images/program.png">

---

# Overview
MediaDownloader is a GUI-wrapper for yt-dlp that auto-configures command-line scripts based on user settings.\
FFmpeg is then used for further media processing if needed.

### **Powered by**
yt-dlp: https://github.com/yt-dlp/yt-dlp \
FFmpeg: https://ffmpeg.org

---

## **Interface**

</details>

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
    - **Format Options**
        -    **Format Dropdown** Specify the format for downloaded media to be converted to
        - **Format Info Button** Displays all media types found on the specified URL's web server
        - **Trim Length Inputs** Trims the download to a specific length with a start and end timestamp. Examples of valid times would be: `0:00 - 0:10` | `1:25 - 2:30` | `2:30:40 - 3:05:15`
            - **Start and end trimming** You can specify to trim from the start time of the video or until the end time of the video with the checkboxes next to the textboxes

<details>
<summary><b>Extra Download Options</b></summary>

- **Video Change Resolution Options**
    - **Width** Width resolution for video
    - **Height** Height resolution for video
- **Video Change Framerate Options**
    - **Framerate** Framerate for video
- **Bitrate Options** Bitrate settings for the encoder
    - **Video Bitrate** Bitrate for video - Examples: "100M" | "900K" (M = MB/s, K = KB/s)
    - **Audio Bitrate** Bitrate for audio - Examples: "320K" | "10K" (M = MB/s, K = KB/s)
- **yt-dlp Arguments Input** Specify arguments to send to yt-dlp (double-click on the textbox to open the yt-dlp GitHub repository page)
- **FFmpeg Arguments Input** Specify arguments to send to FFmpeg (double-click on the textbox to open the yt-dlp GitHub repository page)

</details>
</details>

<details>
<summary><b>Extra Options</b></summary>

- **Queue**
    - **Queue List** Displays the current items in the queue
    - **Add Button** Creates a new queue item with the specified settings
    - **Remove Button** Removes the selected queue item
    - **Download All Button** Downloads all items in the queue
- **History**
    - **History List** Displays all previously downloaded items
    - **Load Button** Loads the selected item and its settings
    - **Refresh Button** Refreshes the history list
    - **Remove Button** Removes the selected history item
- **Log Output Options** Controls how MediaDownloader displays the download process
    - **Display Checkbox** Displays the ongoing download log
    - **Keep Checkbox** Keeps the log open even after MediaDownloader finishes downloading

</details>

<details>
<summary><b>Settings Menu</b></summary>

- **Sound Settings**
    - **Custom Complete Sound** Play a sound to indicate when a download is finished. Specify you own sound in the textbox, or leave it blank to use the default sound
- **URL Settings**
    - **Enable Trusted URLs** Only allow downloading from specified sites (comma separated)
- **Update Settings** Controls how MediaDownloader displays the download process
    - **Enable Notifications** Displays a notification when there is a new update for MediaDownloader
    - **Check for Updates** Checks if there is a new update for MediaDownloader
    - **Run Bootstrapper** Starts the redist bootstrapper
- **History Settings**
    - **Enable History** Enables the download history
    - **Clear History** Clears all history (this cannot be undone!)
- **Queue Settings**
    - **Clear Queue** Clears the queue (this cannot be undone!)

</details>

---

**MediaDownloader** \
Written in C# with .NET Framework 4.8