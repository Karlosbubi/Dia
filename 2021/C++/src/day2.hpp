#include <iostream>
#include <fstream>
#include <vector>
#include <tuple>
#include <string>

using namespace std;

#ifndef test_input
#define test_input

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
#endif

namespace day2
{
    //Test Data :

    vector<tuple<int, string>> input_t1 = {make_tuple(string("forward"), 5),
                                           make_tuple(string("down"), 5),
                                           make_tuple(string("forward"), 8),
                                           make_tuple(string("up"), 3),
                                           make_tuple(string("down"), 8),
                                           make_tuple(string("forward"), 2)};

    tuple<int, int> output_t1 = make_tuple(15, 10);

    vector<test_data<vector<tuple<int, string>>, tuple<int, int>>> t_t1 = {{input_t1, output_t1}};

    vector<test_data<vector<tuple<int, string>>, tuple<int, int>>> t_t2 = {{input_t1, output_t1}};

    //Task implemantation

    vector<tuple<int, string>> readInput(string path)
    {
        vector<tuple<int, string>> result;
        string line;
        ifstream file(path);
        if (file.is_open())
        {
            while (getline(file, line))
            {
                // Format
            }
            file.close();
        }

        return result;
    }
    tuple<int, int> task1(vector<tuple<int, string>> input)
    {
        return make_tuple(0, 0);
    }
    tuple<int, int> task2(vector<tuple<int, string>> input)
    {
        return make_tuple(0, 0);
    }
};