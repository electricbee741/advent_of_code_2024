using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace advent_of_code_2024
{
    public class Day5
    {
        public List<int[]> Rules = [];
        public List<List<int>> PagesToPrint = [];
        
        public Day5() { }
        
        public Day5(string fileName)
        {
            this.ReadFileAndParse(fileName);
        }

        public void ReadFileAndParse(string fileName)
        {
            StreamReader reader = new StreamReader(@"C:\Workspace\advent_of_code_2024\advent_of_code_2024\inputs\" + fileName);
            bool hasReachedEndOfRules = false; 

            try
            {
                do
                {
                    if (!hasReachedEndOfRules)
                    {
                        string line = reader.ReadLine();
                        if (line != "")
                        {
                            this.ParseRule(line);
                        } else
                        {
                            hasReachedEndOfRules = true; 
                        }
                    } else
                    {
                        this.ParsePagesToPrint(reader.ReadLine());
                    }
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

        public void ParseRule(string rule)
        {
            string[] values = rule.Split('|').ToArray();
            int[] intValues = Array.ConvertAll(values, int.Parse);
            this.Rules.Add(intValues);
        }

        public void ParsePagesToPrint(string  pagesToPrint)
        {
            string[] pages = pagesToPrint.Split(",").ToArray();
            List<int> intPages = Array.ConvertAll(pages, int.Parse).ToList();
            this.PagesToPrint.Add(intPages);
        }

        public bool ArePagesValid(List<int> pages)
        {
            bool arePagesValid = true;

            foreach (int[] rule in this.Rules)
            {
                if (pages.Contains(rule[0]))
                {
                    bool firstValFound = false; 
                    foreach (int page in pages)
                    {
                        if (page == rule[0]) firstValFound = true;
                        if (page == rule[1] && !firstValFound) return false; 
                    }
                }
            }

            return arePagesValid;
        }

        public int FindSumOfValidMiddlePages()
        {
            int sum = 0;

            foreach (List<int> pages in this.PagesToPrint)
            {
                if (this.ArePagesValid(pages)) sum += pages[pages.Count / 2];
            }

            return sum;
        }

        public List<int> FixPagesToBePrintedRecursion(List<int> pages)
        {
            if (this.ArePagesValid(pages)) return pages;

            foreach (int[] rule in this.Rules)
            {
                if (pages.Contains(rule[0]))
                {
                    bool firstValFound = false;
                    for (int i = 0; i < pages.Count; i++) 
                    {
                        if (pages[i] == rule[0]) firstValFound = true;
                        if (pages[i] == rule[1] && !firstValFound)
                        {
                            int badNum = pages[i];
                            pages.RemoveAt(i);
                            if (i == pages.Count - 1)
                            {
                                pages.Insert(0, badNum);
                            } else
                            {
                                pages.Insert(i + 1, badNum);
                            }
                            if (this.ArePagesValid(pages)) return pages; 
                            this.FixPagesToBePrintedRecursion(pages);
                        }
                    }
                }
            }

            return pages;
        }

        public List<int> FixPagesToBePrinted(List<int> pages)
        {
            do
            {
                foreach (int[] rule in this.Rules)
                {
                    if (pages.Contains(rule[0]) && pages.Contains(rule[1]) && pages.IndexOf(rule[0]) > pages.IndexOf(rule[1]))
                    {
                        pages.RemoveAt(pages.IndexOf(rule[0]));
                        pages.Insert(pages.IndexOf(rule[1]), rule[0]);
                        if (this.ArePagesValid(pages)) return pages;
                    }
                }
            } while (!this.ArePagesValid(pages));

            return pages; 
        }

        public int FindSumOfInvalidMiddlePagesRecursion()
        {
            int sum = 0;

            foreach (List<int> pages in this.PagesToPrint)
            {
                if (!this.ArePagesValid(pages))
                {
                    sum += this.FixPagesToBePrintedRecursion(pages)[pages.Count / 2];
                }
            }

            return sum;
        }

        public int FindSumOfInvalidMiddlePages()
        {
            int sum = 0;

            foreach (List<int> pages in this.PagesToPrint)
            {
                if (!this.ArePagesValid(pages))
                {
                    sum += this.FixPagesToBePrinted(pages)[pages.Count / 2];
                }
            }

            return sum;
        }
    }
}
