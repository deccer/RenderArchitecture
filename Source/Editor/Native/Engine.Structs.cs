using System.Runtime.InteropServices;

namespace Editor.Native;

public static partial class Engine
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int InitializeDelegate();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int LoadDelegate();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void UpdateDelegate(float deltaTime);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FixedUpdateDelegate(float deltaTime);

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct EngineDescriptor
    {
        public InitializeDelegate InitializeDelegate;
        public LoadDelegate LoadDelegate;
        public UpdateDelegate UpdateDelegate;
        public FixedUpdateDelegate FixedUpdateDelegate;
    }
}