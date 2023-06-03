@echo off
rmdir "..\.vs" /s /q 2> nul
rmdir "bin" /s /q 2> nul
rmdir "obj" /s /q 2> nul
rmdir "Build" /s /q 2> nul
mkdir "Build/MediaDownloader" 2> nul