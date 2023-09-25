using System;
using Editor.Native;

namespace Editor;

internal sealed class Game : IGame
{
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

    public int Load()
    {
        Console.WriteLine("C# Load");
        return 1;
    }

    public void Update(float deltaTime)
    {
        
        Console.WriteLine("C# Update");
        /*
        _counter++;
        if (_counter == 100)
        {
            Engine.SetWindowClose();
        }
        */
    }

    public void FixedUpdate(float deltaTime)
    {
        Console.WriteLine("C# FixedUpdate");
    }
}