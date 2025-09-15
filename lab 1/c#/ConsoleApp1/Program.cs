using System;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Vvedit radius kola");
        Console.Write("Radius = ");
        int R = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Vvedit kordunatu tochku");
        Console.Write("x = ");
        int x = Convert.ToInt32(Console.ReadLine());
        Console.Write("y = ");
        int y = Convert.ToInt32(Console.ReadLine());
        Console.ReadLine();
        static string Popav(int x, int y, int R)
        {
            if (x <= 0 && y >= 0 && x <= R && y <= R && x >= -R)
            {
                if (x == 0 || y == 0 || x == R || y == R || x == -R)
                {
                    return "na mezhi kolo";
                }
                else
                {
                    return "Popav kolo";
                }
            }
            // Трикутник: x >= 0, x <= R, y <= 0, y >= -2*x, y >= -R, y <= -2*(x - R)
            else if (x >= 0 && x <= R && y <= 0 && y >= -2 * x && y >= -R && y <= -2 * (x - R))
            {
                if (Math.Abs(y + 2 * x) < 1e-8 || Math.Abs(y + R) < 1e-8 || Math.Abs(y + 2 * (x - R)) < 1e-8)
                    return "na mezhi trukyt";
                else
                    return "Popav v trukyt";
            }
            else
            {
                return "Ne popav";
            }
        }
        string result = Popav(x, y, R);
        Console.WriteLine(result);
    }
}