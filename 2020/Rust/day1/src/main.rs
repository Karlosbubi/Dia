fn main() {
    println!("Hello, world!");

    println!(
        "{:#?}",
        std::env::current_dir()
            .expect("ERROR: current dir")
            .display()
    );

    let input = read_input(String::from("day1/input/input.txt"));
    println!("{}", task1(input.clone()));
    println!("{}", task2(input));
}

fn read_input(path: String) -> Vec<i32> {
    let file = std::fs::read_to_string(path).expect("ERROR: Reading File\n");
    let result = file
        .split_whitespace()
        .map(|s| s.parse().expect("ERROR: Parsing File"))
        .collect();

    return result;
}

fn task1(input: Vec<i32>) -> i32 {
    for a in input.clone() {
        for b in input.clone() {
            if a + b == 2020 {
                return a * b;
            }
        }
    }
    return 0;
}

fn task2(input: Vec<i32>) -> i32 {
    for a in input.clone() {
        for b in input.clone() {
            for c in input.clone() {
                if a + b + c == 2020 {
                    return a * b * c;
                }
            }
        }
    }
    return 0;
}

#[test]
fn day1_test_task1() {
    let input: Vec<i32> = [1721, 979, 366, 299, 675, 1456].to_vec();
    assert_eq!(task1(input), 514579)
}

#[test]
fn day1_test_task2() {
    let input: Vec<i32> = [1721, 979, 366, 299, 675, 1456].to_vec();
    assert_eq!(task2(input), 241861950)
}

#[test]
fn day1_solution_task1(){
    let input = read_input(String::from("input/input.txt"));
    assert_eq!(task1(input), 960075)
}

#[test]
fn day1_solution_task2(){
    let input = read_input(String::from("input/input.txt"));
    assert_eq!(task2(input), 212900130)
}