use std::env;

use crate::updater::{meta::generate_update_metadata, updater::Updater};

#[derive(Debug)]
struct Argument {
    key: String,
    data: String,
}

pub fn handle_arguments() {
    let is_key = |input: &str| input.chars().take(2).collect::<String>() == "--";

    let input_args: Vec<String> = env::args().collect::<Vec<String>>();

    let mut i: usize = 0;
    while i < input_args.len() {
        let mut increment: usize = 1;

        if is_key(&input_args[i]) {
            let argument_pair: Argument = Argument {
                key: input_args[i].chars().skip(2).collect::<String>(),
                data: if i + 1 < input_args.len() {
                    if !is_key(&input_args[i + 1]) {
                        increment = 2;
                        input_args[i + 1].clone()
                    } else {
                        "".to_string()
                    }
                } else {
                    "".to_string()
                },
            };

            execute_argument(&argument_pair);
        }

        i += increment;
    }
}

fn execute_argument(argument: &Argument) {
    match argument.key.as_str() {
        "update" => {
            Updater::new().update();
        }
        "update-generate-metadata" => {
            generate_update_metadata();
        }
        "update-stage-download" => {
            Updater::new().stage_download(match argument.data.parse::<u32>() {
                Ok(num) => num,
                Err(_) => 0,
            });
        }
        "update-stage-finalize" => {
            Updater::new().stage_finalize(match argument.data.parse::<u32>() {
                Ok(num) => num,
                Err(_) => 0,
            });
        }
        _ => {}
    }
}
