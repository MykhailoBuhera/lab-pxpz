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

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Ввід координат
        Console.WriteLine("Введіть координати білого короля (x y):");
        if (!ReadTwoInts(out int kx, out int ky) || !IsValid(kx, ky))
        {
            Console.WriteLine("Некоректні координати короля.");
            return;
        }

        Console.WriteLine("Введіть координати чорного коня (x y):");
        if (!ReadTwoInts(out int nx, out int ny) || !IsValid(nx, ny))
        {
            Console.WriteLine("Некоректні координати коня.");
            return;
        }

        Console.WriteLine("Введіть координати чорного слона (x y):");
        if (!ReadTwoInts(out int bx, out int by) || !IsValid(bx, by))
        {
            Console.WriteLine("Некоректні координати слона.");
            return;
        }

        if ((kx == nx && ky == ny) || (kx == bx && ky == by) || (nx == bx && ny == by))
        {
            Console.WriteLine("Помилка: дві фігури на одній клітинці!");
            return;
        }

        // Хід короля
        if (KingAttacks(kx, ky, nx, ny))
            Console.WriteLine("Білий король здійснює напад на чорного коня.");
        else if (KingAttacks(kx, ky, bx, by))
            Console.WriteLine("Білий король здійснює напад на чорного слона.");
        else if ((KnightAttacks(nx, ny, kx, ky) && KingAttacks(kx, ky, bx, by)) ||
                 (BishopAttacks(bx, by, kx, ky) && KingAttacks(kx, ky, nx, ny)))
            Console.WriteLine("Білий король здійснює захист.");
        else
            Console.WriteLine("Білий король робить простий хід.");

        // Хід коня
        if (KnightAttacks(nx, ny, kx, ky))
            Console.WriteLine("Чорний кінь здійснює напад на білого короля.");
        else if (KnightAttacks(nx, ny, bx, by))
            Console.WriteLine("Чорний кінь здійснює напад на чорного слона.");
        else
            Console.WriteLine("Чорний кінь робить простий хід.");

        // Хід слона
        if (BishopAttacks(bx, by, kx, ky))
            Console.WriteLine("Чорний слон здійснює напад на білого короля.");
        else if (BishopAttacks(bx, by, nx, ny))
            Console.WriteLine("Чорний слон здійснює напад на чорного коня.");
        else if (KnightAttacks(nx, ny, kx, ky) && BishopAttacks(bx, by, nx, ny))
            Console.WriteLine("Чорний слон здійснює захист.");
        else
            Console.WriteLine("Чорний слон робить простий хід.");
    }

    static bool ReadTwoInts(out int a, out int b)
    {
        a = b = 0;
        string? s = Console.ReadLine();
        if (s == null) return false;
        var parts = s.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length < 2) return false;
        return int.TryParse(parts[0], out a) && int.TryParse(parts[1], out b);
    }
}
