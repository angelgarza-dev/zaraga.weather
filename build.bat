@echo off
REM call "C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\Common7\Tools\VsDevCmd.bat"
REM call "C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\Common7\Tools\VsMSBuildCmd.bat"
call "C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\Tools\VsMSBuildCmd.bat"
set ROOT=%~p0
cd %ROOT%

echo(
@REM region US
@REM set today=%date:~10,4%-%date:~4,2%-%date:~7,2% %time:~0,2%:%time:~3,2%
@REM set versionOfDay=%date:~12,4%%date:~4,2%%date:~7,2%

@REM region MX
set today=%date:~6,4%-%date:~3,2%-%date:~0,2% %time:~0,2%:%time:~3,2%
set versionOfDay=%date:~8,2%%date:~3,2%%date:~0,2%

echo Current Date: %today%
echo Version to Generate: %versionOfDay%

echo(
echo ======================================================================
echo  Working directory is %ROOT%
echo ======================================================================

echo(
echo ======================================================================
echo  Clean up before compiling
echo ======================================================================
dotnet restore zaraga.weather.sln --verbosity:minimal

echo(
echo ======================================================================
echo  Deleting build folders
echo ======================================================================
rmdir zaraga.weather\bin /s /q
rmdir zaraga.weather\obj /s /q

echo(
echo ======================================================================
echo  Folders Deleted
echo ======================================================================

echo(
echo ======================================================================
echo  Restore nuget packages
echo ======================================================================
REM verbosity can be: Quiet | Normal | Minimal | Diagnostic | Detailed
set BUILD_OPTS=--verbosity:Normal
msbuild zaraga.weather.sln -t:restore %BUILD_OPTS%

echo(
echo ======================================================================
echo  Signing options.  Use Keystore from sources, not from local PC
echo ======================================================================
set SIGN=-p:AndroidKeyStore="true" -p:AndroidSigningKeyStore="%ROOT%\Keystore\upload.jks" -p:AndroidSigningKeyAlias="upload" -p:AndroidSigningKeyPass="123qwe" -p:AndroidSigningStorePass="123qwe"
REM verbosity can be: Quiet | Normal | Minimal | Diagnostic | Detailed
set BUILD_OPTS=--verbosity:Normal
set VERSION_OPS=-p:ApplicationDisplayVersion=1.0.0.0 -p:ApplicationVersion=%versionOfDay%  -p:WeatherApiKey="7d848ee5e8d34b84bf1211825250205"

dotnet publish zaraga.weather.sln -f net8.0-android -c Release %SIGN% %SDK% %BUILD_OPTS% %VERSION_OPS%

SET COMPILATION_ERRORLEVEL=%ERRORLEVEL%

echo ======================================================================
echo  Show compilation results and return release build errorlevel
echo ======================================================================
dir %ROOT%\zaraga.weather\bin\Release\net8.0-android
cd %ROOT%\zaraga.weather\bin\Release\net8.0-android
start.
cd %ROOT%
@REM dir %ROOT%\ceqmovil.Android\bin\Debug\mx.aph.ceqmovil-Signed.apk
@REM dir %ROOT%\ceqmovil\ceqmovil.Android\bin\Release\mx.aph.ceqmovil-Signed.apk
exit /b %COMPILATION_ERRORLEVEL%
:end



