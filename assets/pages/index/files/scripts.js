function bodyInit()
{
    dlConfig();
}

function dlConfig()
{
    var ver = "v3.7.0";

    document.getElementById("dlID").href = "https://github.com/o7q/MediaDownloader/releases/download/" + ver + "/MediaDownloader." + ver + ".zip";
    document.getElementById("dlID").innerHTML = "Download " + ver;
}