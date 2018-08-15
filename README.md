# Launch UWP App from Win32 App

This sample demonstrates how a Win32 C# Application can check if a UWP app is installed and launch it. Sample code is derived from this [article] (https://stackoverflow.com/questions/12925748/iapplicationactivationmanageractivateapplication-in-c)

## Requirements

* Visual Studio 2017 with Windows Universal App Development package installed
* Windows SDK version 17134 (installed with Visual Studio 2017)

## Running the Sample

* Open LaunchAppIfInstalled.sln with Visual Studio 2017

* Select the Debug/x86 or Debug/x64 configuration. (Release/x86 and Release x/64 also work)

* Right-click on the LaunchAppIfInstalled-UWP and select Deploy

* Right-click on the ConsoleApp1-UWP and select Set as Startup Project

* Press F5 to start the console app. The console app should run and launch the UWP app.

* Find the LaunchAppIfInstalled-UWP in the start menu. Right click on LaunchAppIfInstalled-UWP and select install.

* Press F5 to start the console app. The console app should report the app was not found.




##  Setup Instructions

