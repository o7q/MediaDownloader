use std::io::{BufRead, BufReader};
use std::process::{Command, Stdio};
use std::thread;

pub fn start_process(process_path: &str, arguments: &[String]) -> std::io::Result<()> {
    println!("PROCESS ARGS:");
    for arg in arguments {
        println!("{}", arg);
    }

    let mut child = Command::new(process_path)
        .args(arguments)
        .stdout(Stdio::piped())
        .stderr(Stdio::piped())
        .spawn()?;

    // clone stdout and stderr handles
    let stdout = child.stdout.take().expect("Failed to capture stdout");
    let stderr = child.stderr.take().expect("Failed to capture stderr");

    // thread: handle stdout
    let stdout_thread = thread::spawn(move || {
        let reader = BufReader::new(stdout);
        for line in reader.lines() {
            match line {
                Ok(line) => println!("{}", line),
                Err(e) => eprintln!("Error reading stdout: {}", e),
            }
        }
    });

    // thread: handle stderr
    let stderr_thread = thread::spawn(move || {
        let reader = BufReader::new(stderr);
        for line in reader.lines() {
            match line {
                Ok(line) => eprintln!("{}", line),
                Err(e) => eprintln!("Error reading stderr: {}", e),
            }
        }
    });

    // wait for child and output threads
    let status = child.wait()?;
    stdout_thread.join().expect("Failed to join stdout thread");
    stderr_thread.join().expect("Failed to join stderr thread");

    println!("Process exited with: {}", status);

    Ok(())
}
