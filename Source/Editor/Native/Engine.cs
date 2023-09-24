using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Editor.Native;

public static partial class Engine
{
    private static nint _nativeLibraryHandle;
    
    static Engine()
    {
        NativeLibrary.SetDllImportResolver(typeof(Engine).Assembly, Resolve);
    }

    private static IntPtr Resolve(string libraryName, Assembly assembly, DllImportSearchPath? searchPath)
    {
        if (_nativeLibraryHandle != nint.Zero)
        {
            return _nativeLibraryHandle;
        }
        
        var libraryPath = GetLibraryName();
        _nativeLibraryHandle = File.Exists(libraryPath)
            ? NativeLibrary.TryLoad(libraryPath, out var libraryHandle)
                ? libraryHandle
                : IntPtr.Zero
            : IntPtr.Zero;
        return _nativeLibraryHandle;
    }

    public static bool Initialize(ref EngineDescriptor engineDescriptor)
    {
        return Engine_Initialize(engineDescriptor) == 1;
    }

    public static void Terminate()
    {
    }

    public static void Run()
    {
        Engine_Run();
    }

    public static void SetWindowClose()
    {
        Engine_SetWindowClose();
    }
    
    private static string GetLibraryName()
    {
        var windowsPaths = new []
        {
            Path.Combine(Environment.CurrentDirectory, "bin/Debug/net7.0/runtimes/win-x64/native/Engine.dll"),
            "runtimes/win-x64/native/Engine.dll",
            "Engine.dll"
        };

        var linuxPaths = new []
        {
            Path.Combine(Environment.CurrentDirectory, "bin/Debug/net7.0/runtimes/linux-x64/native/libEngine.so"),
            "bin/Debug/net7.0/runtimes/linux-x64/native/libEngine.so",
            "runtimes/linux-x64/native/libEngine.so",
            "libEngine.so"
        };

        var paths = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
            ? windowsPaths
            : linuxPaths;

        foreach (var path in paths)
        {
            if (File.Exists(path))
            {
                return path;
            }
        }

        return string.Empty;
    }
}