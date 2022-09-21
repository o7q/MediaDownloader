function init()
{
    dlConfig();
}

function dlConfig()
{
    var ver = "v3.5.1";

    document.getElementById("dlID").href ="https://github.com/o7q/MediaDownloader/releases/download/" + ver + "/MediaDownloader." + ver + ".redists.included.7z";
    document.getElementById("dlID").innerHTML = "Download " + ver;
}