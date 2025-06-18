use std::io::{copy, BufWriter};
use std::{fs::File, io::BufReader};
use zip::ZipArchive;

use crate::logger::logger::IPCLogger;
use crate::utils::{directory::create_directory, file::file_exists, net::download_file_async};

#[cfg(target_os = "windows")]
pub async fn bootstrap_ffmpeg(logger: &IPCLogger) {
    if file_exists("MediaDownloader/bin/ffmpeg.exe") {
        return;
    }

    let _ = create_directory("MediaDownloader/bin");
    let _ = create_directory("MediaDownloader/_temp");

    logger.log("Downloading ffmpeg...");
    let _ = download_file_async(
        "https://github.com/BtbN/FFmpeg-Builds/releases/download/latest/ffmpeg-master-latest-win64-gpl.zip",
        "MediaDownloader/_temp/ffmpeg.zip",
    ).await;
    logger.log("Downloading ffmpeg to \"MediaDownloader/_temp/ffmpeg.zip\"");

    logger.log("Extracting ffmpeg...");
    let _ = extract_ffmpeg();
    logger.log("Extracted ffmpeg to \"MediaDownloader/bin/ffmpeg.exe\"");
}

#[cfg(target_os = "windows")]
fn extract_ffmpeg() -> zip::result::ZipResult<()> {
    let filepath: File = File::open("MediaDownloader/_temp/ffmpeg.zip")?;
    let mut zip: ZipArchive<BufReader<File>> = ZipArchive::new(BufReader::new(filepath))?;

    for i in 0..zip.len() {
        let mut file: zip::read::ZipFile<'_, BufReader<File>> = zip.by_index(i)?;

        let filename = match file.name().rsplit('/').next() {
            Some(value) => value,
            _ => "",
        };

        if filename == "ffmpeg.exe" {
            let mut outfile: BufWriter<File> =
                BufWriter::new(File::create("MediaDownloader/bin/ffmpeg.exe")?);
            copy(&mut file, &mut outfile)?;
        }
    }

    Ok(())
}

#[cfg(target_os = "linux")]
pub async fn bootstrap_ffmpeg(logger: &IPCLogger) {
    const PATH: &str = "MediaDownloader/bin/ffmpeg";
    const ARCHIVE_PATH: &str = "MediaDownloader/_temp/ffmpeg.tar.xz";

    if file_exists(PATH) {
        return;
    }

    let _ = create_directory("MediaDownloader/bin");
    let _ = create_directory("MediaDownloader/_temp");

    logger.log("Downloading ffmpeg...");
    let _ = download_file_async(
        "https://github.com/BtbN/FFmpeg-Builds/releases/download/latest/ffmpeg-master-latest-linux64-lgpl.tar.xz",
        ARCHIVE_PATH,
    ).await;

    logger.log("Extracting ffmpeg...");
    let _ = extract_ffmpeg();
    logger.log(&format!("Extracted ffmpeg to \"{}\"", PATH));
}

#[cfg(target_os = "linux")]
fn extract_ffmpeg() -> std::io::Result<()> {
    use tar::Archive;
    use xz2::read::XzDecoder;

    // const PATH: &str = "MediaDownloader/bin/ffmpeg";
    const ARCHIVE_PATH: &str = "MediaDownloader/_temp/ffmpeg.tar.xz";

    let file = File::open(ARCHIVE_PATH)?;
    let decompressor = XzDecoder::new(BufReader::new(file));
    let mut archive = Archive::new(decompressor);
    archive.unpack("MediaDownloader/_temp/ffmpeg")?;
    Ok(())
}
