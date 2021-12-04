import java.io.File
import java.util.*
import kotlin.math.pow

fun main() {
    println("Hello World!")

    //Day1("src/main/resources/day1.txt").print() TODO
    Day2("src/main/resources/day2.txt").print()
    Day3("src/main/resources/day3.txt").print()
}

//class Day1(private val path: String){} TODO

class Day2(private val path : String){

    fun print(){
        println("Day2 :")

        print("Task 1 : ")
        println(task1(readInput()))

        print("Task 2 : ")
        println(task2(readInput()))
    }

    private fun readInput() : Vector<Pair<String, Int>> {
        val text : Vector<String> = Vector(File(path).readLines())
        val result : Vector<Pair<String, Int>> = Vector<Pair<String, Int>>()

        for (line in text) {
            val entry = line.split(" ")
            if(entry.isNotEmpty()) {
                result.addElement(Pair(entry.first(), entry.last().toInt()))
            }
        }

        return result
    }

    private fun task1(input : Vector<Pair<String, Int>>) : Int{
        var depth = 0
        var horizontal = 0

        for (entry in input){
            when(entry.first){
                "forward" -> horizontal += entry.second
                "down" -> depth += entry.second
                "up" -> depth -= entry.second
            }
        }

        //val coords = Pair(horizontal, depth)

        return horizontal * depth
    }

    private fun task2(input : Vector<Pair<String, Int>>) : Int {
        var depth = 0
        var horizontal = 0
        var aim = 0

        for (entry in input){
            when(entry.first){
                "forward" -> {
                    horizontal += entry.second
                    depth += aim * entry.second
                }
                "down" -> aim += entry.second
                "up" -> aim -= entry.second
            }
        }


        return horizontal * depth
    }
}

class Day3(private val path : String){
    fun print(){
        println("Day2 :")

        print("Task 1 : ")
        println(task1(readInput()))

        print("Task 2 : ")
        println(task2(readInput()))
    }

    private fun readInput() : Vector<Array<Boolean>> {
        val text : Vector<String> = Vector(File(path).readLines())
        val result : Vector<Array<Boolean>> = Vector<Array<Boolean>>()

        for (line in text){
            result.addElement(line.toCharArray().map { when (it) {'1' -> true ; else -> false} }.toTypedArray())
        }

        return result
    }

    private fun binToDec(bin : Array<Boolean>) : Int {
        //val result = bin.mapIndexed(when (element) { true -> 2.0.pow(index.toDouble()).toInt() ; else -> 0}).sum()
        bin.reverse()
        var result = 0
        for(i in bin.indices){
            when (bin[i]){
                true -> result += 2.0.pow(i.toDouble()).toInt()
            }
        }

        return result
    }

    private fun task1(input: Vector<Array<Boolean>>) : Int {
//        println()
        val len = input.size
        val histo : MutableMap<Int, Int> = mutableMapOf<Int, Int>().toSortedMap()
        //val len = input.firstElement().size

        //println(len)
        for (entry in input) {
//            println(entry.map {it.toString()})
            for (i in entry.indices) {
                if (entry[i]) {
                    when (val count = histo[i])
                    {
                        null -> histo[i] = 1
                        else -> histo[i] = count + 1
                    }
                }
            }
            //println(histo)
        }


        val gamma = histo.map{ (it.value < (len/2)) }.toTypedArray()
        val epsilon = gamma.map { !it }.toTypedArray()

//        println(histo.values)
//        println(gamma.map {it.toString()})
//        println(binToDec(gamma))
//        println(epsilon.map {it.toString()})
//        println(binToDec(epsilon))

        return binToDec(gamma) * binToDec(epsilon)
    }

    private fun task2(input: Vector<Array<Boolean>>) : Int {
        val len = input.firstElement().size

        var o2 = input.firstElement()
        var co2 = input.firstElement()

        var data = input

        var one = Vector<Array<Boolean>>()
        var zero = Vector<Array<Boolean>>()

        for (i in 0 until len){
            for (entry in data) {
                if (entry[i]){
                    one.addElement(entry)
                }
                else{
                    zero.addElement(entry)
                }
            }
            data = if (one.size >= zero.size){
                one
            } else {
                zero
            }
            one = Vector<Array<Boolean>>()
            zero = Vector<Array<Boolean>>()

            if (data.size == 1){
                o2 = data.firstElement()
                break
            }
        }

        data = input

        for (i in 0 until len){
            for (entry in data) {
                if (entry[i]){
                    one.addElement(entry)
                }
                else{
                    zero.addElement(entry)
                }
            }
            data = if (one.size < zero.size){
                one
            } else {
                zero
            }
            one = Vector<Array<Boolean>>()
            zero = Vector<Array<Boolean>>()

            if (data.size == 1){
                co2 = data.firstElement()
                break
            }
        }

        return binToDec(o2) * binToDec(co2)
    }
}