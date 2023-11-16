const ROCK : i32 = 1;
const PAPER : i32 = 2;
const SCISSORS : i32 = 3;
const LOSS : i32 = 0;
const DRAW : i32 = 3;
const WIN : i32 = 6;


fn main() {
    println!("Hello, world!");
    let data = read_input("./input.txt".to_string());

    println!("{:?}", task2(data));
}

fn read_input(path: String) -> Vec<(char, char)> {
    let mut result = Vec::new();
    let file = std::fs::read_to_string(path).expect("ERROR: Reading File\n");
    let file = file.trim(); // Deal with trailing new line
    let lines: Vec<&str> = file.split('\n').collect();

    for l in lines {
        let mut tmp = l
            .split(' ')
            .map(|c| c.chars().last().expect("Invalid Input"));
        let a = tmp.next().expect("Missing Char a");
        let b = tmp.next().expect("Missong Char b");
        result.push((a, b));
    }

    return result;
}

fn task1(input: Vec<(char, char)>) -> i32 {
    let mut score = 0;

    /*
    A = X = Rock
    B = Y = Paper
    C = C = Scissors
    */

    for round in input {
        match round.0 {
            'A' => match round.1 { // Rock
                'X' => score += ROCK + DRAW,
                'Y' => score += PAPER + WIN,
                'Z' => score += SCISSORS + LOSS,
                _default => {}
            },
            'B' => match round.1 { // Paper
                'X' => score += ROCK + LOSS,
                'Y' => score += PAPER + DRAW,
                'Z' => score += SCISSORS + WIN,
                _default => {}
            },
            'C' => match round.1 { //Scissors
                'X' => score += ROCK + WIN,
                'Y' => score += PAPER + LOSS,
                'Z' => score += SCISSORS + DRAW,
                _default => {}
            },
            _default => {}
        }
    }

    return score;
}

fn task2(input: Vec<(char, char)>) -> i32 {
    let mut score = 0;

    /*
    A = Rock
    B = Paper
    C = Scissors

    X = loss
    Y = draw
    Z = win
    */

    for round in input {
        match round.0 {
            'A' => match round.1 { // Rock
                'X' => score += SCISSORS + LOSS,
                'Y' => score += ROCK + DRAW,
                'Z' => score += PAPER + WIN,
                _default => {}
            },
            'B' => match round.1 { // Paper
                'X' => score += ROCK + LOSS,
                'Y' => score += PAPER + DRAW,
                'Z' => score += SCISSORS + WIN,
                _default => {}
            },
            'C' => match round.1 { //Scissors
                'X' => score += PAPER + LOSS,
                'Y' => score += SCISSORS + DRAW,
                'Z' => score += ROCK + WIN,
                _default => {}
            },
            _default => {}
        }
    }

    return score;
}
