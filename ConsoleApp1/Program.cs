using Xamarin.Forms;

class Programm
{
    static void Main()
    {
        Pole pole = new Pole();
        bool player = true,exit = true;
        int z = 0, x = 0, c = 0, v = 0;
        while (exit)
        {
            pole.Pokaz();
                Console.WriteLine("Введите адрес шашки по вертикале");
                while (!int.TryParse(Console.ReadLine(), out z))
                {
                    Console.WriteLine("Введите число");
                }
                Console.WriteLine("Введите адрес шашки по горизонтали");
                while (!int.TryParse(Console.ReadLine(), out x))
                {
                    Console.WriteLine("Введите число");
                }
                if((z < 8 || z >= 0) || (x < 8 ||x >= 0))
                {
                    if ((pole.pole[z,x] == 3 && player == true) || (pole.pole[z, x] == 2 && player == false))
                    {
                        Console.WriteLine("Введите координату куда передвинется шашка по вертикале");
                        while (!int.TryParse(Console.ReadLine(), out c))
                            Console.WriteLine("Введите число");
                        Console.WriteLine("Введите адрес шашки по горизонтали");
                        while (!int.TryParse(Console.ReadLine(), out v))
                            Console.WriteLine("Введите число");
                    if (player == true)
                    {
                        if (pole.pole[c, v] == 2)
                        {
                            if (x > v)
                            {
                                if (pole.pole[c - 1, x - 1] == 0)
                                {
                                    pole.pole[c, v] = 0;
                                    pole.pole[z, x] = 0;
                                    pole.pole[c - 1,x - 1] = 3;
                                    player = !player;
                                }
                            }
                            else
                            {
                                if (pole.pole[c-1, v + 1] == 0)
                                {
                                    pole.pole[c, v] = 0;
                                    pole.pole[z, x] = 0;
                                    pole.pole[c - 1,v + 1] = 3;
                                    player = !player;
                                }
                            }

                        }
                        else if (((z - 1 == c && x + 1 == v) || (z - 1 == c && x - 1 == v)) && pole.pole[c, v] != 1)
                        {
                            if (player == true)
                            {
                                pole.pole[c, v] = 3;
                                pole.pole[z, x] = 0;
                            }
                            player = !player;
                        }
                        else
                            Console.WriteLine("ход сделать невозможно");
                    }
                    else
                    {
                        if (pole.pole[c, v] == 3)
                        {
                            if (x > v)
                            {
                                if (pole.pole[c + 1, v - 1] == 0)
                                {
                                    pole.pole[c, v] = 0;
                                    pole.pole[z, x] = 0;
                                    pole.pole[c + 1, v - 1] = 2;
                                    player = !player;
                                }
                            }
                            else
                            {
                                if (pole.pole[c + 1, v + 1] == 0)
                                {
                                    pole.pole[c, v] = 0;
                                    pole.pole[z, x] = 0;
                                    pole.pole[c + 1, v + 1] = 2;
                                    player = !player;
                                }
                            }
                        }
                        else if (((z + 1 == c && x + 1 == v) || (z + 1 == c && x - 1 == v)) && pole.pole[c, v] != 1)
                        {
                            if(player == false)
                            {
                                pole.pole[c, v] = 2;
                                pole.pole[z, x] = 0;
                            }
                            player = !player;
                        }
                        else
                            Console.WriteLine("ход сделать невозможно");
                        }
                    }
                    else
                        Console.WriteLine("Нельзя трогать чужие фигуры и пустые клетки");
                }
                else
                    Console.WriteLine("Вы вышли за лимиты");
            }

        }
    }
class Pole
{
    public int white = 0; public int black = 0;
    public int[,] pole = {
    {1,2,1,2,1,2,1,2},//2 это черний 1 это не ходить
    {2,1,2,1,2,1,2,1},
    {1,2,1,2,1,2,1,2},
    {0,1,0,1,0,1,0,1},
    {1,0,1,0,1,0,1,0},
    {3,1,3,1,3,1,3,1},//3 это белый 1 это не ходить
    {1,3,1,3,1,3,1,3},
    {3,1,3,1,3,1,3,1},
    };
    public void Pokaz()
    {
        white = 0; black = 0;
        for (int i = 0; i < pole.GetLength(0); i++)
        {
            if(i == 0)
            {
                Console.Write($"\t");
            }
            Console.Write($"{i}\t");
        }
        Console.WriteLine();
        for (int i = 0;i < pole.GetLength(0); i++)
        {
            Console.Write($"{i}\t");
            for (int j = 0; j < pole.GetLength(1); j++)
            {
                if (pole[i,j] == 0)
                    Console.Write("*\t");
                if (pole[i, j] == 1)
                    Console.Write("З\t");
                if (pole[i, j] == 2)
                {
                    Console.Write("Ч\t");
                    black++;
                }
                if (pole[i, j] == 3)
                {
                    Console.Write("Б\t");
                    white ++;
                }

            }
            Console.WriteLine();
        }
    }
}