using System;

class Program
{
    static bool IsValid(int x, int y) => x >= 1 && x <= 8 && y >= 1 && y <= 8;

    static bool RookAttacks(int rx, int ry, int tx, int ty) => rx == tx || ry == ty;
    static bool BishopAttacks(int bx, int by, int tx, int ty) => Math.Abs(bx - tx) == Math.Abs(by - ty);

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("Введіть координати білого туру №1 (x y):");
        if (!ReadTwoInts(out int r1x, out int r1y) || !IsValid(r1x, r1y)) { Console.WriteLine("Некоректні координати."); return; }

        Console.WriteLine("Введіть координати білого туру №2 (x y):");
        if (!ReadTwoInts(out int r2x, out int r2y) || !IsValid(r2x, r2y)) { Console.WriteLine("Некоректні координати."); return; }

        Console.WriteLine("Введіть координати чорного слона №1 (x y):");
        if (!ReadTwoInts(out int b1x, out int b1y) || !IsValid(b1x, b1y)) { Console.WriteLine("Некоректні координати."); return; }

        Console.WriteLine("Введіть координати чорного слона №2 (x y):");
        if (!ReadTwoInts(out int b2x, out int b2y) || !IsValid(b2x, b2y)) { Console.WriteLine("Некоректні координати."); return; }

        // Перевірка, чи всі фігури на різних клітинках
        if ((r1x == r2x && r1y == r2y) || (r1x == b1x && r1y == b1y) || (r1x == b2x && r1y == b2y) ||
            (r2x == b1x && r2y == b1y) || (r2x == b2x && r2y == b2y) ||
            (b1x == b2x && b1y == b2y))
        {
            Console.WriteLine("Помилка: дві фігури на одній клітинці!");
            return;
        }

        // Предобчислюємо атаки
        bool r1_att_b1 = RookAttacks(r1x, r1y, b1x, b1y);
        bool r1_att_b2 = RookAttacks(r1x, r1y, b2x, b2y);
        bool r2_att_b1 = RookAttacks(r2x, r2y, b1x, b1y);
        bool r2_att_b2 = RookAttacks(r2x, r2y, b2x, b2y);

        bool b1_att_r1 = BishopAttacks(b1x, b1y, r1x, r1y);
        bool b1_att_r2 = BishopAttacks(b1x, b1y, r2x, r2y);
        bool b2_att_r1 = BishopAttacks(b2x, b2y, r1x, r1y);
        bool b2_att_r2 = BishopAttacks(b2x, b2y, r2x, r2y);

        // --- Білий тура №1: пріоритет захисту > напад > простий хід
        if ((b1_att_r2 && r1_att_b1) || (b2_att_r2 && r1_att_b2))
            Console.WriteLine("Білий тура №1 здійснює захист.");
        else if (r1_att_b1)
            Console.WriteLine("Білий тура №1 здійснює напад на чорного слона №1.");
        else if (r1_att_b2)
            Console.WriteLine("Білий тура №1 здійснює напад на чорного слона №2.");
        else
            Console.WriteLine("Білий тура №1 робить простий хід.");

        // --- Білий тура №2
        if ((b1_att_r1 && r2_att_b1) || (b2_att_r1 && r2_att_b2))
            Console.WriteLine("Білий тура №2 здійснює захист.");
        else if (r2_att_b1)
            Console.WriteLine("Білий тура №2 здійснює напад на чорного слона №1.");
        else if (r2_att_b2)
            Console.WriteLine("Білий тура №2 здійснює напад на чорного слона №2.");
        else
            Console.WriteLine("Білий тура №2 робить простий хід.");

        // --- Чорний слон №1
        if ((r1_att_b2 && b1_att_r1) || (r2_att_b2 && b1_att_r2))
            Console.WriteLine("Чорний слон №1 здійснює захист.");
        else if (b1_att_r1)
            Console.WriteLine("Чорний слон №1 здійснює напад на білу туру №1.");
        else if (b1_att_r2)
            Console.WriteLine("Чорний слон №1 здійснює напад на білу туру №2.");
        else
            Console.WriteLine("Чорний слон №1 робить простий хід.");

        // --- Чорний слон №2
        if ((r1_att_b1 && b2_att_r1) || (r2_att_b1 && b2_att_r2))
            Console.WriteLine("Чорний слон №2 здійснює захист.");
        else if (b2_att_r1)
            Console.WriteLine("Чорний слон №2 здійснює напад на білу туру №1.");
        else if (b2_att_r2)
            Console.WriteLine("Чорний слон №2 здійснює напад на білу туру №2.");
        else
            Console.WriteLine("Чорний слон №2 робить простий хід.");
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
