namespace _02.MouseInTheKitchen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int mouseRow = 0;
            int mouseCol = 0;
            int cheeseCount = 0;
            int[] rowsAndCols = Console.ReadLine()
                
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = rowsAndCols[0];
            int cols = rowsAndCols[1];

            char[,] matrix = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                string symbols = Console.ReadLine();
                   
                for (int j = 0; j < cols; j++)
                {
                    if (symbols[j] == 'M')
                    {
                        mouseRow = i;
                        mouseCol = j;
                        matrix[mouseRow, mouseCol] = '*';
                    }

                    if (symbols[j] == 'C')
                    {
                        cheeseCount++;
                    }
                    matrix[i,j] = symbols[j];
                }
            }

            
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "danger")
            {
                
                if (command == "left")
                {
                    
                    if (mouseCol == 0)
                    {
                        Console.WriteLine("No more cheese for tonight!");
                        break;
                    }
                    else
                    {
                        
                        if (matrix[mouseRow, mouseCol - 1] == '@')
                        {
                            continue;
                        }
                        if (matrix[mouseRow, mouseCol - 1] == 'T')
                        {
                            Console.WriteLine("Mouse is trapped!");
                            matrix[mouseRow, mouseCol - 1] = 'M';
                            matrix[mouseRow, mouseCol] = '*';
                            mouseCol = mouseCol - 1;
                            break;
                        }
                        else if (matrix[mouseRow, mouseCol - 1] == 'C')
                        {
                            cheeseCount--;
                            matrix[mouseRow, mouseCol - 1] = 'M';
                            matrix[mouseRow, mouseCol] = '*';
                            mouseCol = mouseCol - 1;
                            if (cheeseCount == 0)
                            {
                                Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
                                break;
                            }
                        }
                        else
                        {
                            matrix[mouseRow, mouseCol - 1] = 'M';
                            matrix[mouseRow, mouseCol] = '*';
                            mouseCol = mouseCol - 1;
                        }
                        
                    }
                    
                    
                }
                else if (command == "down")
                {
                    if (mouseRow + 1 > rows - 1)
                    {
                        Console.WriteLine("No more cheese for tonight!");
                        break;
                    }
                    else
                    {

                        if (matrix[mouseRow + 1, mouseCol] == '@')
                        {
                            continue;
                        }

                        if (matrix[mouseRow + 1, mouseCol] == 'T')
                        {
                            Console.WriteLine("Mouse is trapped!");
                            matrix[mouseRow + 1, mouseCol] = 'M';
                            matrix[mouseRow, mouseCol] = '*';
                            mouseRow = mouseRow + 1;
                            break;
                        }
                        else if (matrix[mouseRow + 1, mouseCol] == 'C')
                        {
                            cheeseCount--;
                            matrix[mouseRow + 1, mouseCol] = 'M';
                            matrix[mouseRow, mouseCol] = '*';
                            mouseRow = mouseRow + 1;
                            if (cheeseCount == 0)
                            {
                                Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
                                break;
                            }
                        }
                        else
                        {
                            matrix[mouseRow + 1, mouseCol] = 'M';
                            matrix[mouseRow, mouseCol] = '*';
                            mouseRow = mouseRow + 1;
                        }
                    }
                }
                else if (command == "right")
                {
                    if (mouseCol + 1 > cols - 1)
                    {
                        Console.WriteLine("No more cheese for tonight!");
                        break;
                    }
                    else
                    {

                        if (matrix[mouseRow, mouseCol + 1] == '@')
                        {
                            continue;
                        }

                        if (matrix[mouseRow, mouseCol + 1] == 'T')
                        {
                            Console.WriteLine("Mouse is trapped!");
                            matrix[mouseRow, mouseCol + 1] = 'M';
                            matrix[mouseRow, mouseCol] = '*';
                            mouseCol = mouseCol + 1;
                            break;
                        }
                        else if (matrix[mouseRow, mouseCol + 1] == 'C')
                        {
                            cheeseCount--;
                            matrix[mouseRow, mouseCol + 1] = 'M';
                            matrix[mouseRow, mouseCol] = '*';
                            mouseCol = mouseCol + 1;
                            if (cheeseCount == 0)
                            {
                                Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
                                break;
                            }
                        }
                        else
                        {
                            matrix[mouseRow, mouseCol + 1] = 'M';
                            matrix[mouseRow, mouseCol] = '*';
                            mouseCol = mouseCol + 1;
                        }
                    }
                }
                else if (command == "up")
                {
                    if (mouseRow + 1 < 0)
                    {
                        Console.WriteLine("No more cheese for tonight!");
                        break;
                    }
                    else
                    {

                        if (matrix[mouseRow - 1, mouseCol] == '@')
                        {
                            continue;
                        }

                        if (matrix[mouseRow - 1, mouseCol] == 'T')
                        {
                            Console.WriteLine("Mouse is trapped!");
                            matrix[mouseRow - 1, mouseCol] = 'M';
                            matrix[mouseRow, mouseCol] = '*';
                            mouseRow = mouseRow - 1;
                            break;
                        }
                        else if (matrix[mouseRow - 1, mouseCol] == 'C')
                        {
                            cheeseCount--;
                            matrix[mouseRow - 1, mouseCol] = 'M';
                            matrix[mouseRow, mouseCol] = '*';
                            mouseRow = mouseRow - 1;
                            if (cheeseCount == 0)
                            {
                                Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
                                break;
                            }
                        }
                        else
                        {
                            matrix[mouseRow - 1, mouseCol] = 'M';
                            matrix[mouseRow, mouseCol] = '*';
                            mouseRow = mouseRow - 1;
                        }
                    }
                }
            }

            if (command == "danger")
            {
                Console.WriteLine("Mouse will come back later!");
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
}
