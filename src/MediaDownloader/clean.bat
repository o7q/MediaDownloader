@echo off
rmdir ".vs" /s /q 2> nul
rmdir "bin" /s /q 2> nul
rmdir "obj" /s /q 2> nul
rmdir "build" /s /q 2> nul
mkdir "build" 2> nul
mkdir "build/MediaDownloader" 2> nul