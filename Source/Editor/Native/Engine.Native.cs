using System.Runtime.InteropServices;

namespace Editor.Native;

public static partial class Engine
{
    private const string LibraryName = "Engine";

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
    private static extern int Engine_Initialize(EngineDescriptor engineDescriptor);
    
    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
    private static extern void Engine_Run();

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
    private static extern void Engine_SetWindowClose();
}