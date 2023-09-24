using System.Runtime.InteropServices;

namespace Editor.Native;

public static partial class Engine
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct EngineDescriptor
    {
        public InitializeDelegate InitializeDelegate;
        public LoadDelegate LoadDelegate;
        public UpdateDelegate UpdateDelegate;
        public FixedUpdateDelegate FixedUpdateDelegate;
    }
}