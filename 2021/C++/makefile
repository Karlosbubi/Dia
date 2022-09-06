tag = all

build :
	@g++ -std=c++17 ./src/AoC.cpp -o ./bin/AoC

run : build
	@./bin/AoC ${tag}

test : 
	@g++ -std=c++17 ./src/tests.cpp -o ./bin/test
	@./bin/test ${tag}

setup :
	cp ./util/template.hpp ./src/${tag}.hpp

clean:
	rm ./bin/*