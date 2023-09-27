:: MediaDownloader Updater

@echo off
set VERSION=v1.1.0
title MediaDownloader Updater %VERSION%
color 0A

if exist "update.ps1" set SCRIPT_PATH="update.ps1"
if exist "MediaDownloader\updater\update.ps1" set SCRIPT_PATH="MediaDownloader\updater\update.ps1"
powershell.exe -ExecutionPolicy Bypass -File %SCRIPT_PATH%