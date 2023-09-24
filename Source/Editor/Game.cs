using System;
using System.Runtime.InteropServices;
using Editor.Native;

namespace Editor;

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate int InitializeDelegate();

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate int LoadDelegate();

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void UpdateDelegate(float deltaTime);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void FixedUpdateDelegate(float deltaTime);

internal sealed class Game : IGame
{
    private readonly InitializeDelegate _initializeDelegate;
    private readonly LoadDelegate _loadDelegate;
    private readonly UpdateDelegate _updateDelegate;
    private readonly FixedUpdateDelegate _fixedUpdateDelegate;

    private static int _counter;

    public Game()
    {
    }
    
    public void Run()
    {
        var engineDescriptor = new Engine.EngineDescriptor
        {
            InitializeDelegate = Initialize,
            LoadDelegate = Load,
            UpdateDelegate = Update,
            FixedUpdateDelegate = FixedUpdate
        };

        if (!Engine.Initialize(ref engineDescriptor))
        {
            return;
        }

        Engine.Run();
        
        Engine.Terminate();
    }

    public int Initialize()
    {
        Console.WriteLine("C# Initialize");
        return 1;
    }

    public static int Load()
    {
        Console.WriteLine("C# Load");
        return 1;
    }

    public static void Update(float deltaTime)
    {
        /*
        Console.WriteLine("C# Update");

        _counter++;
        if (_counter == 100)
        {
            Engine.SetWindowClose();
        }
        */
    }

    public static void FixedUpdate(float deltaTime)
    {
        Console.WriteLine("C# FixedUpdate");
    }
}