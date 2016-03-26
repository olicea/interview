using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsTests
{
    [TestClass]
    public class RobotInGrid
    {
        [TestMethod]
        public void RobotInGrid_Test()
        {
            // Initialize the grid
            int[][] grid = new int[][]
                {
                    new int[] {0,0,0,0,0 },
                    new int[] {0,1,0,1,0 },
                    new int[] {0,1,1,0,0 },
                    new int[] {0,0,0,0,0 },
                    new int[] {0,0,0,1,0 }
                };
            List<Path> expectedSolutions = new List<Path>();
            Path p = new Path();
            p.Add(0, 0);
            p.Add(0, 1);
            p.Add(0, 2);
            p.Add(0, 3);
            p.Add(0, 4);
            p.Add(1, 4);
            p.Add(2, 4);
            p.Add(3, 4);
            p.Add(4, 4);
            expectedSolutions.Add(p);
            p = new Path();
            p.Add(0, 0);
            p.Add(1, 0);
            p.Add(2, 0);
            p.Add(3, 0);
            p.Add(3, 1);
            p.Add(3, 2);
            p.Add(3, 3);
            p.Add(3, 4);
            p.Add(4, 4);
            expectedSolutions.Add(p);

            // the algorithm will populate this list
            List<Path> paths = new List<Path>();

            FindPaths(grid, paths);
            Assert.AreEqual(2, paths.Count);
            Assert.IsTrue(paths[0].Equals(expectedSolutions[0]));
            Assert.IsTrue(paths[1].Equals(expectedSolutions[1]));
        }

        private void FindPaths(int[][] grid, List<Path> paths)
        {
            FindPaths(grid, 0, 0, new Path(), paths);
        }

        private void FindPaths(int[][] grid, int r, int c, Path path, List<Path> paths)
        {
            int length = path.Count;
            path.Add(r, c);
            if (r == grid.Length - 1 && c == grid[0].Length - 1)
            {
                //we reached the end, add this path as a solution
                paths.Add(new Path(path));
            }
            else
            {
                if (c + 1 < grid[r].Length && grid[r][c + 1] == 0)
                {
                    FindPaths(grid, r, c + 1, path, paths);
                }
                if (r + 1 < grid.Length && grid[r + 1][c] == 0)
                {
                    FindPaths(grid, r + 1, c, path, paths);
                }
            }

            path.Remove(r, c);
            Assert.AreEqual(length, path.Count, "remove did not remove the last item");
        }

        class Path : List<Coordinate>
        {
            public Path() { }
            public Path(Path p) : this()
            {
                p.ForEach(c => Add(c));
            }

            public void Add(int r, int c)
            {
                base.Add(new Coordinate(r, c));
            }

            public void Remove(int r, int c)
            {
                this.RemoveAll(x => x.Row == r && x.Column == c);
            }

            public override string ToString()
            {
                return string.Join("->", this.Select(t => t.Row + "," + t.Column));
            }

            public bool Equals(Path p)
            {
                if (p.Count != this.Count)
                    return false;
                for (int i = 0; i < Count; i++)
                {
                    if (this[i].Row != p[i].Row ||
                        this[i].Column != p[i].Column)
                        return false;
                }
                return true;
            }
        }

        class Coordinate
        {
            public Coordinate(int r, int c)
            {
                Row = r;
                Column = c;
            }
            public int Row;
            public int Column;
        }
    }
}
