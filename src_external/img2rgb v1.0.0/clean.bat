@echo off
set name=img2rgb
title Cleaning %name%
color 7
del "%name%.exe" /f 2> nul
del "%name%.spec" /f 2> nul
rmdir "build" /s /q 2> nul
rmdir "dist" /s /q 2> nul
title DONE!
echo.