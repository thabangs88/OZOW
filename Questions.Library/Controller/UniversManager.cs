using Questions.Library.Enums;
using Questions.Library.Interface;
using Questions.Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.Library.Controller
{
    public class UniversManager : IUniversManager
    {
        UniverseConfig universe;
        Board board;
        Cell[,] cells;

        IFileManager fileManager;
        public UniversManager()
        {
            universe = new UniverseConfig();
            board = new Board();
            fileManager = new FileManager();
        }

        public bool ConfigureBoard(int length, int height)
        {

            if (length == 0 || height == 0)
            {
                throw new Exception("Board length or heigh cannot be Zero");
            }

            board.Height = height;
            board.Length = length;

            return true;
      
        }

        public void ConigureUniversGeneration(int generation)
        {
            universe.Generation = generation;
            cells = new Cell[board.Length, board.Height];

        }

        public bool LoadCells()
        {
            try
            {
                int cellIndex = 1;

                for (int i = 0; i < board.Length; i++)
                {
                    for (int j = 0; j < board.Height; j++)
                    {
                        cells[i, j] = new Cell()
                        {
                            Name = $"Cell {cellIndex}",
                            Poistion = new Point() { X = i, Y = j },
                            LiveState = CellState.Alive,
                        };

                        cellIndex++;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }


        }

        public bool RunUniverseLivespan()
        {
            StringBuilder sb = new StringBuilder();

            try
            {
                fileManager.ClearFileContent();

                int[] x = { -1, -1, -1, 0, 0, 1, 1, 1 };
                int[] y = { -1, 0, 1, -1, 1, -1, 0, 1 };

                int i = 1;
                while (i <= universe.Generation)
                {
                    for (int row = 0; row <= cells.Length; row++)
                    {
                        for (int col = 0; col <= cells.Length; col++)
                        {


                            int neighbors = 0, liveNeighbors = 0;
                            int totalNeighbors = 0;

                            for (int dir = 0; dir < 8; dir++)
                            {

                                int rd = row + x[dir];
                                int cd = col + y[dir];


                                try
                                {
                                    Point cellPoint = new Point() { X = row, Y = col };
                                    Point tempCellPoint = new Point() { X = rd, Y = cd };

                                    if (cellPoint != tempCellPoint)
                                    {
                                        var currentCell = cells[rd, cd];

                                        if (currentCell.LiveState == CellState.Alive)
                                        {
                                            liveNeighbors++;
                                        }

                                        neighbors++;

                                        if (dir == 7)
                                        {
                                            if (cells[row, col].LiveState == CellState.Alive)
                                            {

                                                if (liveNeighbors < 2)
                                                {
                                                    cells[row, col].LiveState = CellState.Dead;
                                                    cells[row, col].GenerationState = PopulationState.Underpopulation;
                                                }

                                                else if (liveNeighbors == 2 || liveNeighbors == 3)
                                                {
                                                    cells[row, col].LiveState = CellState.Alive;
                                                    cells[row, col].GenerationState = PopulationState.NextGeneration;

                                                }

                                                else if (liveNeighbors > 3)
                                                {
                                                    cells[row, col].LiveState = CellState.Dead;
                                                    cells[row, col].GenerationState = PopulationState.Overpopulation;

                                                }

                                            }

                                            if (liveNeighbors == 3)
                                            {
                                                if (cells[row, col].LiveState == CellState.Dead)
                                                {
                                                    cells[row, col].LiveState = CellState.Alive;
                                                    cells[row, col].GenerationState = PopulationState.Reproduction;
                                                }

                                            }

                                            cells[row, col].NoNeighbours = neighbors;




                                            sb.AppendLine($"{cells[row, col].Name}");
                                            sb.AppendLine($"State: {cells[row, col].LiveState}");
                                            sb.AppendLine($"GenerationState: {cells[row, col].GenerationState}");
                                            sb.AppendLine($"Total Neighbors: {cells[row, col].NoNeighbours}");
                                            sb.AppendLine("------------------------------------------------");

                                            fileManager.WriteToFile(sb.ToString());
                                            Console.WriteLine(sb.ToString());
                                        }


                                        totalNeighbors++;

                                    }

                                }
                                catch (Exception)
                                {
                                    continue;
                                }

                            }
                        }

                    }

                    i++;
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }


        }
    }
}
