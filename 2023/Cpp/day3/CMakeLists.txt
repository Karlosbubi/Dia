cmake_minimum_required(VERSION 3.27)
set(DAY 3)
set(YEAR 2023)

project(AoC_${YEAR}_D${DAY})

add_executable(Day${DAY} main.cpp)

set(CPACK_PROJECT_NAME ${PROJECT_NAME})
set(CPACK_PROJECT_VERSION ${PROJECT_VERSION})
include(CPack)
