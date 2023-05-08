// See https://aka.ms/new-console-template for more information
using Levenshtein;

Console.WriteLine("Hello, World!");

int distance = LevenshteinDistance.Calculate("meier", "meyer");
Console.WriteLine(distance.ToString());