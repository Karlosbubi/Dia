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

    vector<test_input<TYPE_I, TYPE_O>> t_t1 = {};
    vector<test_input<TYPE_I, TYPE_O>> t_t2 = {};

    //Task implemantation

    TYPE_I readInput(string path)
    {
        TYPE_I result;
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
    int task1(TYPE_O input)
    {
    }
    int task2(TYPE_O input)
    {
    }
};