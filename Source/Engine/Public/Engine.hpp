#pragma once

#include <cstdint>
#include "Compiler.hpp"

struct GLFWwindow;

using InitializeDelegate =  int (ENGINE_CALL *)();
using LoadDelegate = int (ENGINE_CALL *)();
using UpdateDelegate = void (ENGINE_CALL *)(float deltaTime);
using FixedUpdateDelegate = void (ENGINE_CALL *)(float deltaTime);

typedef struct EngineDescriptor
{
    InitializeDelegate Initialize;
    LoadDelegate Load;
    UpdateDelegate Update;
    FixedUpdateDelegate FixedUpdate; 
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

