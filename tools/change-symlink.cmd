@echo off
echo Formatting HDFS
echo ===============
cd %~dp0%
cd ..
set BIGSMASH_HOME=%cd%
echo %BIGSMASH_HOME%
set JAVA_HOME=%BIGSMASH_HOME%\jdk1.7.0_67
set HADOOP_HOME=%BIGSMASH_HOME%\hadoop-2.5.0
set HADOOP_CONF_DIR=%HADOOP_HOME%\etc\hadoop
rmdir %HADOOP_HOME%\etc\hadoop
mklink /D %HADOOP_HOME%\etc\hadoop %HADOOP_HOME%\etc\hadoop_Standalone
echo Symlink to Standalone mode.
