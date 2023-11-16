fn main() {
    println!("Hello, world!");
    let data = read_input("./input.txt".to_string());

    //println!("{}", task1(data))
    println!("{}", task2(data))
}

fn read_input(path : String) -> String {
    std::fs::read_to_string(path).expect("Erorr reading File").trim().to_string()
}

fn task1(input : String) -> i32 {
    
    let mut a = ' ';
    let mut b = ' ';
    let mut c = ' ';
    let mut d = ' ';
    let mut counter = 1;

    for ch in input.chars() {
        a = b;
        b = c;
        c = d;
        d = ch;

        if  a != b && a != c  && a != d && b != c && b != d && c != d {
            break;
        }
        counter += 1;
    }

    println!("{}-{}-{}-{}", a, b, c, d);

    counter
}

fn task2(input : String) -> i32 {
    let mut result = 1;

    let mut one = ' ';
    let mut two = ' ';
    let mut three = ' ';
    let mut four = ' ';
    let mut five = ' ';
    let mut six = ' ';
    let mut seven = ' ';
    let mut eight = ' ';
    let mut nine = ' ';
    let mut ten = ' ';
    let mut eleven = ' ';
    let mut twelve = ' ';
    let mut thirteen = ' ';
    let mut fourteen = ' ';

    let mut uniqe = false;
    
    for ch in input.chars() {
        one = two;
        two = three;
        three = four;
        four = five;
        five = six;
        six = seven;
        seven = eight;
        eight = nine;
        nine = ten;
        ten = eleven;
        eleven = twelve;
        twelve = thirteen;
        thirteen = fourteen;
        fourteen = ch;

        uniqe = one != two && one != three && one != four && one != five && one != six && one != seven && one != eight && one != nine && one != ten && one != eleven && one != twelve && one != thirteen && one != fourteen;
        uniqe = uniqe && two != three && two != four && two != five && two != six && two != seven && two != eight && two != nine && two != ten && two != eleven && two != twelve && two != thirteen && two != fourteen;
        uniqe = uniqe && three != four && three != five && three != six && three != seven && three != eight && three != nine && three != ten && three != eleven && three != twelve && three != thirteen && three != fourteen;
        uniqe = uniqe && four != five && four != six && four != seven && four != eight && four != nine && four != ten && four != eleven && four != twelve && four != thirteen && four != fourteen;
        uniqe = uniqe && five != six && five != seven && five != eight && five != nine && five != ten && five != eleven && five != twelve && five != thirteen && five != fourteen;
        uniqe = uniqe && six != seven && six != eight && six != nine && six != ten && six != eleven && six != twelve && six != thirteen && six != fourteen;
        uniqe = uniqe && seven != eight && seven != nine && seven != ten && seven != eleven && seven != twelve && seven != thirteen && seven != fourteen;
        uniqe = uniqe && eight != nine && eight != ten && eight != eleven && eight != twelve && eight != thirteen && eight != fourteen;
        uniqe = uniqe && nine != ten && nine != eleven && nine != twelve && nine != thirteen && nine != fourteen;
        uniqe = uniqe && ten != eleven && ten != twelve && ten != thirteen && ten != fourteen;
        uniqe = uniqe && eleven != twelve && eleven != thirteen && eleven != fourteen;
        uniqe = uniqe && twelve != thirteen && twelve != fourteen;
        uniqe = uniqe && thirteen != fourteen;

        if uniqe {
            break;
        }

        result += 1;
    }

    result
}