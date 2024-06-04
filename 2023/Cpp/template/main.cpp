#include <iostream>
#include <string>
#include <fstream>

const int DAY = 2;
const int YEAR = 2023;

const std::string path = "../../../../Inputs/2023/Day1.txt";

int task1();
int task2();

int main(){
    
    int result1 = task1();
    int result2 = task2();

    std::printf("Advent of Code %d Day %d :\n", YEAR, DAY);
    std::printf("Task 1 : %d \nTask 2 : %d\n", result1, result2);

    return 0;
}


int task1(){
    std::printf("Hello World\n");

    std::string line;
    std::ifstream file;
    file.open(path);
    if(file.is_open()){
        while (getline(file, line)){
            std::printf("%s\n", line.c_str());
        } 
    }
    else {
        std::printf("Failed to open file \"%s\"\n", path.c_str());
    }
    
    file.close();
    return -1;
}

int task2(){
    return -1;
}
