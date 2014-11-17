@echo off
REM Taken from
rem http://www.windows-commandline.com/find-windows-os-version-from-command/
wmic os get Caption /value | find "Windows 7"
echo %ERRORLEVEL%