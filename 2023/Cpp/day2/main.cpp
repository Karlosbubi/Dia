#include <iostream>
#include <string>
#include <fstream>

#include <boost/algorithm/string.hpp>

const int DAY = 2;
const int YEAR = 2023;

const std::string path = "../../../../Inputs/2023/Day2.txt";

int task1();
int task2();

int main()
{

    int result1 = task1();
    int result2 = task2();

    std::printf("Advent of Code %d Day %d :\n", YEAR, DAY);
    std::printf("Task 1 : %d \nTask 2 : %d\n", result1, result2);

    return 0;
}

const int RED_MAX = 12;
const int GREEN_MAX = 13;
const int BLUE_MAX = 14;

int task1()
{
    std::string line;
    std::ifstream file;
    file.open(path);

    int result = 0;

    if (file.is_open())
    {
        while (getline(file, line))
        {
            std::vector<std::string> strs;
            boost::split(strs, line, boost::is_any_of(":"));
            std::string id_str = strs.front();
            std::string games = strs.back();

            strs.clear();
            boost::split(strs, id_str, boost::is_any_of(" "));
            int game_id = std::atoi(strs.back().c_str());

            strs.clear();
            boost::split(strs, games, boost::is_any_of(";"));
            bool possible = true;

            for (std::string game : strs)
            {
                std::vector<std::string> strs2;
                boost::split(strs2, game, boost::is_any_of(","));
                int red = 0, green = 0, blue = 0;
                for (std::string i : strs2)
                {
                    std::vector<std::string> strs3;
                    boost::split(strs3, i, boost::is_any_of(" "));
                    int num = std::atoi(strs3[1].c_str());
                    // std::printf("Num = %d\n", num);
                    std::string colour = strs3[2];

                    if (colour == "red")
                    {
                        red = num;
                    }
                    if (colour == "green")
                    {
                        green = num;
                    }
                    if (colour == "blue")
                    {
                        blue = num;
                    }
                }
                if (!(red <= RED_MAX && green <= GREEN_MAX && blue <= BLUE_MAX))
                {
                    possible = false;
                    /*
                    std::printf("Game %d was not possible : ", game_id);
                    if(red > RED_MAX){
                        std::printf("because red exeeded max : %d\n", red);
                    }
                    else if(green > GREEN_MAX){
                        std::printf("because red exeeded max : %d\n", green);
                    }
                    else if(blue > BLUE_MAX){
                        std::printf("because red exeeded max : %d\n", blue);
                    }
                    else {
                        std::printf("because of a bug\n");
                    }
                    */
                }
                else
                {
                    // std::printf("Game %d was possible : red = %d, green = %d, blue = %d\n", game_id, red, green, blue);
                }
            }

            if (possible)
            {
                result += game_id;
            }
        }
    }
    else
    {
        std::printf("Failed to open file \"%s\"\n", path.c_str());
    }

    file.close();
    return result;
}

int task2()
{
    std::string line;
    std::ifstream file;
    file.open(path);

    int result = 0;

    if (file.is_open())
    {
        while (getline(file, line))
        {
            std::vector<std::string> strs;
            boost::split(strs, line, boost::is_any_of(":"));
            std::string id_str = strs.front();
            std::string games = strs.back();

            strs.clear();
            boost::split(strs, id_str, boost::is_any_of(" "));
            int game_id = std::atoi(strs.back().c_str());

            strs.clear();
            boost::split(strs, games, boost::is_any_of(";"));
            int red = 0, green = 0, blue = 0;

            for (std::string game : strs)
            {
                std::vector<std::string> strs2;
                boost::split(strs2, game, boost::is_any_of(","));

                for (std::string i : strs2)
                {
                    std::vector<std::string> strs3;
                    boost::split(strs3, i, boost::is_any_of(" "));
                    int num = std::atoi(strs3[1].c_str());
                    // std::printf("Num = %d\n", num);
                    std::string colour = strs3[2];

                    if (colour == "red" && num > red)
                    {
                        red = num;
                    }
                    if (colour == "green" && num > green)
                    {
                        green = num;
                    }
                    if (colour == "blue" && num > blue)
                    {
                        blue = num;
                    }
                }
            }
            result += (red * green * blue);
        }
    }
    else
    {
        std::printf("Failed to open file \"%s\"\n", path.c_str());
    }

    file.close();
    return result;
}