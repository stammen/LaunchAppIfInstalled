﻿using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// From https://stackoverflow.com/questions/12925748/iapplicationactivationmanageractivateapplication-in-c

public enum ActivateOptions
{
    None = 0x00000000,  // No flags set
    DesignMode = 0x00000001,  // The application is being activated for design mode, and thus will not be able to
    // to create an immersive window. Window creation must be done by design tools which
    // load the necessary components by communicating with a designer-specified service on
    // the site chain established on the activation manager.  The splash screen normally
    // shown when an application is activated will also not appear.  Most activations
    // will not use this flag.
    NoErrorUI = 0x00000002,  // Do not show an error dialog if the app fails to activate.                                
    NoSplashScreen = 0x00000004,  // Do not show the splash screen when activating the app.
}

[ComImport, Guid("2e941141-7f97-4756-ba1d-9decde894a3d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
interface IApplicationActivationManager
{
    // Activates the specified immersive application for the "Launch" contract, passing the provided arguments
    // string into the application.  Callers can obtain the process Id of the application instance fulfilling this contract.
    IntPtr ActivateApplication([In] String appUserModelId, [In] String arguments, [In] ActivateOptions options, [Out] out UInt32 processId);
    IntPtr ActivateForFile([In] String appUserModelId, [In] IntPtr /*IShellItemArray* */ itemArray, [In] String verb, [Out] out UInt32 processId);
    IntPtr ActivateForProtocol([In] String appUserModelId, [In] IntPtr /* IShellItemArray* */itemArray, [Out] out UInt32 processId);
}

[ComImport, Guid("45BA127D-10A8-46EA-8AB7-56EA9078943C")]//Application Activation Manager
class ApplicationActivationManager : IApplicationActivationManager
{
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)/*, PreserveSig*/]
    public extern IntPtr ActivateApplication([In] String appUserModelId, [In] String arguments, [In] ActivateOptions options, [Out] out UInt32 processId);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    public extern IntPtr ActivateForFile([In] String appUserModelId, [In] IntPtr /*IShellItemArray* */ itemArray, [In] String verb, [Out] out UInt32 processId);
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    public extern IntPtr ActivateForProtocol([In] String appUserModelId, [In] IntPtr /* IShellItemArray* */itemArray, [Out] out UInt32 processId);
}

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ApplicationActivationManager appActiveManager = new ApplicationActivationManager();//Class not registered

            try
            {
                uint pid;
                appActiveManager.ActivateApplication("f41b88ad-fb57-433c-863c-75e6978e7627_e8xk87pxx0yyw!App", null, ActivateOptions.None, out pid);
                Console.WriteLine("App is installed");
                Environment.Exit(0); // exit the app now since the UWP app was launched
            }
            catch (Exception e)
            {
                Console.WriteLine("App is not installed: " + e.Message);
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
