using System.Text.RegularExpressions;
using static Day1.FilePath;

namespace Day1;

public class CalDoc
{ 
    
    static StreamWriter output = new(OutputPath);
    // initializing a variable that will store our solution value
    static int solution  = 0;
    
    private static Dictionary<string, int> numTable = 
        new Dictionary<string, int> 
        {
            {"one", 1}, {"two", 2}, {"three", 3},
            {"four", 4}, {"five", 5}, {"six", 6},
            {"seven", 7}, {"eight", 8}, {"nine", 9}
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
        string s = new string(newDigit);
        
        // converting the new string to a number, and adding it to our solution
        solution += Convert.ToInt32(s);
        // writing the new digit to our output file, because why not
        output.WriteLine(newDigit);
    }
    
    public static void Main(string[] args)
    {
        // initializing file paths
        
        // pass file path to StreamReader
        StreamReader input = new StreamReader(InputPath);
        
        // reading the first line of the input file
        var line = input.ReadLine();
        
        // this loop will go through every line of the input file to the end
        while (line != null)
        {
            // replace word numbers with literal
            line = Regex.Replace(line, numTable,);
            // remove letters from the line being read
            line = Regex.Replace(line, "[A-Za-z]", "");
            // this method SHOULD return the two digit version of each line
            new CalDoc().ReturnSolution(line);
            // read the next line
            line = input.ReadLine();
        }
        
        // we need to close both files in order for them to update
        input.Close();
        output.Close();
        Console.WriteLine(solution);
    }
}