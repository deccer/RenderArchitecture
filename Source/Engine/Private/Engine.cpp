#include "Engine.hpp"
#include "EngineAppIcon.hpp"

#include <iostream>

#include <glad/glad.h>
#include <GLFW/glfw3.h>

#define STB_IMAGE_IMPLEMENTATION
#include <stb_image.h>

static EngineState g_EngineState;

EngineState* GetEngineState()
{
	return &g_EngineState;
}

int32_t Engine_Initialize(EngineDescriptor engineDescriptor)
{
    if (g_EngineState.IsRunning)
    {
        return 1;
    }

    if (glfwInit() == GLFW_FALSE)
    {
        printf("C++: Unable to initialize Glfw\n");
        return 1;
    }

    g_EngineState.Window = nullptr;

    g_EngineState.Descriptor.OnInitialize = engineDescriptor.OnInitialize;
    g_EngineState.Descriptor.OnLoad = engineDescriptor.OnLoad;
    g_EngineState.Descriptor.OnUpdate = engineDescriptor.OnUpdate;
    g_EngineState.Descriptor.OnFixedUpdate = engineDescriptor.OnFixedUpdate;
    g_EngineState.Descriptor.OnRender = engineDescriptor.OnRender;
    g_EngineState.Descriptor.OnUnload = engineDescriptor.OnUnload;

    return 1;
}

void Engine_Run()
{
    std::cout << "C++: Creating Window\n";

    glfwWindowHint(GLFW_CLIENT_API, GLFW_OPENGL_API);
    glfwWindowHint(GLFW_OPENGL_PROFILE, GLFW_OPENGL_CORE_PROFILE);
    glfwWindowHint(GLFW_CONTEXT_VERSION_MAJOR, 4);
    glfwWindowHint(GLFW_CONTEXT_VERSION_MINOR, 6);
    glfwWindowHint(GLFW_OPENGL_DEBUG_CONTEXT, GLFW_TRUE);

    auto primaryMonitor = glfwGetPrimaryMonitor();
    auto videoMode = glfwGetVideoMode(primaryMonitor);

    auto screenWidth = videoMode->width;
    auto screenHeight = videoMode->height;

    auto windowWidth = static_cast<int32_t>(screenWidth * 0.8f);
    auto windowHeight = static_cast<int32_t>(screenHeight * 0.8f);

    g_EngineState.Window = glfwCreateWindow(windowWidth, windowHeight, "C++ Window", nullptr, nullptr);
    if (g_EngineState.Window == nullptr)
    {
        printf("C++: Unable to create window\n");
        glfwTerminate();
        return;
    }
    std::cout << "C++: Window Created\n";

    int32_t monitorLeft = 0;
    int32_t monitorTop = 0;
    glfwGetMonitorPos(primaryMonitor, &monitorLeft, &monitorTop);
    glfwSetWindowPos(g_EngineState.Window, screenWidth / 2 - windowWidth / 2 + monitorLeft, screenHeight / 2 - windowHeight / 2 + monitorTop);

    int32_t appImageWidth{};
    int32_t appImageHeight{};
    unsigned char* appImagePixels = stbi_load_from_memory(reinterpret_cast<const stbi_uc*>(&g_EngineAppIcon[0]), g_EngineAppIconSize, &appImageWidth, &appImageHeight, nullptr, 4);
    if (appImagePixels != nullptr)
    {
        GLFWimage appImage;
        appImage.width = 128;
        appImage.height = 128;
        appImage.pixels = appImagePixels;
        glfwSetWindowIcon(g_EngineState.Window, 1, &appImage);
        stbi_image_free(appImagePixels);
    }

    glfwMakeContextCurrent(g_EngineState.Window);
    gladLoadGLLoader((GLADloadproc)glfwGetProcAddress);
    
    if (g_EngineState.Descriptor.OnInitialize() == 0)
    {
        printf("C++: Not Initialized\n");
        return;
    }
    std::cout << "C++: Initialized\n";

    if (g_EngineState.Descriptor.OnLoad() == 0)
    {
      return;
    }
    std::cout << "C++: Loaded\n";

    auto currentTime = glfwGetTime();
    auto previousTime = currentTime;

    while (!glfwWindowShouldClose(g_EngineState.Window))
    {
        glfwPollEvents();
        currentTime = glfwGetTime();
        auto deltaTime = static_cast<float>(currentTime - previousTime);
        previousTime = currentTime;

        g_EngineState.Descriptor.OnUpdate(deltaTime);
        g_EngineState.Descriptor.OnRender(deltaTime);

        glfwSwapBuffers(g_EngineState.Window);
    }

    g_EngineState.Descriptor.OnUnload();

    glfwDestroyWindow(g_EngineState.Window);
    g_EngineState.Window = nullptr;
}

void Engine_SetWindowClose()
{
    glfwSetWindowShouldClose(g_EngineState.Window, GLFW_TRUE);
}

void Engine_SetWindowTitle(const char* windowTitle)
{
    glfwSetWindowTitle(g_EngineState.Window, windowTitle);
}