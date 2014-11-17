@echo off
rem Solusi 247
rem 2014
rem Taken from
rem http://waynes-world-it.blogspot.com/2008/07/process-list-with-command-line.html
set DAEMON_NAME=%1
wmic path win32_process Where "CommandLine Like '%%%DAEMON_NAME%%%'" get CommandLine,ProcessId | find "%DAEMON_NAME%" | find "java" > %TEMP%\pid1.txt
rem echo %ERRORLEVEL%

rem org.apache.zookeeper.server.quorum.QuorumPeerMain
rem backtype.storm.daemon.nimbus
rem backtype.storm.daemon.supervisor
rem backtype.storm.ui.core

if "%ERRORLEVEL%"=="0" (
	rem Remove trailing space & empty lines
	rem http://stackoverflow.com/questions/9223460/remove-empty-lines-from-text-file-with-powershell
	powershell -Command "(gc %TEMP%\pid1.txt) | Foreach {$_.TrimEnd()} | where {$_ -ne \"\"} | Set-Content %TEMP%\pid2.txt"

	rem Replace = & " to Z
	rem http://stackoverflow.com/questions/60034/how-can-you-find-and-replace-text-in-a-file-using-the-windows-command-line-envir
	powershell -Command "(Get-Content %TEMP%\pid2.txt) | ForEach-Object { $_ -replace '""', 'Z' } | ForEach-Object { $_ -replace '=', 'Z' } | Set-Content %TEMP%\pid1.txt"

	rem Loop untuk ambil token terakhir
	rem http://stackoverflow.com/questions/280969/windows-batch-loop-over-folder-string-and-parse-out-last-folder-name
	for /f "tokens=*" %%a in (%TEMP%\pid1.txt) do (	
		call :LAST_TOKEN %%a
		)
		goto :EOF
		
	rem Fungsi untuk mendapat token terakhir
	:LAST_TOKEN
	if "%1"=="" (
		@echo %LAST%
		goto :EOF
	)
	set LAST=%1
	SHIFT
	goto :LAST_TOKEN

	rem rm %TEMP%\pid1.txt
)