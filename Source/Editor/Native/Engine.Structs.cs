using System.Runtime.InteropServices;

namespace Editor.Native;

public static partial class Engine
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int BoolEventHandler();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void EventHandler();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void DeltaTimeEventHandler(float deltaTime);
    
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct EngineDescriptor
    {
        public BoolEventHandler OnInitialize;
        public BoolEventHandler OnLoad;
        public DeltaTimeEventHandler OnUpdate;
        public DeltaTimeEventHandler OnFixedUpdate;
        public DeltaTimeEventHandler OnRender;
        public EventHandler OnUnload;
    }
}