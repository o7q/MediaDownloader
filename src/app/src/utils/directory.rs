use std::fs;
use std::io;

pub fn create_directory(path: &str) -> io::Result<()> {
    println!("Creating directory: {}", path);
    fs::create_dir_all(path)
}

pub fn remove_directory(path: &str) -> io::Result<()> {
    println!("Removing directory: {}", path);
    fs::remove_dir_all(path)
}

pub fn directory_exists(path: &str) -> bool {
    fs::metadata(path).is_ok()
}
