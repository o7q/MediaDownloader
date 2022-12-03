@echo off
set name=MediaConverter
title Cleaning %name%
color 7
del "%name%.exe" /f 2> nul
rmdir "mediaconverter" /s /q 2> nul
title DONE!
echo.