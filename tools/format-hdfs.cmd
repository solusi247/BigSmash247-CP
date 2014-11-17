@echo off
echo %~dp0%
cd %~dp0%
cd ..
set BIGSMASH_HOME=%cd%
echo %BIGSMASH_HOME%
rmdir /s /q %BIGSMASH_HOME%\hdfs
mkdir %BIGSMASH_HOME%\hdfs\namenode
mkdir %BIGSMASH_HOME%\hdfs\datanode
set JAVA_HOME=%BIGSMASH_HOME%\jdk1.7.0_67
set HADOOP_HOME=%BIGSMASH_HOME%\hadoop-2.5.0
mklink /D %HADOOP_HOME%\etc\hadoop %HADOOP_HOME%\etc\hadoop_Pseudo
set var1=%BIGSMASH_HOME:\=/%
powershell -Command "(Get-Content %HADOOP_HOME%\etc\hadoop\hdfs-site.xml.template) | ForEach-Object { $_ -replace 'BIGSMASH_HOME', '%var1%' } | Set-Content %HADOOP_HOME%\etc\hadoop\hdfs-site.xml"
set HADOOP_CONF_DIR=%HADOOP_HOME%\etc\hadoop
%HADOOP_HOME%\bin\hdfs.cmd namenode -format