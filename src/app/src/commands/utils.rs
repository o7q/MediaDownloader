use crate::utils::{
    directory::{directory_exists, get_parent_directory},
    file::{file_exists, normalize_path, read_file},
};

use std::process::Command;

#[derive(Debug)]
struct NavigateOptions {
    path: String,
    navigate_into: bool,
}

#[tauri::command]
pub fn util_open_path_location(mut path: &str) {
    let download_location = match read_file("MediaDownloader/_temp/last_output_path.txt") {
        Ok(contents) => contents,
        Err(_) => "".to_string(),
    };

    if path.is_empty() {
        path = "Downloads";
    }

    let navigate_options: NavigateOptions =
        if get_parent_directory(&download_location) == normalize_path(path) {
            if file_exists(&download_location) {
                NavigateOptions {
                    path: download_location.clone(),
                    navigate_into: false,
                }
            } else if directory_exists(&download_location) {
                NavigateOptions {
                    path: download_location.clone(),
                    navigate_into: true,
                }
            } else {
                NavigateOptions {
                    path: normalize_path(path),
                    navigate_into: true,
                }
            }
        } else {
            NavigateOptions {
                path: normalize_path(path),
                navigate_into: true,
            }
        };

    navigate_to(&navigate_options);
}

#[cfg(target_os = "windows")]
fn navigate_to(navigate_options: &NavigateOptions) {
    use crate::utils::file::normalize_path_windows;

    let path: String = normalize_path_windows(&navigate_options.path.clone());

    let _ = if navigate_options.navigate_into {
        Command::new("explorer").arg(path).status()
    } else {
        Command::new("explorer").arg("/select,").arg(path).status()
    };
}

#[cfg(target_os = "linux")]
fn navigate_to(navigate_options: &NavigateOptions) {

}
