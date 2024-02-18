namespace _02.Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int jetRow = 0;
            int jetCol = 0;
            int countOfEnemies = 0;
            int armour = 300;
            char[,] matrix = new char[size, size];

            for (int i = 0; i < size; i++)
            {
                string symbols = Console.ReadLine();
                for (int j = 0; j < size; j++)
                {
                    if (symbols[j] == 'J')
                    {
                        jetRow = i;
                        jetCol = j;
                    }

                    if (symbols[j] == 'E')
                    {
                        countOfEnemies++;
                    }
                    matrix[i,j] = symbols[j];
                }
            }
            
            while (countOfEnemies > 0 && armour > 0)
            {
                string command = Console.ReadLine();
                if (command == "left")
                {
                    if (matrix[jetRow, jetCol - 1] == '-')
                    {
                        matrix[jetRow, jetCol] = '-';
                        matrix[jetRow, jetCol - 1] = 'J';
                        jetCol -= 1;
                    }
                    else if (matrix[jetRow, jetCol - 1] == 'E')
                    {
                        if (countOfEnemies > 1)
                        {
                            countOfEnemies--;
                            armour -= 100;
                        }
                        else if (countOfEnemies == 1)
                        {
                            countOfEnemies--;
                        }
                        matrix[jetRow, jetCol] = '-';
                        matrix[jetRow, jetCol - 1] = 'J';
                        jetCol -= 1;
                    }
                    else if (matrix[jetRow, jetCol - 1] == 'R')
                    {
                        armour = 300;
                        matrix[jetRow, jetCol] = '-';
                        matrix[jetRow, jetCol - 1] = 'J';
                        jetCol -= 1;

                    }
                }
                else if (command == "right")
                {
                    if (matrix[jetRow, jetCol + 1] == '-')
                    {
                        matrix[jetRow, jetCol] = '-';
                        matrix[jetRow, jetCol + 1] = 'J';
                        jetCol += 1;

                    }
                    else if (matrix[jetRow, jetCol + 1] == 'E')
                    {
                        if (countOfEnemies > 1)
                        {
                            countOfEnemies--;
                            armour -= 100;
                        }
                        else if (countOfEnemies == 1)
                        {
                            countOfEnemies--;
                        }
                        matrix[jetRow, jetCol] = '-';
                        matrix[jetRow, jetCol + 1] = 'J';
                        jetCol += 1;

                    }
                    else if (matrix[jetRow, jetCol + 1] == 'R')
                    {
                        armour = 300;
                        matrix[jetRow, jetCol] = '-';
                        matrix[jetRow, jetCol + 1] = 'J';
                        jetCol += 1;

                    }
                }
                else if (command == "down")
                {
                    if (matrix[jetRow + 1, jetCol] == '-')
                    {
                        matrix[jetRow, jetCol] = '-';
                        matrix[jetRow + 1, jetCol] = 'J';
                        jetRow += 1;

                    }
                    else if (matrix[jetRow + 1, jetCol] == 'E')
                    {
                        if (countOfEnemies > 1)
                        {
                            countOfEnemies--;
                            armour -= 100;
                        }
                        else if (countOfEnemies == 1)
                        {
                            countOfEnemies--;
                        }
                        matrix[jetRow, jetCol] = '-';
                        matrix[jetRow + 1, jetCol] = 'J';
                        jetRow += 1;
                    }
                    else if (matrix[jetRow + 1, jetCol] == 'R')
                    {
                        armour = 300;
                        matrix[jetRow, jetCol] = '-';
                        matrix[jetRow + 1, jetCol] = 'J';
                        jetRow += 1;
                    }
                }
                else if (command == "up")
                {
                    if (matrix[jetRow - 1, jetCol] == '-')
                    {
                        matrix[jetRow, jetCol] = '-';
                        matrix[jetRow - 1, jetCol] = 'J';
                        jetRow -= 1;
                    }
                    else if (matrix[jetRow - 1, jetCol] == 'E')
                    {
                        if (countOfEnemies > 1)
                        {
                            countOfEnemies--;
                            armour -= 100;
                        }
                        else if (countOfEnemies == 1)
                        {
                            countOfEnemies--;
                        }
                        matrix[jetRow, jetCol] = '-';
                        matrix[jetRow - 1, jetCol] = 'J';
                        jetRow -= 1;

                    }
                    else if (matrix[jetRow - 1, jetCol] == 'R')
                    {
                        armour = 300;
                        matrix[jetRow, jetCol] = '-';
                        matrix[jetRow - 1, jetCol] = 'J';
                        jetRow -= 1;

                    }
                }
            }

            if (countOfEnemies == 0 && armour > 0)
            {
                Console.WriteLine("Mission accomplished, you neutralized the aerial threat!");
            }
            else if (armour == 0 && countOfEnemies > 0)
            {
                Console.WriteLine($"Mission failed, your jetfighter was shot down! Last coordinates [{jetRow}, {jetCol}]!");
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(matrix[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
}
