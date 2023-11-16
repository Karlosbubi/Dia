package main

import (
	"fmt"
	"io/ioutil"
	"strings"
)

func main() {
	text := load("../../Inputs/2020/Day6.txt")
	//fmt.Println(text)
	ans := combine(text)
	fmt.Println(ans)
	dat := sum(count(ans))
	fmt.Println(dat)
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

func combine(text string) []string {
	dat := strings.Split(text, "\n")
	var tmp string
	var group []string
	var result []string

	//fmt.Println("-----")

	for _, s := range dat {

		if s != "" {
			//fmt.Println(s)
			tmp += s
		} else {
			group = append(group, tmp)
			tmp = ""
		}
	}
	group = append(group, tmp)

	for _, i := range group {
		result = append(result, collapse(i))
	}

	return result
}

func collapse(text string) string {
	var list []byte
	keys := make(map[byte]bool)
	for _, entry := range []byte(text) {
		if _, value := keys[entry]; !value {
			keys[entry] = true
			list = append(list, entry)
		}

	}
	return string(list)
}

func count(text []string) []int {
	var result []int

	for _, i := range text {
		len := 0
		for range []byte(i) {
			len++
		}
		result = append(result, len)
	}
	return result
}

func sum(array []int) int {
	result := 0
	for _, v := range array {
		result += v
	}
	return result
}
