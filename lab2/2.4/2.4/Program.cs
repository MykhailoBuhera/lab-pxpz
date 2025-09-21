
using System;

// Generate a jagged array (array of int[]). Uses TryParse for safe input and a single Random.
int[][] generatejaggedArr()
{
    Console.Write("Enter size of array: ");
    string? input = Console.ReadLine();
    if (!int.TryParse(input, out int SIZE) || SIZE <= 0)
    {
        Console.WriteLine("Invalid size. Using size = 0.");
        return Array.Empty<int[]>();
    }

    var rand = new Random();
    int[][] arr = new int[SIZE][];
    for (int i = 0; i < SIZE; i++)
    {
        int rowSize = rand.Next(1, 6);
        arr[i] = new int[rowSize];
        for (int j = 0; j < rowSize; j++)
        {
            arr[i][j] = rand.Next(-10, 10);
        }
    }
    return arr;
}

// Display a jagged array safely by using Length on each row.
void displayArray(int[][]? array)
{
    if (array == null || array.Length == 0)
    {
        Console.WriteLine("(empty array)");
        return;
    }

    for (int i = 0; i < array.Length; i++)
    {
        int cols = array[i]?.Length ?? 0;
        for (int j = 0; j < cols; j++)
        {
            Console.Write(array[i][j] + " ");
        }
        Console.WriteLine();
    }
}

void main()
{
    /*
    var jagged = generatejaggedArr();
    displayArray(jagged);*/
    
}

main();