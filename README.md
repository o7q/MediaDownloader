<img src="assets/images/banner.png">

# [<b>>> Download Latest</b>](https://github.com/o7q/MediaDownloader/releases/download/v3.8.3.0/MediaDownloader.v3.8.3.0.zip)
### Welcome! MediaDownloader is a simple, lightning-fast, GUI based tool that removes the hassle of using yt-dlp through a command-line.

---

<img src="assets/images/program.png">

---

# Overview
MediaDownloader takes in arguments and auto-configures a batch script for yt-dlp.\
FFmpeg is then used for further media processing if specified to do so.

### **Powered by**
yt-dlp: https://github.com/yt-dlp/yt-dlp \
FFmpeg: https://ffmpeg.org

---

# Usage

## **Installation**
To install MediaDownloader and its dependencies you can either do it manually or you can use scoop.

- **Normal Installation** \
**1.** Go to https://o7q.github.io/MediaDownloader \
**2.** Click `Download <version>`

- **Scoop Installation**

**1.** Open `cmd.exe` and run this command:
```powershell
powershell -noe "iex(irm tl.ctt.cx);Get utils/mediadownloader"
```
**2.** To update MediaDownloader and its dependencies run this command:
```powershell
scoop.cmd update *
```

<br>

## **Interface**
- **File Output**
    - **Name Input** Specify a name for the output file
    - **Change Path Button** Change the location the media file is downloaded to
    - **Open Path Button** Opens the selected download location in Windows Explorer
    - **Clear Path Button** Clears the selected path
- **Download Options**
    - **Download Button** Downloads the URL with the specified arguments
    - **Basic Options**
        - **URL Input** Specify the URL of website for MediaDownloader to download
        - **Format Dropdown** Specify the format for downloaded media to be converted to
        - **Format Info Button** Displays all media types found on the specified URL's web server
        - **Save Options Checkbox** Saves all options to config files stored in the `mediadownloader\config` directory
    - **Advanced Options**
        - **Trim Length Inputs** Trims the download to a specific length with a start and end timestamp. Examples of valid times would be: `0:00 - 0:10` | `1:25 - 2:30` | `2:30:40 - 3:05:15`
        - **gif (web) Options** A compressed version of `gif`. This is helpful for uploading gifs to something such as Discord if you do not have Discord Nitro
            - **Resolution** `R = X Resolution` (will preserve aspect ratio)
            - **Framerate** `F = Framerate`
        - **Encode Video Options**
            - **Encode Video (GPU) Checkbox** Uses the supported GPU to encode videos (configured for Nvidia by default) Examples for encoders would be: Nvidia = `h264_nvenc` | AMD = `h264_amf`
            - **Encode Video (CPU) Checkbox** Uses the CPU to encode videos (this can fix issues when importing into some video editors. **warning:** this option can be very slow depending on your hardware)
        - **yt-dlp Arguments Input** Specify arguments to send to yt-dlp (double-click on the textbox to open the yt-dlp GitHub repository page)
        - **Log Output Options** Controls how MediaDownloader displays the download process
            - **Display Checkbox** Displays the ongoing download log
            - **Keep Checkbox** Keeps the log open even after MediaDownloader finishes downloading

<br>

## **Formats**
- **Video**
    - **mp4** Downloads in the mp4 video format. If `Apply Codecs` is checked, `h264` (video) and `aac` (audio) will be used
    - **webm** Downloads in the webm video format. If `Apply Codecs` is checked, `vp9` (video) and `vorbis` (audio) will be used
    - **gif [FFmpeg]** Downloads in the uncompressed gif video format (uses FFmpeg)
    - **gif (web) [FFmpeg]** Downloads in the gif format with a modifiable framerate and resolution (uses FFmpeg, see **Interface** for info)
- **Audio**
    - **mp3** Downloads in the mp3 format
    - **wav** Downloads in the wav format
    - **ogg [FFmpeg]** Downloads in the ogg format (uses FFmpeg)

---

**MediaDownloader** \
Written in C# with .NET Framework 4.8