@echo off
rmdir ".vs" /s /q 2> nul
rmdir "MediaDownloader\.vs" /s /q 2> nul
rmdir "MediaDownloader\bin" /s /q 2> nul
rmdir "MediaDownloader\obj" /s /q 2> nul
rmdir "MediaDownloader\Build" /s /q 2> nul
mkdir "MediaDownloader\Build/MediaDownloader" 2> nul