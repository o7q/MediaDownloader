use std::fs;
use std::io;
use std::path::Path;

pub fn write_file(path: &str, content: &str) -> io::Result<()> {
    println!("Writing file: {}", path);
    fs::write(path, content)
}

pub fn read_file(path: &str) -> io::Result<String> {
    fs::read_to_string(path)
}

pub fn file_exists(path: &str) -> bool {
    Path::new(path).exists()
}

pub fn get_files(path: &str) -> Vec<String> {
    let mut files: Vec<String> = Vec::new();

    match fs::read_dir(path) {
        Ok(entries) => {
            for entry in entries {
                match entry {
                    Ok(entry) => files.push(entry.path().to_string_lossy().to_string()),
                    Err(err) => eprintln!("Error: {}", err),
                }
            }
        }
        Err(err) => eprintln!("Error: {}", err),
    }

    files
}

pub fn get_filename(path: &str, extension: bool) -> String {
    let path: &Path = Path::new(path);

    let filename: Option<&std::ffi::OsStr> = if extension {
        path.file_name()
    } else {
        path.file_stem()
    };

    if let Some(filename) = filename {
        filename.to_string_lossy().to_string()
    } else {
        String::new()
    }
}

#[cfg(windows)]
pub fn normalize_path(s: &str) -> String {
    s.replace("/", "\\")
}

#[cfg(not(windows))]
pub fn normalize_path(s: &str) -> String {
    s.to_string()
}
