use std::fs;
use std::fs::File;
use std::io;
use std::io::Write;
use std::path::Path;

pub fn create_directory(path: &str) -> io::Result<()> {
    fs::create_dir_all(path)?;
    Ok(())
}

pub fn remove_directory(path: &str) -> io::Result<()> {
    fs::remove_dir_all(path)?;
    Ok(())
}

pub fn directory_exists(path: &str) -> bool {
    fs::metadata(path).is_ok()
}

pub fn write_file(path: &str, content: &str) -> io::Result<()> {
    let mut file: File = File::create(path)?;
    file.write_all(content.as_bytes())?;
    Ok(())
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
