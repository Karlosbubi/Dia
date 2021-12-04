import java.io.File
import java.util.*
import kotlin.math.pow

fun main() {
    println("Hello World!")

    Day1("src/main/resources/day1.txt").print()
    Day2("src/main/resources/day2.txt").print()
    Day3("src/main/resources/day3.txt").print()
    Day4("src/main/resources/day4.txt").print()
}

class Day1(private val path: String){
    fun print(){
        println("Day1 :")

        print("Task 1 : ")
        println(task1(readInput()))

        print("Task 2 : ")
        println(task2(readInput()))
    }

    private fun readInput() : Vector<Int> {
        val text : Vector<String> = Vector(File(path).readLines())
        val result : Vector<Int> = Vector()

        for (line in text) {
            result.addElement(line.toInt())
        }

        return result
    }

    private fun task1(input : Vector<Int>) : Int {
        var last = input.firstElement()
        var counter = 0

        for (entry in input) {
            if (entry > last){
                counter++
            }
            last = entry
        }

        return counter
    }

    private fun task2(input: Vector<Int>) : Int {
        var last = input[0] + input[1] + input[2]
        var sum : Int
        var counter = 0

        for (entry in 0 until  input.size - 2){
            sum = input[entry] + input[entry + 1] + input[entry + 2]
            if (sum > last) {
                counter++
            }
            last = sum
        }

        return counter
    }
}

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
        println("Day3 :")

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

class Day4(private val path : String){
    fun print(){
        println("Day4 :")

        print("Task 1 : ")
        println(task1(readInput()))

        print("Task 2 : ")
        println(task2(readInput()))
    }

    private fun readInput(): Pair<Vector<Int>, Vector<Vector<Vector<Int>>>> {
        var text = File(path).readLines()

        val draws = Vector(text.first().split(",").map { it.toInt() })
        text = text.drop(2)

        val boards = Vector<Vector<Vector<Int>>>()
        var board = Vector<Vector<Int>>()

        for (line in text) {
            if (line != "") {
                board.addElement(Vector(line.split(" ").map {it.toIntOrNull()}.filterNotNull()))
            } else if (board.isNotEmpty()) {
                boards.addElement(board)
                board = Vector<Vector<Int>>()
            }
        }
        boards.addElement(board)

//        for (b in boards){
//            println(b)
//        }


        return Pair(draws, boards)
    }

    private fun task1(input : Pair<Vector<Int>, Vector<Vector<Vector<Int>>>>): Int {
        val draws = input.first
        val boards = input.second

        val hitmap = Vector(boards.map { it -> Vector( it.map{ it -> Vector(it.map {
            it == null
        })})})

        for (i in draws){
            for (b in boards){
                for (r in b){
                    for (c in r){
                            hitmap[boards.indexOf(b)][b.indexOf(r)][r.indexOf(c)] = (c == i) || hitmap[boards.indexOf(b)][b.indexOf(r)][r.indexOf(c)]
                    }
                }
            }

            for (h in hitmap){
                //check
                val bingo = check(h)


                //calc
                if (bingo){
                    return score(h, boards[hitmap.indexOf(h)], i)
                }
            }
        }

        return -1
    }

    private fun task2(input : Pair<Vector<Int>, Vector<Vector<Vector<Int>>>>): Int {
        var result = 0

        val draws = input.first
        val boards = input.second

        val hitmap = Vector(boards.map { it -> Vector( it.map{ it -> Vector(it.map {
            it == null
        })})})

        for (i in draws){
            for (b in boards){
                for (r in b){
                    for (c in r){
                        hitmap[boards.indexOf(b)][b.indexOf(r)][r.indexOf(c)] = (c == i) || hitmap[boards.indexOf(b)][b.indexOf(r)][r.indexOf(c)]
                    }
                }

            }

            val dropH = Vector<Vector<Vector<Boolean>>>()
            val dropB = Vector<Vector<Vector<Int>>>()
            var drop = false
            for (h in hitmap){
                val bingo = check(h)

                if (bingo){
                    dropH.addElement(h)
                    dropB.addElement(boards[hitmap.indexOf(h)])
                    drop = true
                }
            }

            if(boards.size == 1 && drop){
                //println("")
                //println(boards)
                //println(hitmap)
                return score(hitmap.lastElement(), boards.lastElement(), i)
            }

            if (drop) {
                boards.removeAll(dropB)
                hitmap.removeAll(dropH)
            }

        }

        return result
    }

    private fun score(hit : Vector<Vector<Boolean>>, board : Vector<Vector<Int>>, multiplyer : Int): Int{
        var result = 0
        for(r in 0..4){
            for(c in 0 .. 4){
                if(!hit[r][c]){
                    result += board[r][c]
                }
            }
        }

        result *= multiplyer
        return  result
    }

    private fun check(board: Vector<Vector<Boolean>>) : Boolean {
        var bingo = false
        for (r in 0..4){
            for (c in 0..4){
                if ((board[r][0] && board[r][1] && board[r][2] && board[r][3] && board[r][4] )|| (board[0][c] && board[1][c] && board[2][c] && board[3][c] && board[4][c])){
                    bingo = true
                }
            }
        }

//      if((h[0][0] && h[1][1] && h[2][2] && h[3][3] && h[4][4]) || (h[4][0]) && h[3][1] && h[2][2] && h[1][3] && h[0][4]){
//           bingo = true
//      }

        return bingo
    }

}
