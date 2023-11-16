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
	dat := sum(countSlice(ans))
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
	var group []string
	var result []string
	//cn := make(map[int]int)

	dat := strings.Split(text, "\n")

	for _, i := range dat {
		if i != "" {
			group = append(group, i)
		} else {
			result = append(result, agree(group))
			group = nil
		}
	}
	result = append(result, agree(group))
	return result
}

func agree(text []string) string {
	l := len(text)
	m := make(map[byte]int)
	var res []byte

	for _, s := range text {
		for _, c := range []byte(s) {
			m[c]++
		}
	}

	//fmt.Println(l)

	for k := range m {
		if m[k] == l {
			res = append(res, k)
		}
	}

	return string(res)
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

func countSlice(text []string) []int {
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

func count(text string) int {
	len := 0
	for range []byte(text) {
		len++
	}
	return len
}

func sum(array []int) int {
	result := 0
	for _, v := range array {
		result += v
	}
	return result
}
