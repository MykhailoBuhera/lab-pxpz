using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Random rnd = new Random();
        int n = 5; //size of matrx

        
        int[,] A = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                A[i, j] = rnd.Next(-50, 50); // random for elements
            }
        }

        // vuvid matrix
        Console.WriteLine("matrix A");
        PrintMatrix(A);

        Console.Write("\n enter chuslo x ");
        int x = int.Parse(Console.ReadLine());

        // 3. Пошук рядків і стовпців для видалення
        HashSet<int> rowsToRemove = new HashSet<int>();
        HashSet<int> colsToRemove = new HashSet<int>();

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (A[i, j] == x)
                {
                    rowsToRemove.Add(i);
                    colsToRemove.Add(j);
                }
            }
        }

        // size new maric
        int newN = n - rowsToRemove.Count;
        if (newN <= 0)
        {
            Console.WriteLine("\neroro pishov spatu");
            return;
        }

        int[,] B = new int[newN, newN];

        
        int newRow = 0;
        for (int i = 0; i < n; i++)
        {
            if (rowsToRemove.Contains(i)) continue;
            int newCol = 0;
            for (int j = 0; j < n; j++)
            {
                if (colsToRemove.Contains(j)) continue;
                B[newRow, newCol] = A[i, j];
                newCol++;
            }
            newRow++;
        }

        
        Console.WriteLine("\nmatrix B:");
        PrintMatrix(B);
    }

    // 
    static void PrintMatrix(int[,] M)
    {
        for (int i = 0; i < M.GetLength(0); i++)
        {
            for (int j = 0; j < M.GetLength(1); j++)
            {
                Console.Write($"{M[i, j],4}");
            }
            Console.WriteLine();
        }
    } 
}
