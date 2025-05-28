use std::process::Command;

pub fn start_process(process_path: &str, arguments: &[&str]) {
    let mut output = Command::new(process_path);

    for arg in arguments {
        output.arg(arg);
    }

    output.output().expect("Failed to execute process");
}
