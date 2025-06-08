use crate::utils::{directory::create_directory, file::file_exists, net::download_file};

use std::io::{copy, BufWriter};
use std::{fs::File, io::BufReader};
use zip::ZipArchive;

#[cfg(target_os = "windows")]
pub fn bootstrap_ffmpeg() {
    if file_exists("MediaDownloader/bin/ffmpeg.exe") {
        return;
    }

    let _ = create_directory("MediaDownloader/bin");

    let _ = create_directory("MediaDownloader/_temp");
    let _ = download_file(
        "https://github.com/BtbN/FFmpeg-Builds/releases/download/latest/ffmpeg-master-latest-win64-gpl.zip",
        "MediaDownloader/_temp/ffmpeg.zip",
    );

    let _ = extract_ffmpeg();
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
pub fn bootstrap_ffmpeg() {}
