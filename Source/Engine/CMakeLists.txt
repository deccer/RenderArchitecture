cmake_minimum_required(VERSION 3.26)
project(Engine)

find_package(OpenGL REQUIRED)

#add_custom_target(CopyEngineLibrary ALL COMMAND ${CMAKE_COMMAND} -E copy ${CMAKE_CURRENT_BINARY_DIR}/Debug/Engine.dll ${CMAKE_SOURCE_DIR}/Source/Editor/bin/Debug/net7.0/runtimes/win-x64/native)   
#add_custom_target(CopyEngineLibraryPdb ALL COMMAND ${CMAKE_COMMAND} -E copy ${CMAKE_CURRENT_BINARY_DIR}/Debug/Engine.pdb ${CMAKE_SOURCE_DIR}/Source/Editor/bin/Debug/net7.0/runtimes/win-x64/native)   

add_library(Engine SHARED

    Public/Engine.hpp
    Private/Engine.cpp
)

target_include_directories(Engine PRIVATE Private)
target_include_directories(Engine PUBLIC Public)
target_link_libraries(Engine PRIVATE glad glfw stb_image)

if (WIN32)
add_custom_command(
    TARGET Engine POST_BUILD
    COMMAND ${CMAKE_COMMAND} -E copy ${CMAKE_CURRENT_BINARY_DIR}/Debug/Engine.dll ${CMAKE_SOURCE_DIR}/Source/Editor/bin/Debug/net8.0/runtimes/win-x64/native/ VERBATIM
    )
else()
add_custom_command(
    TARGET Engine POST_BUILD
    COMMAND ${CMAKE_COMMAND} -E copy ${CMAKE_CURRENT_BINARY_DIR}/libEngine.so ${CMAKE_SOURCE_DIR}/Source/Editor/bin/Debug/net8.0/runtimes/linux-x64/native/ VERBATIM
    )
endif (WIN32)
