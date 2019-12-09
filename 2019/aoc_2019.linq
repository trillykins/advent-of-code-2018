<Query Kind="Program" />

void Main()
{
	AOC01();
}

void AOC01()
{
	File.ReadLines(@"C:\Users\mpetersson\Downloads\aoc_01.txt").Select(x => (int.Parse(x) / 3) - 2).Sum().Dump();
}
// Define other methods and classes here
