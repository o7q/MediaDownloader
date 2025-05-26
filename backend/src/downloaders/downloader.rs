pub trait Downloader {
    fn new() -> Self;
    fn set_url(&mut self, url: &str);
    fn download(&self);
}
