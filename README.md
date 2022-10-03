<img src="assets/images/readmebanner.png">

# [<b>>> Download Latest</b>](https://github.com/o7q/MediaDownloader/releases/download/v3.5.2/MediaDownloader.v3.5.2.redists.included.7z)
<h3>Welcome! MediaDownloader is a simple, lightning-fast, GUI-based tool that removes the hassle of using yt-dlp through a command-line.</h3>

---

<img src="assets/images/program.png"/>

---

# Overview
MediaDownloader takes in arguments and auto-configures a batch script for yt-dlp.\
FFmpeg is then used for farther media processing if specified to do so.

### Powered by:
yt-dlp: https://github.com/yt-dlp/yt-dlp \
ffmpeg: https://ffmpeg.org

---

# Usage

## <b>Components</b>
<b>URL Input</b> Specify the URL of website for MediaDownloader to download \
<b>Format Dropdown</b> Specify the format for downloaded media to be converted to \
<b>Download Button</b> Downloads the URL with the specified arguments \
<b>Change Path Button</b> Change the location the media file is downloaded to \
<b>Open Path Button</b> Opens the selected download location in Windows Explorer \
<b>Clear Path Button</b> Clears the selected path \
<b>View Raw Formats Button</b> Displays all media types found on the specified URL's web server \
<b>MediaD GitHub Button</b> Opens this MediaDownloader GitHub page \
<b>yt-dlp GitHub Button</b> Opens the `yt-dlp` GitHub page (you can use this to find arguments used in the `Custom DL Arguments` section \
<b>Info Button</b> Shows info about MediaDownloader \
<b>Apply Video Codecs Checkbox</b> Use the CPU to apply codecs to downloaded media files (this can fix issues when importing into some video editors. <b>warning:</b> this option can be very slow depending on your hardware) \
<b>Save Options Checkbox</b> Saves all options to config files stored in the `mediadownloader` directory \
<b>Custom DL Arguments Input</b> Specify custom arguments that `yt-dlp` will accept \
<b>gif (web) Quality Inputs</b> `R = X Resolution` (will preserve aspect ratio) & `F = Framerate` (this is helpful for uploading gifs to something such as Discord if you do not have Discord Nitro)\
<b>GPU Acceleration Inputs</b> Use the supported GPU to encode videos (configured for Nvidia by default) Examples for encoders would be: Nvidia = `h264_nvenc` | AMD = `h264_amf`

## <b>Formats</b>
### <b>[Video]</b>
<b>(raw video)</b> Downloads in the raw video format. Does not apply any codecs\
<b>mp4</b> Downloads in the mp4 video format. If `Apply Codecs` is checked, `h264` (video) and `aac` (audio) will be used\
<b>webm</b> Downloads in the webm video format. If `Apply Codecs` is checked, `vp9` (video) and `vorbis` (audio) will be used\
<b>gif [ffmpeg]</b> Downloads in the uncompressed gif video format (uses ffmpeg)\
<b>gif (web) [ffmpeg]</b> Downloads in the gif format with a modifiable framerate and resolution (uses ffmpeg, see <b>Components</b> for info)

### <b>[Audio]</b>
<b>(raw audio)</b> Downloads in the raw audio format. Does not apply any codecs\
<b>mp3</b> Downloads in the mp3 format\
<b>wav</b> Downloads in the wav format\
<b>ogg [ffmpeg]</b> Downloads in the ogg format (uses ffmpeg)

### <b>[Custom]</b>
<b>(Custom DL Arguments)</b> Downloads using the specified download arguments

---

<i>Programmed with C# and .NET Framework 4.8.</i> \
<i>If you want to compile the code yourself I highly recommend using Visual Studio.</i>