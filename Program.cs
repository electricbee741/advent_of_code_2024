﻿// See https://aka.ms/new-console-template for more information

using advent_of_code_2024;

Console.WriteLine("Advent of Code 2024");
Console.WriteLine("-------------------");
Console.WriteLine("\n");

//Day 1
Day1 day1 = new Day1("1_real.txt");

//Console.WriteLine("Puzzle 1: " + day1.FindDifferences());
Console.WriteLine("Puzzle 2: " + day1.FindSimilarityScore());