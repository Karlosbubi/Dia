#[derive(Debug, Clone, Copy)]
struct Move {
    from : i32,
    to : i32,
    quantity : i32
}
#[derive(Debug, Clone)]
struct Input {
    stacks : Vec<Vec<i32>>,
    instructions : Vec<Move>
}

fn main() {
    let data = read_input("./input.txt".to_string());
    println!("{:#?}", data);
}

fn read_input(path : String) -> Input {
    let mut stack = Vec::new();
    let mut moves = Vec::new();

    // TODO Split of Header with Stack layout

    // TODO Parse Satck Layout

    // TODO Parse Instructions

    Input { stacks: stack, instructions: moves }
}

