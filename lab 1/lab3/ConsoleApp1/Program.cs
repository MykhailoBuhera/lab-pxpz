using System;

class Program
{
    static bool IsValid(int x, int y) => x >= 1 && x <= 8 && y >= 1 && y <= 8;

    static bool KingAttacks(int kx, int ky, int tx, int ty)
    {
        return Math.Abs(kx - tx) <= 1 && Math.Abs(ky - ty) <= 1;
    }

    static bool KnightAttacks(int nx, int ny, int tx, int ty)
    {
        int dx = Math.Abs(nx - tx);
        int dy = Math.Abs(ny - ty);
        return (dx == 2 && dy == 1) || (dx == 1 && dy == 2);
    }

    static bool BishopAttacks(int bx, int by, int tx, int ty)
    {
        return Math.Abs(bx - tx) == Math.Abs(by - ty);
    }

    static int ChooseFigure()
    {
        while (true)
        {
            Console.Write("Виберіть фігуру для ходу (1 - Білий король, 2 - Чорний кінь, 3 - Чорний слон, 0 - Вихід): ");
            string s = Console.ReadLine();
            if (int.TryParse(s, out int f) && f >= 0 && f <= 3) return f;
            Console.WriteLine("Невірний ввід — спробуйте ще.");
        }
    }

    static void ShowBoard(int x1, int y1, int x2, int y2, int x3, int y3)
    {
        Console.WriteLine("\n--- Поточні координати фігур ---");
        Console.WriteLine($"Білий король: ({x1},{y1})");
        Console.WriteLine($"Чорний кінь:  ({x2},{y2})");
        Console.WriteLine($"Чорний слон:  ({x3},{y3})");
        Console.WriteLine("--------------------------------\n");
    }

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("Введіть координати білого короля (x y):");
        if (!ReadTwoInts(out int x1, out int y1) || !IsValid(x1, y1))
        {
            Console.WriteLine("Некоректні координати короля.");
            return;
        }

        Console.WriteLine("Введіть координати чорного коня (x y):");
        if (!ReadTwoInts(out int x2, out int y2) || !IsValid(x2, y2))
        {
            Console.WriteLine("Некоректні координати коня.");
            return;
        }

        Console.WriteLine("Введіть координати чорного слона (x y):");
        if (!ReadTwoInts(out int x3, out int y3) || !IsValid(x3, y3))
        {
            Console.WriteLine("Некоректні координати слона.");
            return;
        }

        if ((x1 == x2 && y1 == y2) || (x1 == x3 && y1 == y3) || (x2 == x3 && y2 == y3))
        {
            Console.WriteLine("Помилка: дві фігури на одній клітинці!");
            return;
        }

        while (true)
        {
            ShowBoard(x1, y1, x2, y2, x3, y3); // показуємо координати

            int choice = ChooseFigure();
            if (choice == 0) { Console.WriteLine("Вихід."); break; }

            Console.WriteLine("Введіть нові координати для вибраної фігури (x y):");
            if (!ReadTwoInts(out int nx, out int ny) || !IsValid(nx, ny))
            {
                Console.WriteLine("Некоректні координати ходу.");
                continue;
            }

            switch (choice)
            {
                case 1: // Білий король
                    if (KingAttacks(nx, ny, x2, y2))
                        Console.WriteLine("Білий король здійснює напад на чорного коня.");
                    else if (KingAttacks(nx, ny, x3, y3))
                        Console.WriteLine("Білий король здійснює напад на чорного слона.");
                    else
                        Console.WriteLine("Простий хід короля.");
                    x1 = nx; y1 = ny; // оновлюємо позицію
                    break;

                case 2: // Чорний кінь
                    if (KnightAttacks(x2, y2, x1, y1))
                        Console.WriteLine("Кінь здійснює напад на білого короля.");
                    else
                        Console.WriteLine("Простий хід коня.");
                    x2 = nx; y2 = ny;
                    break;

                case 3: // Чорний слон
                    if (BishopAttacks(x3, y3, x1, y1))
                        Console.WriteLine("Слон здійснює напад на білого короля.");
                    else
                        Console.WriteLine("Простий хід слона.");
                    x3 = nx; y3 = ny;
                    break;
            }
        }
    }

    static bool ReadTwoInts(out int a, out int b)
    {
        a = b = 0;
        string s = Console.ReadLine();
        if (s == null) return false;
        var parts = s.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length < 2) return false;
        return int.TryParse(parts[0], out a) && int.TryParse(parts[1], out b);
    }
}
