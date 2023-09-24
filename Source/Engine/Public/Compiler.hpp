#pragma once

#if (defined(__clang__) || (defined(__GNUC__)))
#define ENGINE_API __attribute__ ((__visibility__ ("default")))
#define ENGINE_CALL
#elif (defined(__MINGW64__) || (defined(_MSC_VER)))
#define ENGINE_API __declspec(dllexport)
#define ENGINE_CALL __cdecl
#else
#pragma error "Unsupported Compiler"
#define ENGINE_API
#define ENGINE_CALL
#endif
