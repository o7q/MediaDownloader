@echo off
color 7
windres "icon.rc" -O coff -o "icon.res"
echo.
pause