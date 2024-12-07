using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent_of_code_2024
{
    public class Day7
    {
        public List<long> Solutions = [];
        public List<List<long>> Values = [];
        public List<string> PossibleOperators = ["+", "*", "||"];

        public Day7(string fileName)
        {
            this.ReadInputAndCreateLists(fileName);
        }

        public void SplitLine(string line)
        {
            List<string> lineSections = line.Split(':').ToList();
            Solutions.Add(long.Parse(lineSections[0]));
            Values.Add(Array.ConvertAll(lineSections[1].Split(' ', StringSplitOptions.RemoveEmptyEntries), long.Parse).ToList());
        }

        public void ReadInputAndCreateLists(string fileName)
        {
            StreamReader reader = new StreamReader(@"C:\Workspace\advent_of_code_2024\advent_of_code_2024\inputs\" + fileName);

            try
            {
                do
                {
                    this.SplitLine(reader.ReadLine());
                } while (reader.Peek() != -1);
            }
            catch
            {
                throw new Exception("File is empty!");
            }
            finally
            {
                reader.Close();
            }
        }

        public bool CouldBeTrue(long solution, List<long> values)
        {
            long numberOfOperators = values.Count - 1; 

            List<List<string>> possibleOperators = GeneratePossibleOperators(numberOfOperators);

            foreach (List<string> possibleOperator in possibleOperators) 
            {
                if (EvaluateLine(possibleOperator, values) == solution) return true; 
            }

            return false; 
        }

        public List<List<string>> GeneratePossibleOperators(long length)
        {
            List<List<string>> result = [];
            GeneratePossibleOperatorsRecursive(new List<string>(), length, result);
            return result;
        }

        public void GeneratePossibleOperatorsRecursive(List<string> current, long length, List<List<string>> result)
        {
            if (current.Count == length)
            {
                result.Add(new List<string>(current));
                return;
            }

            foreach (string op in PossibleOperators)
            {
                current.Add(op);
                GeneratePossibleOperatorsRecursive(current, length, result);
                current.RemoveAt(current.Count - 1);
            }
        }

        public long EvaluateLine(List<string> operators, List<long> values)
        {
            int operatorsIndex = 0;
            int valuesIndex = 1; 
            long solution = values[0];
            do
            {
                if (operators[operatorsIndex] == "*") solution *= values[valuesIndex];
                if (operators[operatorsIndex] == "+") solution += values[valuesIndex];
                if (operators[operatorsIndex] == "||")
                {
                    string sol = solution.ToString() + values[valuesIndex].ToString();
                    solution = long.Parse(sol);
                }
                operatorsIndex++;
                valuesIndex++;
            } while (operatorsIndex < operators.Count && valuesIndex < values.Count);
            return solution;
        }

        public long FindTotalCalibration()
        {
            long sum = 0;
            for (int i = 0; i < Values.Count; i++)
            {
                if (CouldBeTrue(Solutions[i], Values[i])) sum += Solutions[i];
            }
            return sum;
        }
    }
}
