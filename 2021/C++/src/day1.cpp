//#include "AoC.hpp"

#include <iostream>
#include <fstream>
#include <vector>
#include <string>

using namespace std;

int task1(vector<int> input);
int task2(vector<int> input);
vector<int> readInput(string path);

//vector<test_input<vector<int>, int>> t_t1 = {test_input<vector<int>, int>({199, 200, 208, 210, 200, 207, 240, 269, 260, 263}, 7)};

int main()
{
    cout << "Hello Day 1\n";
    //return AoC::test<vector<int>, int>(t_t1, t_t1) ? -1 : AoC::run<vector<int>>(string("../input/day1.txt"));
    vector<int> test = {199, 200, 208, 210, 200, 207, 240, 269, 260, 263};
    vector<int> input = readInput("input/day1.txt");

    cout << "Task 1 test : " << task1(test) << " \n";
    cout << "Task 1 result : " << task1(input) << " \n";

    cout << "Task 2 test : " << task2(test) << " \n";
    cout << "Task 2 result : " << task2(input) << " \n";
}

vector<int> readInput(string path)
{
    vector<int> result;
    string line;
    ifstream file(path);
    if (file.is_open())
    {
        while (getline(file, line))
        {
            result.push_back(stoi(line));
        }
        file.close();
    }

    return result;
}
int task1(vector<int> input)
{
    int growth = 0;
    for (int i = (input.size() - 1); i > 0; i--)
    {
        if (input[i] > input[i - 1])
        {
            growth++;
        }
    }
    return growth;
}
int task2(vector<int> input)
{
    vector<int> sums;

    for (int i = (input.size() - 1); i > 1; i--)
    {

        sums.insert(sums.begin(), (input[i] + input[i - 1] + input[i - 2]));
        //cout << input[i] << " + " << input[i - 1] << " + " << input[i - 2] << " = " << (input[i] + input[i - 1] + input[i - 2]) << "\n";
        //cout << "i = " << i << " - Indices = " << i << " " << i - 1 << " " << i - 2 << " \n";
    }

    return task1(sums);
}