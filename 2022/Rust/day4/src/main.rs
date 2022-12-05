#[derive(Debug, Clone, Copy)]
struct Item {
    start1 : i32,
    end1 : i32,
    start2 : i32,
    end2 : i32
}

fn main() {
    println!("Hello, world!");
    let data = read_input(String::from("./input.txt"));
    println!("{:#?}", task2(data));
}

fn read_input(path : String) -> Vec<Item> {
    let mut result = Vec::new();

    let file = std::fs::read_to_string(path).expect("ERROR: Reading File\n");
    let file = file.trim(); // Deal with trailing new line
    let lines: Vec<&str> = file.split('\n').collect();

    for line in lines {
        let areas : Vec<&str> = line.split(',').collect();
        let area1 : Vec<i32> = areas[0].split("-").map(|s| {s.parse::<i32>().expect("Invalid Iput : not a number")}).take(2).collect();
        let area2 : Vec<i32> = areas[1].split("-").map(|s| {s.parse::<i32>().expect("Invalid Iput : not a number")}).take(2).collect();

        result.push(Item{
            start1: area1[0],
            end1: area1[1],
            start2: area2[0],
            end2: area2[1]
        })
    }
  

    return result;
}

fn task1(input : Vec<Item>) -> i32{
    let mut result = 0;
    for item in input {
        if item.start1 <= item.start2 && item.end1 >= item.end2 {
            result += 1;
        }
        else if item.start2 <= item.start1 && item.end2 >= item.end1 {
            result += 1;
        }
    }
    return result;
}

fn task2(input : Vec<Item>) -> i32{
    let mut result = 0;
    for item in input {
        if !(item.end2 < item.start1 || item.end1 < item.start2) {
            result += 1;
        }
    }
    return result;
}