#include "AoC.hpp"

using namespace std;

vector<test_input<vector<int>, int>> t_t1;
t_t1.push_back(test_input({199, 200, 208, 210, 200, 207, 240, 269, 260, 263}, 7));

int main()
{
    cout << "Hello Day 1\n";
    return AoC::test<vector<int>, int>(t_t1, ) ? -1 : AoC::run<vector<int>>(string("../input/day1.txt"));
}

vector<int> readInput(string path)
{
}

int task1(vector<int> input)
{
}

bool tests()
{
    //task 1
    vector<int> input = {199, 200, 208, 210, 200, 207, 240, 269, 260, 263};

    int output = 7;

    if (output != task1(input))
    {
        cout << "Day 1 task 1 failed. \n";
        cout << "Expected : " << output << " got : " << task1(input) << ".\n";
        return false;
    }
    else
    {
        cout << "Day 1 task 1 passed. \n";
    }

    return true;
}