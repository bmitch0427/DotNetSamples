@echo off
set "projectPath=C:\projects\UltiPro.NET\Assemblies\Foundation\IntegrationStudio\Api.Ultipro.Payroll.Tests\Api.Ultipro.Payroll.Tests.csproj"
set "msbuildPath=C:\Program Files (x86)\MSBuild\14.0\Bin\MSBuild.exe"
set "source=C:\projects\UltiPro.NET\Assemblies\Foundation\IntegrationStudio\Api.Ultipro.Payroll.Tests\bin\Debug"
set "destination=C:\projects\UltiPro.NET\Assemblies\Foundation\IntegrationStudio\Api.Ultipro.Personnel.Tests\bin\Debug"

echo Checking if NLog files exist in the source...

rem Check if NLog files exist in the source
if not exist "%source%\NLog.*" (
  echo NLog files do not exist in the source. Proceeding with the build and copy operations.
) else (
  echo NLog files already exist in the source. Skipping the build operation.
  goto CopyFiles
)

echo Building Visual Studio project %projectPath%...

rem Check if MSBuild executable exists
if not exist "%msbuildPath%" (
  echo MSBuild not found. Please verify the path.
  exit /b 1
)

rem Perform the build operation
"%msbuildPath%" "%projectPath%"

rem Check if the build was successful
if errorlevel 1 (
  echo Error building Visual Studio project.
  exit /b 1
) else (
  echo Visual Studio project built successfully.
)

:CopyFiles
echo Copying files with the name "NLog" from %source% to %destination%...

rem Perform the copy operation for files with the name "NLog"
copy /Y "%source%\NLog.*" "%destination%"

rem Check if the copy was successful
if errorlevel 1 (
  echo Error copying files with the name "NLog".
  exit /b 1
) else (
  echo Files with the name "NLog" copied successfully.
)

echo Press any key to exit...
pause