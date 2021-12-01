import java.io.File
import java.util.*

fun main() {
    println("Hello World!")

    Day2("./src/main/resources/day2.txt").print()
}


private class Day1(val path: String) {

    fun print() {
        println(task1(input()))
        println(task2(input()))
    }

    fun input(): Vector<Int> {
        return Vector(File(path).readLines().map { it.toInt() })
    }


    fun task1(input: Vector<Int>): Int {
        for (a in input) {
            for (b in input) {
                if (a + b == 2020) {
                    return a * b
                }
            }
        }
        return 0
    }

    fun task2(input: Vector<Int>): Int {
        for (a in input) {
            for (b in input) {
                for (c in input) {
                    if (a + b + c == 2020) {
                        return a * b * c
                    }
                }
            }
        }

        return 0
    }
}

private class Day2(val path: String){
    fun print() {
        println(task1(input()))
        println(task2(input()))
    }

    class password(val a : Int, b : Int, key : Char, line : String)

    fun input(): Vector<password> {
        val file = File(path).readLines().toString().trim()
        val result = Vector<password>()
        for (s in file){

        }
        return result
    }

    fun task1(input : Vector<password>) : Int {
        var result = 0
        for (p in input) {
            var valid = false

            if(valid){
                result++
            }
        }
        return result
    }

    fun task2(input: Vector<password>) : Int {
        var result = 0
        for (p in input) {
            var valid = false

            if(valid){
                result++
            }
        }
        return result
    }
}