using System;

namespace MatrixAreaCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the matrix as a string:");
            string input = Console.ReadLine();

            int numberOfAreas = CalculateNumberOfAreas(input);
            Console.WriteLine($"Number of areas formed by 1: {numberOfAreas}");
        }

        static int CalculateNumberOfAreas(string input)
        {
            string[] rows = input.Split(';');
            int[,] matrix = new int[rows.Length, rows[0].Split(',').Length];

            for (int i = 0; i < rows.Length; i++)
            {
                string[] values = rows[i].Split(',');
                for (int j = 0; j < values.Length; j++)
                {
                    matrix[i, j] = int.Parse(values[j]);
                }
            }

            int rowsCount = matrix.GetLength(0);
            int colsCount = matrix.GetLength(1);
            int areas = 0;

            bool[,] visited = new bool[rowsCount, colsCount];

            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < colsCount; j++)
                {
                    if (matrix[i, j] == 1 && !visited[i, j])
                    {
                        areas++;
                        VisitConnectedArea(matrix, visited, i, j);
                    }
                }
            }

            return areas;
        }

        static void VisitConnectedArea(int[,] matrix, bool[,] visited, int row, int col)
        {
            if (row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1))
                return;

            if (matrix[row, col] == 1 && !visited[row, col])
            {
                visited[row, col] = true;

                VisitConnectedArea(matrix, visited, row - 1, col); // Up
                VisitConnectedArea(matrix, visited, row + 1, col); // Down
                VisitConnectedArea(matrix, visited, row, col - 1); // Left
                VisitConnectedArea(matrix, visited, row, col + 1); // Right
            }
        }
    }
}
