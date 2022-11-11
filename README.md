<img src="assets/images/banner.png">

# [<b>>> Download Latest</b>](https://github.com/o7q/MediaDownloader/releases/download/v3.7.0/MediaDownloader.v3.7.0.7z)
<h3>Welcome! MediaDownloader is a simple, lightning-fast, GUI-based tool that removes the hassle of using yt-dlp through a command-line.</h3>

---

<img src="assets/images/program.png"/>

---

# Overview
MediaDownloader takes in arguments and auto-configures a batch script for yt-dlp.\
FFmpeg is then used for further media processing if specified to do so.

### Powered by:
yt-dlp: https://github.com/yt-dlp/yt-dlp \
FFmpeg: https://ffmpeg.org

---

# Usage

## <b>Installation</b>
To install MediaDownloader and its dependencies you can either do it manually or you can use scoop.

<b>Manual Installation</b> \
<b>1.</b> Go to https://o7q.github.io/MediaDownloader \
<b>2.</b> Click `Download <version>`

<br>

<b>Scoop Installation</b> \
<b>1.</b> Open `cmd.exe` and run this command:
```powershell
powershell -noe "iex(irm tl.ctt.cx);Get utils/mediadownloader"
```
<b>2.</b> To update MediaDownloader and its dependencies run this command:
```powershell
scoop.cmd update *
```

## <b>Components</b>
<b>URL Input</b> Specify the URL of website for MediaDownloader to download \
<b>Format Dropdown</b> Specify the format for downloaded media to be converted to \
<b>Format Info Button</b> Displays all media types found on the specified URL's web server \
<b>Download Button</b> Downloads the URL with the specified arguments \
<b>Change Path Button</b> Change the location the media file is downloaded to \
<b>Open Path Button</b> Opens the selected download location in Windows Explorer \
<b>Clear Path Button</b> Clears the selected path \
<b>Trim Length Inputs</b> Trims the download to a specific length with a start and end timestamp. Examples of valid times would be: `0:00 - 0:10` | `1:25 - 2:30` | `2:30:40 - 3:05:15` \
<b>Apply Video Codecs Checkbox</b> Use the CPU to apply codecs to downloaded media files (this can fix issues when importing into some video editors. <b>warning:</b> this option can be very slow depending on your hardware) \
<b>Save Options Checkbox</b> Saves all options to config files stored in the `mediadownloader` directory \
<b>yt-dlp Arguments Input</b> Specify arguments to send to yt-dlp (double-click on the textbox to open the yt-dlp GitHub repository page) \
<b>gif (web) Options</b> `R = X Resolution` (will preserve aspect ratio) & `F = Framerate` (this is helpful for uploading gifs to something such as Discord if you do not have Discord Nitro) \
<b>GPU Acceleration Inputs</b> Use the supported GPU to encode videos (configured for Nvidia by default) Examples for encoders would be: Nvidia = `h264_nvenc` | AMD = `h264_amf`

## <b>Formats</b>
### <b>Video</b>
<b>mp4</b> Downloads in the mp4 video format. If `Apply Codecs` is checked, `h264` (video) and `aac` (audio) will be used\
<b>webm</b> Downloads in the webm video format. If `Apply Codecs` is checked, `vp9` (video) and `vorbis` (audio) will be used\
<b>gif [FFmpeg]</b> Downloads in the uncompressed gif video format (uses FFmpeg) \
<b>gif (web) [FFmpeg]</b> Downloads in the gif format with a modifiable framerate and resolution (uses FFmpeg, see <b>Components</b> for info)

### <b>Audio</b>
<b>mp3</b> Downloads in the mp3 format\
<b>wav</b> Downloads in the wav format\
<b>ogg [FFmpeg]</b> Downloads in the ogg format (uses FFmpeg)

---

<i>Programmed with C# and .NET Framework 4.8</i> \
<i>* If you want to compile the code yourself I highly recommend using Visual Studio</i>