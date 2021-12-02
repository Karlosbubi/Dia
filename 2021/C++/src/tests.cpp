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
    template <typename I, typename O>
    static bool test(vector<test_data<I, O>> test_data, O (*func)(I), int task)
    {
        cout << "Testing : \n";
        int i = 0;
        for (auto t : test_data)
        {
            i++;
            if ((func(t.input) != t.output))
            {
                cout << "Test Nr. " << i << " von Task " << task << " failed\n";
                //cout << "Expected : \"" << t.output << "\" got : \"" << func(t.input) << "\"\n";
                return false;
            }
            cout << "Test Nr. " << i << " von Task " << task << " passed\n";
        }

        return true;
    }

    int static TEST(int day)
    {
        string path = "./input/day" + to_string(day) + ".txt";
        cout << "Day " << day << " : \n\n";
        switch (day)
        {
        case 1:
            if (!test<vector<int>, int>(day1::t_t1, day1::task1, 1))
                return 1;
            if (!test<vector<int>, int>(day1::t_t2, day1::task2, 2))
                return 1;

            std::cout << "\nAll Tests Passed !\n\n";
            break;

        case 2:
            if (!test<vector<tuple<int, string>>, tuple<int, int>>(day2::t_t1, day2::task1, 1))
                return 1;
            if (!test<vector<tuple<int, string>>, tuple<int, int>>(day2::t_t2, day2::task2, 2))
                return 1;

            std::cout << "\nAll Tests Passed !\n\n";
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

    return AoC::TEST(stoi(day));
}