cmake_minimum_required(VERSION 3.26)
project(Engine)

find_package(OpenGL REQUIRED)

if (WIN32)
    set(EngineTarget x64)
elseif (UNIX)
    set(EngineTarget lib64)
else()
    message(FATAL_ERROR "Unknown Target!")
endif()

add_library(Engine SHARED

    Public/Engine.hpp
    Private/Engine.cpp
)

set_target_properties(Engine
    PROPERTIES
    ARCHIVE_OUTPUT_DIRECTORY "${CMAKE_CURRENT_SOURCE_DIR}/Lib/${EngineTarget}"
    LIBRARY_OUTPUT_DIRECTORY "${CMAKE_CURRENT_SOURCE_DIR}/Lib/${EngineTarget}"
    RUNTIME_OUTPUT_DIRECTORY "${CMAKE_CURRENT_SOURCE_DIR}/Lib/${EngineTarget}"
)


target_include_directories(Engine PRIVATE Private)
target_include_directories(Engine PUBLIC Public)
target_link_libraries(Engine PRIVATE glad glfw stb_image)


# if (WIN32)
# add_custom_command(
#     TARGET Engine POST_BUILD
#     COMMAND ${CMAKE_COMMAND} -E copy ${CMAKE_CURRENT_BINARY_DIR}/Debug/Engine.dll ${CMAKE_SOURCE_DIR}/Lib/win-x64/ VERBATIM
#     )
# else()
# add_custom_command(
#     TARGET Engine POST_BUILD
#     COMMAND ${CMAKE_COMMAND} -E copy ${CMAKE_CURRENT_BINARY_DIR}/libEngine.so ${CMAKE_SOURCE_DIR}/Lib/linux-x64/ VERBATIM
#     )
# endif (WIN32)
