export function isUrlPlaylist(url: String) {
    const playlistKeywords = ["/playlist?", "&list=", "?list=", "/sets"];
    for (const keyword of playlistKeywords) {
        if (url.includes(keyword)) {
            return true;
        }
    }
    return false;
}