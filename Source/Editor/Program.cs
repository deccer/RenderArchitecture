using Microsoft.Extensions.DependencyInjection;

namespace Editor;

public static class Program
{
    public static void Main()
    {
        using var serviceProvider = CreateServiceProvider();
        var game = serviceProvider.GetRequiredService<IGame>();
        game.Run();
    }
    
    private static ServiceProvider CreateServiceProvider()
    {
        var services = new ServiceCollection();
        services.AddSingleton<IGame, Game>();
        return services.BuildServiceProvider();
    }
}