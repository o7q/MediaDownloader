function Test-File
{
    param([string]$File)

    $Result = $false

    if (Test-Path -Path $File -PathType Leaf)
    {
        $Result = $true
    }

    return $Result
}

function Remove-File
{
    param([string]$File)

    if (Test-File -File $File)
    {
        Remove-Item -Path $File -Force
    }
}

$PATH = "MediaDownloader.exe"
if ((Test-File -File "..\..\MediaDownloader.exe") -and -not (Test-File -File "MediaDownloader.exe"))
{
    $PATH = "..\..\MediaDownloader.exe"
}
Write-Output "Found: `"$PATH`"`n"

# find and close mediadownloader
$Process = Get-Process -Name "MediaDownloader" -ErrorAction SilentlyContinue
if ($Process)
{
    # wait for exit
    Write-Output "Waiting for MediaDownloader to exit..."
    $Process.WaitForExit()
    
    Clear-Host
}

# delete mediadownloader after exit
Write-Output "Removing `"$PATH`""
Remove-File -File $PATH

# download mediadownloader
Write-Output "Downloading `"$PATH`""
Invoke-WebRequest -Uri "https://github.com/o7q/MediaDownloader/releases/latest/download/MediaDownloader.exe" -OutFile $PATH

Start-Process -FilePath $PATH