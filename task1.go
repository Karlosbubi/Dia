package main

import "fmt"

func check(e error) {
    if e != nil {
        panic(e)
    }
}

func main(){

	dat, err := ioutil.ReadFile("task1-input.txt")
    check(err)
    fmt.Print(string(dat))

}