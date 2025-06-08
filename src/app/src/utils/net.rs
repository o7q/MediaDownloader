use std::fs::File;
use std::io::copy;
use std::io::BufWriter;

pub fn download_file(url: &str, path: &str) -> Result<(), Box<dyn std::error::Error>> {
    let response: reqwest::blocking::Response = reqwest::blocking::get(url)?;

    let mut dest: BufWriter<File> = BufWriter::new(File::create(path)?);
    let mut content: reqwest::blocking::Response = response;

    copy(&mut content, &mut dest)?;
    println!(
        "Downloaded file from address: \"{}\", to: \"{}\"",
        url, path
    );
    Ok(())
}
