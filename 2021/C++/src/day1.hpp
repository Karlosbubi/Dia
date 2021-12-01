#include <iostream>
#include <fstream>
#include <vector>
#include <string>

using namespace std;

template <typename I, typename O>
struct test_data
{
    I input;
    O output;
    test_data(I in, O out)
    {
        input = in;
        output = out;
    }
};

namespace day1
{
    //Test Data :

    vector<int> input = {199, 200, 208, 210, 200, 207, 240, 269, 260, 263};

    test_data<vector<int>, int> test1(input, 7);
    vector<test_data<vector<int>, int>> t_t1 = {test1};

    test_data<vector<int>, int> test2(input, 5);
    vector<test_data<vector<int>, int>> t_t2 = {test2};

    //Task implemantation

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
};