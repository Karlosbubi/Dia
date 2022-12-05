fn main() {
    println!("Hello, world!");
    let data = read_input("./input.txt".to_string());
    println!("{}", task2(data))
}

fn read_input(path: String) -> Vec<String> {
    let file = std::fs::read_to_string(path).expect("ERROR: Reading File\n");
    let file = file.trim().to_string(); // Deal with trailing new line

    file.split('\n').map(|s| s.to_string()).collect()
}

fn priority(input: char) -> i32 {
    // Fuktion der Schande
    match input {
        'a' => 1,
        'b' => 2,
        'c' => 3,
        'd' => 4,
        'e' => 5,
        'f' => 6,
        'g' => 7,
        'h' => 8,
        'i' => 9,
        'j' => 10,
        'k' => 11,
        'l' => 12,
        'm' => 13,
        'n' => 14,
        'o' => 15,
        'p' => 16,
        'q' => 17,
        'r' => 18,
        's' => 19,
        't' => 20,
        'u' => 21,
        'v' => 22,
        'w' => 23,
        'x' => 24,
        'y' => 25,
        'z' => 26,
        'A' => 27,
        'B' => 28,
        'C' => 29,
        'D' => 30,
        'E' => 31,
        'F' => 32,
        'G' => 33,
        'H' => 34,
        'I' => 35,
        'J' => 36,
        'K' => 37,
        'L' => 38,
        'M' => 39,
        'N' => 40,
        'O' => 41,
        'P' => 42,
        'Q' => 43,
        'R' => 44,
        'S' => 45,
        'T' => 46,
        'U' => 47,
        'V' => 48,
        'W' => 49,
        'X' => 50,
        'Y' => 51,
        'Z' => 52,
        _ => 0,
    }
}

fn task1(input: Vec<String>) -> i32 {
    let mut result = 0;
    for line in input {
        let len = line.len();
        let compartment1: String = line.clone().drain(..(len / 2)).collect();
        let compartment2: String = line.clone().drain((len / 2)..len).collect();

        for item in compartment1.chars() {
            if compartment2.contains(item) {
                //println!("{} - {} : {}", compartment1, compartment2, item);
                result += priority(item);
                break;
            }
        }
        //println!("{} - {}", compartment1, compartment2);
    }
    return result;
}

fn task2(input: Vec<String>) -> i32 {
    let mut result = 0;

    let groups : Vec<Vec<String>>= input.chunks(3).map(|s| s.into()).collect();

    for group in groups {
        for item in group[0].chars() {
            if group[1].contains(item) && group[2].contains(item){
                result += priority(item);
                break;
            }
        }
    }
    
    return result;
}
