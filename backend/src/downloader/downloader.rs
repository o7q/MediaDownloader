pub trait Downloader {
    fn new() -> Self;
    fn set_url(&mut self, url: &str);
    fn set_name(&mut self, name: &str);
    fn get_name(&self) -> String;
    fn download(&self);

    fn determine_output_name(&self) -> String {
        if self.get_name().is_empty() {
            String::from("%(title)s")
        } else {
            String::from(self.get_name())
        }
    }
}
