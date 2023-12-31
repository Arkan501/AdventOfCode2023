﻿using System.Text.RegularExpressions;
using static Day1.FilePath;

namespace Day1;

public class CalDoc
{ 
    private static readonly StreamReader Input = new(InputPath);
    private static readonly StreamWriter Output = new(OutputPath);
    // initializing a variable that will store our solution value
    private static int _solution;
    
    private static readonly Dictionary<string, string> NumDict = 
        new Dictionary<string, string> 
        {
            {"one", "on1e"}, {"two", "tw2o"}, {"three", "thr3ee"},
            {"four", "fo4ur"}, {"five", "fi5ve"}, {"six", "si6x"},
            {"seven", "sev7en"}, {"eight", "eig8ht"}, {"nine", "ni9ne"}
        };
    // method to convert string of numbers into two digit answer the problem has asked for
    private void ReturnSolution(string digits)
    {
        // pulling the first digit out of the old string
        var first = digits[0];
        // pulling last digit out of the old string
        var last = digits[^1];
        // adding both of the pulled digits into a char array
        char[] newDigit = { first, last };
        // converting the char array into a string
        var s = new string(newDigit);
        
        // converting the new string to a number, and adding it to our solution
        _solution += Convert.ToInt32(s);
        // writing the new digit to our output file, because why not
        Output.WriteLine(newDigit);
    }
    
    public static void Main(string[] args)
    {
        // initializing file paths
        
        // pass file path to StreamReader
        
        // reading the first line of the input file
        var line = Input.ReadLine();
        
        // this loop will go through every line of the input file to the end
        while (line != null)
        {
            // replace word numbers with literal
            foreach (var key in NumDict.Keys)
            {
                line = line.Replace(key, NumDict[key]);
            }
            // remove letters from the line being read
            line = Regex.Replace(line, "[^0-9]", "");
            // this method SHOULD return the two digit version of each line
            new CalDoc().ReturnSolution(line);
            // read the next line
            line = Input.ReadLine();
        }
        
        // we need to close both files in order for them to update
        Input.Close();
        Output.Close();
        Console.WriteLine(_solution);
    }
}