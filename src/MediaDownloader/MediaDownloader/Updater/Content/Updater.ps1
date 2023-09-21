# MediaDownloader Updater v1.0.0

function Remove-File
{
    param([string]$File)

    if (Test-Path -Path $File -PathType Leaf)
    {
        Remove-Item -Path $File -Force
    }
}

# find and close mediadownloader
$process = Get-Process -Name "MediaDownloader" -ErrorAction SilentlyContinue
if ($process)
{
    # wait for exit
    Write-Output "Waiting for MediaDownloader to exit..."
    $process.WaitForExit()
    
    Clear-Host
}

# delete mediadownloader after exit
Write-Output "Removing `"MediaDownloader`""
Remove-File -File "MediaDownloader.exe"

# download mediadownloader
Write-Output "Downloading `"MediaDownloader`""
Invoke-WebRequest -Uri "https://github.com/o7q/MediaDownloader/releases/latest/download/MediaDownloader.exe" -OutFile "MediaDownloader.exe"

Start-Process -FilePath "MediaDownloader.exe"