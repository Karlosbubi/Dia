package main

import (
	"fmt"
	"io/ioutil"
	"strings"
)

type passport struct {
	byr int    //(Birth Year)
	iyr int    //(Issue Year)
	eyr int    //(Expiration Year)
	hgt int    //(Height)
	hcl string //(Hair Color)
	ecl string //(Eye Color)
	pid int64  //(Passport ID)
	cid string //(Country ID)
}

func check(e error) {
	if e != nil {
		panic(e)
	}
}

func replaceAtIndex(in string, r rune, i int) string {
	out := []rune(in)
	out[i] = r
	return string(out)
}

func stringToPassport(s string) passport {
	p := passport{byr: 0,
		iyr: 0,
		eyr: 0,
		hgt: 0,
		hcl: "",
		ecl: "",
		pid: 0,
		cid: ""}

	//byr:%v iyr:%v eyr:%v {hgt:%vcm hgt:%vin} hcl:%v ecl:%v pid:%v cid:%v

	return p
}

func checkPassport(p passport) bool {
	if p.byr == 0 {
		return false
	}
	if p.iyr == 0 {
		return false
	}
	if p.eyr == 0 {
		return false
	}
	if p.hgt == 0 {
		return false
	}
	if p.hcl == "" {
		return false
	}
	if p.ecl == "" {
		return false
	}
	if p.pid == 0 {
		return false
	}
	return true
}

func main() {

	dat, err := ioutil.ReadFile("d4/t1/input.txt")
	check(err)

	//fmt.Println(string(dat))

	s := strings.Split(string(dat), "\n")
	k := ""
	for i := 0; i < len(s); i++ {
		for s[i] != "" {
			k += s[i]
			i++
		}
		fmt.Println(k)
		k = ""
	}

	//fmt.Println(s)
}
