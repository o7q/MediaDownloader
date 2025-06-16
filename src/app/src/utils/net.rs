use futures_util::StreamExt;
use reqwest::Error;
use tokio::fs::File;
use tokio::io::AsyncWriteExt;

pub async fn download_file_async(url: &str, path: &str) -> Result<(), Box<dyn std::error::Error>> {
    let mut file: File = File::create(path).await?;
    println!("Downloading: \"{}\"", url);

    let response: reqwest::Response = reqwest::get(url).await?;
    let mut stream = response.bytes_stream();

    while let Some(chunk_result) = stream.next().await {
        let chunk = chunk_result?;
        file.write_all(&chunk).await?;
    }

    file.flush().await?;

    Ok(())
}

pub async fn download_text_async(url: &str) -> Result<String, Error> {
    let response: reqwest::Response = reqwest::get(url).await?;
    let body: String = response.text().await?;
    Ok(body)
}

pub fn launch_url(url: &str) {
    if webbrowser::open(url).is_ok() {}
}
