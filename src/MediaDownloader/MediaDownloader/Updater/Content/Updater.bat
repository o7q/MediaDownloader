:: MediaDownloader Updater

@echo off
set VERSION=v1.1.0
title MediaDownloader Updater %VERSION%
color 0A
powershell.exe -ExecutionPolicy Bypass -File "update.ps1"
pause