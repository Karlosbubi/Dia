package main

import (
	"fmt"
	"io/ioutil"
	"strings"
)

func check(e error) {
	if e != nil {
		panic(e)
	}
}

func main() {

	dat, err := ioutil.ReadFile("d2/t1/input.txt")
	check(err)
	//fmt.Print(string(dat))

	s := strings.Split(string(dat), "\n")
	//fmt.Println(s)
	for _, i := range s {
		fmt.Println(i)
	}
}
