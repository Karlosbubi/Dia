#include <iostream>
#include <vector>
#include <string>

template <typename I, typename O>
struct test_input
{
    I input;
    O output;
    test_input(I in, O out)
    {
        input = in;
        output = out;
    }
};

class AoC
{
    template <typename T>
    T readInput(std::string path);
    template <typename T>
    auto task1(T input);
    template <typename T>
    auto task2(T input);

public:
    template <typename T>
    static int run(const std::string path)
    {
        std::cout << "Task 1 result : " << task1<T>(readInput<T>(path)) << "\n";
        std::cout << "Task 2 result : " << task2<T>(readInput<T>(path)) << "\n";

        return 0;
    }

    template <typename I, typename O>
    static bool test(std::vector<test_input<I, O>> t_task1, std::vector<test_input<I, O>> t_task2)
    {
        std::cout << "Testing : \n";
        int i = 0;
        for (auto t1 : t_task1)
        {
            i++;
            if (task1<I>(t1.input) != t1.output)
            {
                std::cout << "Test Nr. " << i << " von Task 1 failed\n";
                return false;
            }
            std::cout << "Test Nr. " << i << " von Task 1 passed\n";
        }

        i = 0;
        for (auto t2 : t_task2)
        {
            i++;
            if (task1<I>(t2.input) != t2.output)
            {
                std::cout << "Test Nr. " << i << " von Task 2 failed\n";
                return false;
            }
            std::cout << "Test Nr. " << i << " von Task 2 passed\n";
        }

        std::cout << "\nAll Tests Passed !\n\n";
        return true;
    }
};