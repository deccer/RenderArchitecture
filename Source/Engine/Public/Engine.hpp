#pragma once

#include <cstdint>
#include "Compiler.hpp"

struct GLFWwindow;

using EventHandler =  void (ENGINE_CALL *)();
using BoolEventHandler = int (ENGINE_CALL *)();
using DeltaTimeHandler = void (ENGINE_CALL *)(float deltaTime);

typedef struct EngineDescriptor
{
    BoolEventHandler OnInitialize;
    BoolEventHandler OnLoad;
    DeltaTimeHandler OnUpdate;
    DeltaTimeHandler OnFixedUpdate; 
    DeltaTimeHandler OnRender;
    EventHandler OnUnload;
} EngineDescriptor;

typedef struct EngineState
{
    bool IsRunning;
    EngineDescriptor Descriptor;
    GLFWwindow* Window;
} EngineState;

EngineState* GetEngineState();

#if __cplusplus
extern "C"
{
#endif

int32_t ENGINE_API Engine_Initialize(EngineDescriptor engineDescriptor);
void ENGINE_API Engine_Run();
void ENGINE_API Engine_SetWindowClose();

#if __cplusplus
}
#endif

