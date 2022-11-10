use std::result;

#[derive(Clone, PartialEq)]
enum Length {
    cm(i32),
    inch(i32),
}

#[derive(Clone)]
struct Passport {
    byr: i32,
    iyr: i32,
    eyr: i32,
    hgt: Length,
    hcl: String,
    pid: i64,
    cid: i32,
}

fn main() {
    println!("Hello, world!");
    let data = readInput("day4/input/input.txt".to_string());

    println!("task 1 : {}", task1(data.clone()));
    println!("task 2 : {}", task2(data));
}

fn readInput(path: String) -> Vec<Passport> {
    let file = std::fs::read_to_string(path).unwrap();
    let lines: Vec<&str> = file.split('\n').collect();

    // line vec to entry string vec

    let mut result = Vec::new();
    for l in lines {
        result.push(Passport::fromString(l.to_string()));
    }
    return result;
}

impl Passport {
    pub fn fromString(input: String) -> Passport {
        Passport {
            byr: 0,
            iyr: 0,
            eyr: 0,
            hgt: Length::cm(0),
            hcl: "".to_string(),
            pid: 0,
            cid: 0,
        }
    }

    fn complete(&self) -> bool {
        if self.byr == 0 {
            return false;
        }
        if self.iyr == 0 {
            return false;
        }
        if self.eyr == 0 {
            return false;
        }
        if self.hgt == Length::cm(0) {
            return false;
        }
        if self.hcl == "".to_string() {
            return false;
        }
        if self.pid == 0 {
            return false;
        }

        true
    }

    fn valid(&self) -> bool {
        false
    }
}

fn task1(input: Vec<Passport>) -> i32 {
    let mut counter = 0;
    for passport in input {
        if passport.complete() {
            counter += 1;
        }
    }
    return counter;
}

fn task2(input: Vec<Passport>) -> i32 {
    let mut counter = 0;
    for passport in input {
        if passport.valid() {
            counter += 1;
        }
    }
    return counter;
}
