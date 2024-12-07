using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent_of_code_2024
{
    public class Day6
    {
        readonly public char UP = '^';
        readonly public char DOWN = 'v';
        readonly public char LEFT = '<';
        readonly public char RIGHT = '>';
        readonly public char OBSTACLE = '#';

        public List<List<char>> Grid = [];
        public List<int[]> DistinctPositions = [];
        public List<int[]> Obstacles = []; 

        public int[] GuardPos = [-1, -1];
        public char GuardDir = '0';
        public bool HasExited = false;

        public List<int[]> turnPositions = [];
        public List<char> turns = [];

        public Day6(string fileName)
        {
            this.ReadInputAndCreateGrid(fileName);
            this.FindGuard();
            this.FindObstacles();
        }

        public void ReadInputAndCreateGrid(string fileName)
        {
            StreamReader reader = new StreamReader(@"C:\Workspace\advent_of_code_2024\advent_of_code_2024\inputs\" + fileName);

            try
            {
                do
                {
                    this.Grid.Add(reader.ReadLine().ToCharArray().ToList());
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

        public int[] FindGuard()
        {
            for (int x = 0; x < this.Grid.Count; x++)
            {
                for (int y = 0; y < this.Grid[x].Count; y++)
                {
                    if (this.Grid[x][y] == UP || this.Grid[x][y] == DOWN || this.Grid[x][y] == LEFT || this.Grid[x][y] == RIGHT)
                    {
                        GuardDir = this.Grid[x][y];
                        GuardPos[0] = x;
                        GuardPos[1] = y;
                        return GuardPos; 
                    }
                }
            }

            return GuardPos; 
        }

        public void AddDistinctPosition(int[] pos)
        {
            for (int x = 0; x < DistinctPositions.Count; x++)
            {
                if (DistinctPositions[x][0] == pos[0] && DistinctPositions[x][1] == pos[1]) return; 
            }
            DistinctPositions.Add(pos);
        }

        public void FindObstacles()
        {
            for (int x = 0; x < this.Grid.Count; x++)
            {
                for (int y = 0; y < this.Grid[x].Count; y++)
                {
                    if (this.Grid[x][y] == OBSTACLE)
                    {
                        Obstacles.Add([x, y]); 
                    }
                }
            }
        }

        public bool IsObstacle(int[] pos)
        {
            return Obstacles.Any(arr => arr.SequenceEqual(pos));
        }

        public bool IsOffscreen(int[] pos)
        {
            if (pos[0] < 0 || pos[0] > Grid.Count || pos[1] < 0 || pos[1] > Grid[0].Count) return true;
            return false; 
        }

        public int[] FindNextPosition()
        {
            if (GuardDir == UP)
            {
                return [GuardPos[0] - 1, GuardPos[1]];
            }
            else if (GuardDir == DOWN)
            {
                return [GuardPos[0] + 1, GuardPos[1]];
            }
            else if (GuardDir == LEFT)
            {
                return [GuardPos[0],  GuardPos[1] - 1];
            }
            else if (GuardDir == RIGHT)
            {
                return [GuardPos[0], GuardPos[1] + 1];
            }
            return [-1, -1];
        }

        public void Turn()
        {
            if (GuardDir == UP)
            {
                GuardDir = RIGHT;
            }
            else if (GuardDir == DOWN)
            {
                GuardDir = LEFT;
            }
            else if (GuardDir == LEFT)
            {
                GuardDir = UP;
            }
            else if (GuardDir == RIGHT)
            {
                GuardDir = DOWN;
            }
        }

        public int Move()
        {
            do
            {
                int[] nextPos = FindNextPosition();
                if (this.IsOffscreen(nextPos))
                {
                    HasExited = true;
                }
                else if (this.IsObstacle(nextPos))
                {
                    turnPositions.Add(GuardPos);
                    turns.Add(GuardDir);
                    Turn();
                } else
                {
                    AddDistinctPosition(GuardPos);
                    GuardPos = nextPos;
                }

            } while (!HasExited);

            return DistinctPositions.Count;
        }

        public bool IsALoop(int[] testPos)
        {
            HasExited = false;
            this.FindGuard();
            turnPositions.Clear();
            DistinctPositions.Clear();
            turns.Clear();

            do
            {
                int[] nextPos = FindNextPosition();
                if (this.IsOffscreen(nextPos))
                {
                    HasExited = true;
                }
                else if (this.IsObstacle(nextPos) || (nextPos[0] == testPos[0] && nextPos[1] == testPos[1]))
                {
                    for (int i = 0; i < turnPositions.Count; i++)
                    {
                        if (turnPositions[i][0] == GuardPos[0] && turnPositions[i][1] == GuardPos[1] && turns[i] == GuardDir)
                        {
                            return true;
                        }
                    }
                    turnPositions.Add(GuardPos);
                    turns.Add(GuardDir);
                    Turn();
                }
                else
                {
                    AddDistinctPosition(GuardPos);
                    GuardPos = nextPos;
                }

            } while (!HasExited);

            return false; 
        }

        public int AddObstacles()
        {
            int sum = 0; 

            for (int x = 0; x < Grid.Count; x++)
            {
                for (int y = 0; y < Grid[x].Count; y++)
                {
                    if (!this.IsObstacle([x, y]))
                    {
                        if (this.IsALoop([x, y])) sum++;
                    }
                }
            }

            return sum;
        }
    }
}
