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

In order to replicate this scenario you will need to use the application user model ID of the your Windows Store app in the call to appActiveManager.ActivateApplication. You create this
string by appending !App to the Package Family Name of your app.

For example, if the Package Family Name of your app is 

    f41b88ad-fb57-433c-863c-75e6978e7627_e8xk87pxx0yyw 

then the application user model ID of your app will be 

    f41b88ad-fb57-433c-863c-75e6978e7627_e8xk87pxx0yyw!App

You can find the Package Family Name of your app by looking at the Packaging tab of the Package.appxmanifest (double click on the Package.appxmanifest file in your solution).


