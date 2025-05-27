use std::process::Command;

pub fn start_process(process_path: &str, arguments: &[&str]) {
    let mut output = Command::new(process_path);

    for arg in arguments {
        output.arg(arg);
    }

    output.output().expect("Failed to execute process");

    // if output.status.success() {
    //     let stdout: std::borrow::Cow<'_, str> = String::from_utf8_lossy(&output.stdout);
    //     println!("Program output:\n{}", stdout);
    // } else {
    //     let stderr: std::borrow::Cow<'_, str> = String::from_utf8_lossy(&output.stderr);
    //     eprintln!("Program error:\n{}", stderr);
    // }
}
