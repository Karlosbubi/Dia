#include <iostream>
#include <fstream>
#include <vector>
#include <string>

using namespace std;

#include "day1.hpp"
#include "day2.hpp"

class AoC
{
public:
    static int RUN(const int day)
    {
        string path = "./input/day" + to_string(day) + ".txt";
        cout << "Day " << day << " : \n\n";
        switch (day)
        {
        case 1:
            cout << "\tTask 1 result : " << day1::task1(day1::readInput(path)) << "\n";
            cout << "\tTask 2 result : " << day1::task2(day1::readInput(path)) << "\n\n";
            break;

        case 2:
            cout << "\tTask 1 result : " << day2::task1(day2::readInput(path)) << "\n";
            cout << "\tTask 2 result : " << day2::task2(day2::readInput(path)) << "\n\n";
            break;

        default:
            cout << "\tDay Invalid (try 1-24) or not yet Implemented\n\n";
            break;
        }

        return 0;
    }
};

int main(int argc, char **argv)
{
    if (argc < 2)
    {
        return -1;
    }
    string day = argv[1];
    day = day.substr(3, 2);

    return AoC::RUN(stoi(day));
}