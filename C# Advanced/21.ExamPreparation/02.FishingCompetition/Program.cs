namespace _02.FishingCompetition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int boatRow = 0;
            int boatCol =0;
            char[,] matrix = new char[size, size];

            int fish = 0;
            for (int i = 0; i < size; i++)
            {
                string symbols = Console.ReadLine();

                for (int j = 0; j < size; j++)
                {
                    if (symbols[j] == 'S')
                    {
                        boatRow = i;
                        boatCol = j;
                    }
                    matrix[i, j] = symbols[j];
                }
            }

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "collect the nets")
            {
                if (command == "left")
                {
                    int previousCol = boatCol;
                    if (boatCol - 1 < 0)
                    {
                        boatCol = size - 1;
                    }
                    else
                    {
                        boatCol -= 1;
                    }

                    if (matrix[boatRow, boatCol] == 'W')
                    {
                        
                        Console.WriteLine($"You fell into a whirlpool! The ship sank and you lost the fish you caught. Last coordinates of the ship: [{boatRow},{boatCol}]");
                        return;

                    }
                    else if(char.IsDigit(matrix[boatRow, boatCol]))
                    {
                        
                        fish += matrix[boatRow, boatCol] - '0';
                        matrix[boatRow, boatCol] = 'S';
                        matrix[boatRow, previousCol] = '-';
                    }
                    else
                    {
                        matrix[boatRow, boatCol] = 'S';
                        matrix[boatRow, previousCol] = '-';
                    }
                }
                else if (command == "right")
                {
                    int previousCol = boatCol;
                    if (boatCol + 1 > size - 1)
                    {
                        boatCol = 0;
                    }
                    else
                    {

                        boatCol += 1;
                    }

                    if (matrix[boatRow, boatCol] == 'W')
                    {

                        Console.WriteLine($"You fell into a whirlpool! The ship sank and you lost the fish you caught. Last coordinates of the ship: [{boatRow},{boatCol}]");
                        return;

                    }
                    else if (char.IsDigit(matrix[boatRow, boatCol]))
                    {

                        fish += matrix[boatRow, boatCol] - '0';
                        matrix[boatRow, boatCol] = 'S';
                        matrix[boatRow, previousCol] = '-';
                    }
                    else
                    {
                        matrix[boatRow, boatCol] = 'S';
                        matrix[boatRow, previousCol] = '-';
                    }
                }
                else if (command == "up")
                {
                    int previousRow = boatRow;
                    if (boatRow - 1 < 0)
                    {
                        boatRow = size - 1;
                    }
                    else
                    {
                        boatRow -= 1;
                    }

                    if (matrix[boatRow, boatCol] == 'W')
                    {

                        Console.WriteLine($"You fell into a whirlpool! The ship sank and you lost the fish you caught. Last coordinates of the ship: [{boatRow},{boatCol}]");
                        return;

                    }
                    else if (char.IsDigit(matrix[boatRow, boatCol]))
                    {

                        fish += matrix[boatRow, boatCol] - '0';
                        matrix[boatRow, boatCol] = 'S';
                        matrix[previousRow, boatCol] = '-';
                    }
                    else
                    {
                        matrix[boatRow, boatCol] = 'S';
                        matrix[previousRow, boatCol] = '-';
                    }
                }
                else if (command == "down")
                {
                    int previousRow = boatRow;
                    if (boatRow + 1 > size - 1)
                    {
                        boatRow = 0;
                    }
                    else
                    {
                        boatRow += 1;
                    }

                    if (matrix[boatRow, boatCol] == 'W')
                    {

                        Console.WriteLine($"You fell into a whirlpool! The ship sank and you lost the fish you caught. Last coordinates of the ship: [{boatRow},{boatCol}]");
                        return;
                    }
                    else if (char.IsDigit(matrix[boatRow, boatCol]))
                    {

                        fish += matrix[boatRow, boatCol] - '0';
                        matrix[boatRow, boatCol] = 'S';
                        matrix[previousRow, boatCol] = '-';
                    }
                    else
                    {
                        matrix[boatRow, boatCol] = 'S';
                        matrix[previousRow, boatCol] = '-';
                    }
                }
            }

            if (fish >= 20)
            {
                Console.WriteLine("Success! You managed to reach the quota!");
                
                
            }
            else 
            {
                Console.WriteLine($"You didn't catch enough fish and didn't reach the quota! You need {20 - fish} tons of fish more.");
                
            }

            if (fish > 0)
            {
                Console.WriteLine($"Amount of fish caught: {fish} tons.");
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
