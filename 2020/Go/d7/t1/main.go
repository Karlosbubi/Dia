package main

import (
	"fmt"
	"io/ioutil"
)

func main() {
	fmt.Println(load("../../Inputs/2020/Day7.txt"))
}

func check(e error) {
	if e != nil {
		panic(e)
	}
}

func load(path string) string {
	dat, err := ioutil.ReadFile(path)
	check(err)
	return string(dat)
}
