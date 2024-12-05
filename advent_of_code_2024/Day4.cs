using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace advent_of_code_2024
{
    public class Day4
    {
        public List<string> Rows = [];
        public int WordsFound = 0;
        public string Pattern = "XMAS";

        public Day4(string fileName)
        {
            this.ReadFileAndCreateRows(fileName);
        }

        public int FindWordCount()
        {
            int count = 0;

            foreach (string row in Rows)
            {
                count += this.FindHorizontalForward(row);
                count += this.FindHorizontalBackwards(row);
            }

            count += this.FindVerticalForward();
            count += this.FindVerticalBackwards();
            count += this.FindDiagonalDownForward();
            count += this.FindDiagonalDownBackwards();
            count += this.FindDiagonalUpForward();
            count += this.FindDiagonalUpBackwards();

            return count; 
        }

        public void ReadFileAndCreateRows(string fileName)
        {
            StreamReader reader = new StreamReader(@"C:\Workspace\advent_of_code_2024\advent_of_code_2024\inputs\" + fileName);

            try
            {
                do
                {
                    List<String> values = reader.ReadLine().Split('\n').ToList();
                    this.Rows.Add(values[0]);
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

        public int FindHorizontalForward(string row)
        {
            MatchCollection matches = Regex.Matches(row, this.Pattern); 

            return matches.Count;
        }

        public int FindHorizontalBackwards(string row)
        {
            char[] patternArr = this.Pattern.ToCharArray();
            Array.Reverse(patternArr);
            string patternReversed = new string(patternArr);
            
            MatchCollection matches = Regex.Matches(row, patternReversed);

            return matches.Count;
        }

        public int FindVerticalForward()
        {
            int count = 0;

            for (int row = 0; row + 3 < Rows.Count; row++)
            {
                char[] rowArr = Rows[row].ToCharArray();
                for (int col = 0; col < rowArr.Length; col++)
                {
                    if (this.Rows[row][col] == 'X' && this.Rows[row + 1][col] == 'M' && this.Rows[row + 2][col] == 'A' && this.Rows[row + 3][col] == 'S') count++;
                }
            }

            return count;
        }

        public int FindVerticalBackwards()
        {
            int count = 0;

            for (int row = Rows.Count - 1; row - 3 >= 0; row--)
            {
                char[] rowArr = Rows[row].ToCharArray();
                for (int col = rowArr.Length - 1; col >= 0; col--)
                {
                    if (this.Rows[row][col] == 'X' && this.Rows[row - 1][col] == 'M' && this.Rows[row - 2][col] == 'A' && this.Rows[row - 3][col] == 'S') count++;
                }
            }

            return count;
        }

        public int FindDiagonalDownForward()
        {
            int count = 0;

            for (int row = 0; row + 3 < Rows.Count; row++)
            {
                char[] rowArr = Rows[row].ToCharArray();
                for (int col = 0; col + 3 < rowArr.Length; col++)
                {
                    if (this.Rows[row][col] == 'X' && this.Rows[row + 1][col + 1] == 'M' && this.Rows[row + 2][col + 2] == 'A' && this.Rows[row + 3][col + 3] == 'S') count++;
                }
            }

            return count;
        }

        public int FindDiagonalDownBackwards()
        {
            int count = 0;

            for (int row = Rows.Count - 1; row - 3 >= 0; row--)
            {
                char[] rowArr = Rows[row].ToCharArray();
                for (int col = rowArr.Length - 1; col - 3 >= 0; col--)
                {
                    if (this.Rows[row][col] == 'X' && this.Rows[row - 1][col - 1] == 'M' && this.Rows[row - 2][col - 2] == 'A' && this.Rows[row - 3][col - 3] == 'S') count++;
                }
            }

            return count;
        }

        public int FindDiagonalUpForward()
        {
            int count = 0;

            for (int row = 0; row + 3 < Rows.Count; row++)
            {
                char[] rowArr = Rows[row].ToCharArray();
                for (int col = rowArr.Length - 1; col - 3 >= 0; col--)
                {
                    if (this.Rows[row][col] == 'X' && this.Rows[row + 1][col - 1] == 'M' && this.Rows[row + 2][col - 2] == 'A' && this.Rows[row + 3][col - 3] == 'S') count++;
                }
            }

            return count;
        }

        public int FindDiagonalUpBackwards()
        {
            int count = 0;

            for (int row = Rows.Count - 1; row - 3 >= 0; row--)
            {
                char[] rowArr = Rows[row].ToCharArray();
                for (int col = 0; col + 3 < rowArr.Length; col++)
                {
                    if (this.Rows[row][col] == 'X' && this.Rows[row - 1][col + 1] == 'M' && this.Rows[row - 2][col + 2] == 'A' && this.Rows[row - 3][col + 3] == 'S') count++;
                }
            }

            return count;
        }

        public int FindMasX()
        {
            int count = 0;

            for (int row = 1; row < this.Rows.Count - 1; row++)
            {
                for (int col = 1; col < this.Rows[row].Length - 1; col++)
                {
                    if (this.Rows[row][col] == 'A')
                    {
                        int validxs = 0; 
                        if (this.Rows[row - 1][col - 1] == 'M' && this.Rows[row + 1][col + 1] == 'S') validxs++;
                        if (this.Rows[row - 1][col - 1] == 'S' && this.Rows[row + 1][col + 1] == 'M') validxs++;
                        if (this.Rows[row - 1][col + 1] == 'M' && this.Rows[row + 1][col - 1] == 'S') validxs++;
                        if (this.Rows[row - 1][col + 1] == 'S' && this.Rows[row + 1][col - 1] == 'M') validxs++;
                        if (validxs == 2) count++;
                    }
                }
            }

            return count; 
        }
    }
}
