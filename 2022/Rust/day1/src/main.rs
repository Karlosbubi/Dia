use std::thread::Result;

fn main() {
    println!("Hello, world!");

    let input = read_input(String::from("./input.txt"));
    println!("{}", task1(input.clone()));
    println!("{}", task2(input));
}

fn read_input(path: String) -> Vec<Vec<i32>> {
    let file = std::fs::read_to_string(path).expect("ERROR: Reading File\n");
    let elves: Vec<&str> = file.split('\n').collect();

    let mut result = Vec::new();
    let mut tmp = Vec::new();

    for elf in elves {
        if elf != "" {
            let i: i32 = elf.parse().expect("ERROR: Parsing File");
            tmp.push(i);
        } else {
            result.push(tmp);
            tmp = Vec::new();
        }
    }

    return result;
}

fn task1(input: Vec<Vec<i32>>) -> i32 {
    let mut summed: Vec<i32> = input.iter().map(|e| e.iter().sum()).collect();
    summed.sort();

    summed.pop().expect("missing value")
}

fn task2(input: Vec<Vec<i32>>) -> i32 {
    let mut summed: Vec<i32> = input.iter().map(|e| e.iter().sum()).collect();
    summed.sort();

    summed.drain((summed.len() - 3)..).sum()
}
