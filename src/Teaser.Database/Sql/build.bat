@echo off
REM *****************************************
REM       usage: go to command line and type   'build'
REM	      for a specific target use 'build target'
REM       example   'build Zip'
REM
REM		  old code REM msbuild Content.build /t:%*
REM *****************************************
cls

echo -----------------------------
REM set msBuildCommand=C:\WINDOWS\Microsoft.NET\Framework\v3.5\msbuild example-msbuild.proj
set msBuildCommand=C:\WINDOWS\Microsoft.NET\Framework\v3.5\msbuild migrate.proj

if "%1"=="" GOTO runDefault
	echo about to run with target ='%1'
	echo -----------------------------
	%msBuildCommand%  /t:%1
GOTO end

:runDefault
	echo inside runDefault target ='%1'
	echo -----------------------------
	%msBuildCommand% 
GOTO end

:end 
