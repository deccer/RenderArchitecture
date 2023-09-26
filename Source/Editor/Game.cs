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
            OnInitialize = Initialize,
            OnLoad = Load,
            OnUpdate = Update,
            OnFixedUpdate = FixedUpdate,
            OnRender = Render,
            OnUnload = Unload
        };

        if (!Engine.Initialize(ref engineDescriptor))
        {
            return;
        }

        Engine.Run();
        
        Engine.Terminate();
    }

    private int Initialize()
    {
        Console.WriteLine("C# Initialize");
        return 1;
    }

    private int Load()
    {
        Console.WriteLine("C# Load");
        return 1;
    }

    private void Update(float deltaTime)
    {
        
        Console.WriteLine("C#: Update");
        /*
        _counter++;
        if (_counter == 100)
        {
            Engine.SetWindowClose();
        }
        */
    }

    private void FixedUpdate(float deltaTime)
    {
        Console.WriteLine("C#: FixedUpdate");
    }

    private void Render(float deltaTime)
    {

    }

    private void Unload()
    {
        Console.WriteLine("C#: Unload");
    }
}