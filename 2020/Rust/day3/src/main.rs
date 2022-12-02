fn main() {
    println!("Hello, world!");
    println!("t1 = {}", solve_t1());
    println!("t2 = {}", solve_t2());
}

fn read_input(path: String) -> Vec<String> {
    let file = std::fs::read_to_string(path).unwrap();
    file.split('\n')
        //.take(20)
        .map(|line| line.to_string())
        .collect()
}

fn go_slope(x: i32, y: i32, data: Vec<String>) -> i32 {
    let line_length: i32 = (data[0].len()).try_into().unwrap();
    let lines: i32 = (data.len() - 1).try_into().unwrap();

    let mut position_x: i32 = 0;
    let mut position_y: i32 = 0;
    let mut counter = 0;

    loop {
        if data
            .iter()
            .nth(position_y.try_into().unwrap())
            .unwrap()
            .chars()
            .nth(position_x.try_into().unwrap())
            .unwrap()
            == '#'
        {
            counter += 1;
            //println!("line {}, column {} was a tree", position_y, position_x);
        } else {
            //println!("line {}, column {} was no tree", position_y, position_x);
        }
        position_x += x;
        position_y += y;

        if position_y > lines {
            break;
        }

        if position_x >= line_length {
            position_x -= line_length;
        }
    }

    return counter;
}

fn solve_t1() -> i32 {
    go_slope(3, 1, read_input("input/input.txt".to_string()))
}

fn solve_t2() -> i64 {
    let input = read_input("input/input.txt".to_string());
    let mut result: i64 = 1;

    result = result * i64::from(go_slope(1, 1, input.clone()));
    result = result * i64::from(go_slope(3, 1, input.clone()));
    result = result * i64::from(go_slope(5, 1, input.clone()));
    result = result * i64::from(go_slope(7, 1, input.clone()));

    result * i64::from(go_slope(1, 2, input))
}

#[test]
fn day3_solution_task1() {
    assert_eq!(solve_t1(), 211);
}
#[test]
fn day3_solution_task2() {
    assert_eq!(solve_t2(), 3584591857);
}
