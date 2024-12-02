using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent_of_code_2024
{
    public class Day2
    {
        public List<List<int>> Reports = []; //Each line is "report", each value in line is "level"
        public List<bool> AreSafe = [];

        public Day2(string fileName)
        {
           this.ReadFileAndCreateReports(fileName);
        }

        public void ReadFileAndCreateReports(string fileName)
        {
            StreamReader reader = new StreamReader("C:\\Workspace\\advent_of_code_2024\\advent_of_code_2024\\inputs\\" + fileName);

            try
            {
                do
                {
                    List<string> values = reader.ReadLine().Split('\n', StringSplitOptions.RemoveEmptyEntries).ToList();
                    this.Reports.Add((values[0].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList()));
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

        public Boolean IsLevelSafe(List<int> levels)
        {
            Boolean hasIncrease = false;
            Boolean hasDecrease = false;

            for (int i = 0; i < levels.Count - 1; i++)
            {
                if (levels[i] == levels[i + 1]) return false; 
                if (levels[i] < levels[i + 1])
                {
                    if (hasDecrease) return false; 
                    hasIncrease = true;
                } else
                {
                    if (hasIncrease) return false;
                    hasDecrease = true;
                }
            }

            return true; 
        }
    }
}
