#include <iostream>
#include <string>
#include <string_view>
#include <fstream>
#include <list>

const int DAY = 1;
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
    std::string line;
    std::ifstream file;

    std::list<int> digits;
    int sum = 0;

    file.open(path);
    if(file.is_open()){
        while (getline(file, line)){
            for(char c : line){
                if(c >= '0' && c <= '9'){
                    digits.push_back(c - '0');
                }
            }
            int val = (digits.front() * 10) + digits.back();
            digits.clear();
            //std::printf("%s => %d\n", line.c_str(), val);
            sum += val;
        } 
    }
    else {
        std::printf("Failed to open file \"%s\"\n", path.c_str());
    }
    
    file.close();
    return sum;
}

int task2(){
        std::string line;
    std::ifstream file;

    std::list<int> digits;
    int sum = 0;

    file.open(path);
    if(file.is_open()){
        while (getline(file, line)){
            std::string line_copy = line;
            for(int i = 0; i < line_copy.length(); i++){
                if(line.starts_with("zero") || line.starts_with("0")){
                    //std::printf("DEBUG : %s starts with %d\n", line.c_str(), 0);
                    digits.push_back(0);
                }
                if(line.starts_with("one") || line.starts_with("1")){
                    //std::printf("DEBUG : %s starts with %d\n", line.c_str(), 1);
                    digits.push_back(1);
                }
                if(line.starts_with("two") || line.starts_with("2")){
                    //std::printf("DEBUG : %s starts with %d\n", line.c_str(), 2);
                    digits.push_back(2);
                }
                if(line.starts_with("three") || line.starts_with("3")){
                    //std::printf("DEBUG : %s starts with %d\n", line.c_str(), 3);
                    digits.push_back(3);
                }
                if(line.starts_with("four") || line.starts_with("4")){
                    //std::printf("DEBUG : %s starts with %d\n", line.c_str(), 4);
                    digits.push_back(4);
                }
                if(line.starts_with("five") || line.starts_with("5")){
                    //std::printf("DEBUG : %s starts with %d\n", line.c_str(), 5);
                    digits.push_back(5);
                }
                if(line.starts_with("six") || line.starts_with("6")){
                    //std::printf("DEBUG : %s starts with %d\n", line.c_str(), 6);
                    digits.push_back(6);
                }
                if(line.starts_with("seven") || line.starts_with("7")){
                    //std::printf("DEBUG : %s starts with %d\n", line.c_str(), 7);
                    digits.push_back(7);
                }
                if(line.starts_with("eight") || line.starts_with("8")){
                    //std::printf("DEBUG : %s starts with %d\n", line.c_str(), 8);
                    digits.push_back(8);
                }
                if(line.starts_with("nine") || line.starts_with("9")){
                    //std::printf("DEBUG : %s starts with %d\n", line.c_str(), 9);
                    digits.push_back(9);
                }
                line.erase(0, 1);
            }
            int val = (digits.front() * 10) + digits.back();
            digits.clear();
            //std::printf("%s (%s) => %d\n", line_copy.c_str(), line.c_str(), val);
            sum += val;
        } 
    }
    else {
        std::printf("Failed to open file \"%s\"\n", path.c_str());
    }
    
    file.close();
    return sum;
}