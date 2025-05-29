pub trait Downloader {
    fn new() -> Self;

    fn set_url(&mut self, url: &str);
    fn set_name(&mut self, name: &str);
    fn set_custom_arguments(&mut self, custom_arguments: &str);

    fn get_name(&self) -> String;

    fn download(&self);

    fn determine_output_name(&self) -> String {
        if self.get_name().is_empty() {
            String::from("%(title)s")
        } else {
            String::from(self.get_name())
        }
    }

    fn decode_raw_arguments(&mut self, raw_custom_arguments: &str) -> Vec<String> {
        if !raw_custom_arguments.is_empty() {
            raw_custom_arguments.split('\n').map(String::from).collect()
        } else {
            Vec::new()
        }
    }
}
