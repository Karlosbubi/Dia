use std::io::BufRead;

pub(crate) fn task1(path: &str) -> i32 {
    let sum = 0;

    let input = read_file(path);
    let sum = input.iter().map(|x| {
        get_number(x)
    }).sum();

    sum
}

pub(crate) fn task2(path: &str) -> i32 {
    return -1;
}

fn read_file(path: &str) -> Vec<String> {
    let file = std::fs::read_to_string(path).expect("ERROR: Reading File\n");
    file.lines().map(|x| {x.to_string()}).collect()
}

fn get_number(input: &str) -> i32 {
    let mut a = 0;
    let mut b = 0;
    for (_, c) in input.chars().enumerate() {
        match c.to_digit(10) {
            Some(d) => {
                a = d;
                break;
            }
            None => {}
        }
    }
    for (_, c) in input.chars().into_iter().rev().enumerate() {
        match c.to_digit(10) {
            Some(d) => {
                b = d;
                break;
            }
            None => {}
        }
    }

    (a * 10 + b) as i32
}

fn repace_numbers(input: &str) -> String {

}
