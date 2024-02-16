namespace _02.DeliveryBoy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndCols = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

            char[,] matrix = new char[rowsAndCols[0], rowsAndCols[1]];

            int pizzaRow = 0;
            int pizzaCol = 0;

            int startRow = 0;
            int startCol = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string newRow = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = newRow[col];

                    if (matrix[row, col] == 'B')
                    {
                        pizzaRow = row;
                        pizzaCol = col;
                        startRow = row;
                        startCol = col;
                    }
                }
            }

            bool isOutsideMatrix = false;

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "left")
                {
                    if (pizzaCol == 0)
                    {
                        if (matrix[pizzaRow, pizzaCol] == '-')
                        {
                            matrix[pizzaRow, pizzaCol] = '.';
                        }

                        isOutsideMatrix = true;

                        Console.WriteLine("The delivery is late. Order is canceled.");

                        break;
                    }

                    if (matrix[pizzaRow, pizzaCol - 1] == '*')
                    {
                        continue;
                    }

                    if (matrix[pizzaRow, pizzaCol] != 'R')
                    {
                        matrix[pizzaRow, pizzaCol] = '.';
                    }

                    pizzaCol--;
                }
                else if (command == "right")
                {
                    if (pizzaCol == matrix.GetLength(1) - 1)
                    {
                        if (matrix[pizzaRow, pizzaCol] == '-')
                        {
                            matrix[pizzaRow, pizzaCol] = '.';
                        }

                        isOutsideMatrix = true;

                        Console.WriteLine("The delivery is late. Order is canceled.");

                        break;
                    }

                    if (matrix[pizzaRow, pizzaCol + 1] == '*')
                    {
                        continue;
                    }

                    if (matrix[pizzaRow, pizzaCol] != 'R')
                    {
                        matrix[pizzaRow, pizzaCol] = '.';
                    }

                    pizzaCol++;
                }
                else if (command == "up")
                {
                    if (pizzaRow == 0)
                    {
                        if (matrix[pizzaRow, pizzaCol] == '-')
                        {
                            matrix[pizzaRow, pizzaCol] = '.';
                        }

                        isOutsideMatrix = true;

                        Console.WriteLine("The delivery is late. Order is canceled.");

                        break;
                    }

                    if (matrix[pizzaRow - 1, pizzaCol] == '*')
                    {
                        continue;
                    }

                    if (matrix[pizzaRow, pizzaCol] != 'R')
                    {
                        matrix[pizzaRow, pizzaCol] = '.';
                    }

                    pizzaRow--;
                }
                else if (command == "down")
                {
                    if (pizzaRow == matrix.GetLength(0) - 1)
                    {
                        if (matrix[pizzaRow, pizzaCol] == '-')
                        {
                            matrix[pizzaRow, pizzaCol] = '.';
                        }

                        isOutsideMatrix = true;

                        Console.WriteLine("The delivery is late. Order is canceled.");

                        break;
                    }

                    if (matrix[pizzaRow + 1, pizzaCol] == '*')
                    {
                        continue;
                    }

                    if (matrix[pizzaRow, pizzaCol] != 'R')
                    {
                        matrix[pizzaRow, pizzaCol] = '.';
                    }

                    pizzaRow++;
                }

                if (matrix[pizzaRow, pizzaCol] == 'P')
                {
                    Console.WriteLine("Pizza is collected. 10 minutes for delivery.");

                    matrix[pizzaRow, pizzaCol] = 'R';

                    continue;
                }

                if (matrix[pizzaRow, pizzaCol] == 'A')
                {
                    Console.WriteLine("Pizza is delivered on time! Next order...");

                    matrix[pizzaRow, pizzaCol] = 'P';

                    break;
                }
            }

            if (isOutsideMatrix)
            {
                matrix[startRow, startCol] = ' ';
            }
            else
            {
                matrix[startRow, startCol] = 'B';
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
