use std::fs;
use std::fs::File;
use std::io;
use std::io::Write;

pub fn create_directory(path: &str) -> io::Result<()> {
    fs::create_dir_all(path)
}

pub fn directory_exists(path: &str) -> bool {
    fs::metadata(path).is_ok()
}

pub fn write_file(path: &str, content: &str) -> io::Result<()> {
    let mut file = File::create(path)?;
    file.write_all(content.as_bytes())?;
    Ok(())
}
