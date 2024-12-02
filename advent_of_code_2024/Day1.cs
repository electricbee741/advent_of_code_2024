using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent_of_code_2024
{
    public class Day1
    {
        public List<int> FirstColumn {  get; set; } = new List<int>();
        public List<int> SecondColumn { get; set; } = new List<int>();
        public List<int> Differences { get; set; } = new List<int>();

        public Day1() { }
        public Day1(string fileName) 
        {
            this.ReadFileAndCreateLists(fileName);
        }

        public void ReadFileAndCreateLists(string fileName)
        {
            StreamReader reader = new StreamReader("C:\\Workspace\\advent_of_code_2024\\inputs\\" + fileName);

            try
            {
                do
                {
                    string[] values = reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    FirstColumn.Add(Int32.Parse(values[0]));
                    SecondColumn.Add(Int32.Parse(values[1]));
                }
                while (reader.Peek() != -1);
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

        public int FindDifferences()
        {
            this.FirstColumn.Sort();
            this.SecondColumn.Sort();

            for (int i = 0; i < FirstColumn.Count; i++)
            {
                this.Differences.Add(Math.Abs(FirstColumn[i] - SecondColumn[i]));
            }

            return this.Differences.Sum();
        }

        public int FindSimilarityScore()
        {
            int score = 0;

            foreach (int id in FirstColumn)
            {
                score += id * this.SecondColumn.Count(val => val == id);
            }

            return score;
        }
    }
}
