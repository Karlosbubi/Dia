use std::result;

#[derive(Debug, Clone, Copy)]
struct Rule {
    number1: i32,
    number2: i32,
    letter: char,
}

#[derive(Debug, Clone)]
struct Set {
    rule: Rule,
    password: String,
    input: String,
}

fn main() {
    println!("Hello, world!");
    let input = read_input(String::from("../../Inputs/2020/Day2.txt"));

    println!("{}", solve_t1(input.clone()));
    println!("{}", solve_t2(input));
}

fn read_input(path: String) -> Vec<Set> {
    let file = std::fs::read_to_string(path).expect("ERROR: Reading File\n");
    let lines: Vec<&str> = file.split('\n').collect();

    let mut result: Vec<Set> = Vec::new();

    for l in lines {
        let n1: i32 = l.split('-').nth(0).unwrap().parse().unwrap();
        let n2: i32 = l
            .split('-')
            .nth(1)
            .unwrap()
            .split(' ')
            .nth(0)
            .unwrap()
            .parse()
            .unwrap();
        let c: char = l
            .split('-')
            .nth(1)
            .unwrap()
            .split(' ')
            .nth(1)
            .unwrap()
            .replace(":", "")
            .parse()
            .unwrap();

        let r = Rule {
            number1: n1,
            number2: n2,
            letter: c,
        };

        let pwd: String = l
            .split('-')
            .nth(1)
            .unwrap()
            .split(' ')
            .nth(2)
            .unwrap()
            .to_string();

        result.push(Set {
            rule: r,
            password: pwd,
            input: l.to_string(),
        });
        //println!("{:#?}", result.last());
    }

    //println!("{:?}", lines);

    return result;
}

fn check_t1(input: Set) -> bool {
    let rule = input.rule;
    let pwd = input.password;

    let mut counter = 0;

    for c in pwd.chars() {
        if c == rule.letter {
            counter += 1;
        }
    }

    counter >= rule.number1 && counter <= rule.number2
}

fn solve_t1(input: Vec<Set>) -> i32 {
    let mut counter = 0;
    for set in input {
        if (check_t1(set)) {
            counter += 1;
        }
    }
    return counter;
}

fn check_t2(input: Set) -> bool {
    let rule = input.rule;
    let pwd = input.password;

    let a = pwd
        .chars()
        .nth((rule.number1 - 1).try_into().unwrap())
        .unwrap()
        == rule.letter;
    let b = pwd
        .chars()
        .nth((rule.number2 - 1).try_into().unwrap())
        .unwrap()
        == rule.letter;

    // a xor b
    (a && !b) || (b && !a)
}

fn solve_t2(input: Vec<Set>) -> i32 {
    let mut counter = 0;
    for set in input {
        if (check_t2(set)) {
            counter += 1;
        }
    }
    return counter;
}

#[test]
fn day2_solution_task1() {
    assert_eq!(solve_t1(read_input(String::from("input/input.txt"))), 414)
}

#[test]
fn day2_solution_task2() {
    assert_eq!(solve_t2(read_input(String::from("input/input.txt"))), 413)
}
