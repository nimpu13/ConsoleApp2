using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Player
    {
    static public Random random = new Random();
        //Инвентарь
        static public string helm;
        static public string armor;
        static public string hands;
        static public string legs;
        static public string boots;
        static public string weapon;
        static public string jewelery;

        public static void InventoryStats(ref int damage,ref int regen, ref int hp, ref int defense)
        {
            switch (weapon)
            {
                case "Меч востановления":
                    damage += 5;
                    regen += 5;
                    break;
                case "Магический меч":
                    damage += 5;
                    break;
                case "Железный меч":
                    damage += 3;
                    break;
                case "Деревяный мечь":
                    damage += 1;
                    break;
            }
            switch(helm)
            {
                case "Кожаный шлем":
                    defense += 1;
                    break;
                case "Железный шлем":
                    defense += 3;
                    break;
                case "Шлем берсерка":
                    defense -= 10;
                    damage += 10;
                    break;
                case "Шлем паладина":
                    defense += 5;
                    regen += 5;
                    break;
            }
            switch(armor)
            {
                case "Кожаный нагрудник":
                    defense += 1;
                    break;
                case "Железный нагрудник":
                    defense += 3;
                    break;
                case "Стальной нагрудник":
                    defense += 5;
                    break;
                case "Стеклянный нагрудник":
                    defense -= 5;
                    break;
            }
        }
        public static void InventoryInfo()
        {
            //Получение информации об экиперовке (дописать инфо об свойствах экипировки)
            switch (Console.ReadKey(false).Key)
            {
                case ConsoleKey.D1:
                    Console.WriteLine($"Шлем: {helm}");
                    break;
                case ConsoleKey.D2:
                    Console.WriteLine($"Нагрудник: {armor}");
                    break;
                case ConsoleKey.D3:
                    Console.WriteLine($"Перчатки: {hands}");
                    break;
                case ConsoleKey.D4:
                    Console.WriteLine($"Поножи: {legs}");
                    break;
                case ConsoleKey.D5:
                    Console.WriteLine($"Обувь: {boots}");
                    break;
                case ConsoleKey.D6:
                    Console.WriteLine($"Оружие: {weapon}");
                    break;
                case ConsoleKey.D7:
                    Console.WriteLine($"Амулет: {jewelery}");
                    break;
                case ConsoleKey.D8:
                    Console.WriteLine($"Ваше снаряжение: {helm}\n{armor}\n{hands}\n{legs}\n{boots}\n{weapon}\n{jewelery}");
                    break;
            }
        }

        //----------------
        public int damage = 20;
        public int hp = 100;
        public int maxHp = 100;
        public int regen = 1;
        static public string name = "P ";
        public int x;
        public int y;
        public Player()
        {
            ClassMenu(ref damage, ref hp, ref maxHp, ref regen);
        Pspawn:
            if (Program.map2[x, y] != "X ")
            {
                x = random.Next(0, 10);
                y = random.Next(0, 10);
                Program.map2[x, y] = name;
            }
            else
                goto Pspawn;
        }
        static void ClassMenu(ref int damage, ref int hp, ref int maxHp, ref int regen)
        {
            Console.WriteLine("Выберите класс\n1)Воин\n2)Убийца");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    Console.WriteLine("Вы выбрали класс Воин");
                    break;
                case ConsoleKey.D2:
                    Console.WriteLine("Вы выбрали класс Убийца");
                    damage = 40;
                    hp = 50;
                    maxHp = 50;
                    regen = 2;
                    break;
            }
        }
        public static void Move(ref string[,] map, ref int x, ref int y, ref int php)
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.LeftArrow:
                    if (y > 0)
                    {
                        if (map[x, y - 1] == "X ") Console.WriteLine("Вы не умете ходить сквоь стены!!!");
                        else
                        {
                            map[x, y] = ". ";
                            y--;
                            map[x, y] = Player.name;
                        }
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (y < 10 && map[x, y + 1] != "X ")
                    {
                        map[x, y] = ". ";
                        y++;
                        map[x, y] = Player.name;
                    }
                    else Console.WriteLine("Вы не умете ходить сквоь стены!!!");

                    break;
                case ConsoleKey.UpArrow:
                    if (x > 0 && map[x - 1, y] != "X ")
                    {
                        map[x, y] = ". ";
                        x--;
                        map[x, y] = Player.name;
                    }
                    else Console.WriteLine("Вы не умете ходить сквоь стены!!!");
                    break;
                case ConsoleKey.DownArrow:
                    if (x < 10 && map[x + 1, y] != "X ")
                    {
                        map[x, y] = ". ";
                        x++;
                        map[x, y] = Player.name;
                    }
                    else Console.WriteLine("Вы не умете ходить сквоь стены!!!");
                    break;
                case ConsoleKey.Escape:
                    Program.escape = true;
                    break;
                case ConsoleKey.Spacebar:
                    php += 4;
                    break;
            }
        }

    }
}
