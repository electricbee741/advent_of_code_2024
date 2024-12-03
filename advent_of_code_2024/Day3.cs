using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace advent_of_code_2024
{
    public class Day3
    {
        readonly string BasePattern = @"mul\(\d+,\d+\)";
        readonly string ConditionalPattern = @"mul\(\d+,\d+\)|do\(\)|don't\(\)";

        public string CorruptedInput = "";
        public List<string> Functions = [];

        public Day3(string fileName)
        {
            this.ReadInput(fileName);
        }

        public void ReadInput(string fileName)
        {
            StreamReader reader = new StreamReader("C:\\Workspace\\advent_of_code_2024\\advent_of_code_2024\\inputs\\" + fileName);

            try
            {
                this.CorruptedInput = reader.ReadToEnd();
            }
            catch
            {

                throw new Exception("File is empty!");
            }
        }

        public void CleanInput(string pattern)
        {
            MatchCollection matches = Regex.Matches(this.CorruptedInput, pattern);

            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    this.Functions.Add(match.Value);
                }
            }

        }

        public int Mul(string function)
        {
            int x = 0;
            int y = 0;
            
            string pattern = @"\d+";
            MatchCollection matches = Regex.Matches(function, pattern);

            if (matches.Count >= 2)
            {
                x = Int32.Parse(matches[0].Value);
                y = Int32.Parse(matches[1].Value);
            }

            return x * y; 
        }

        public int FindSum()
        {
            this.CleanInput(this.BasePattern);

            int sum = 0;

            foreach (var function in Functions)
            {
                sum += this.Mul(function);
            }

            return sum;
        }

        public int FindSumWithConditionals()
        {
            this.CleanInput(this.ConditionalPattern);

            int sum = 0;
            Boolean areSkipping = false; 

            foreach (var function in Functions)
            {
                if (Regex.IsMatch(function, @"do\(\)"))
                {
                    areSkipping = false;
                } else if (Regex.IsMatch(function, @"don't\(\)"))
                {
                    areSkipping = true;
                } else if (!areSkipping)
                {
                    sum += this.Mul(function);
                }
            }

            return sum;
        }
    }
}
