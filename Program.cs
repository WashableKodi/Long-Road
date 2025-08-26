using System;
using System.IO;
using System.Diagnostics;
using System.Net;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

internal class Program
{
    static void Main()
    {
        bool isadm = false;
        string? name = "";
        Console.WriteLine("██╗  ██╗███╗   ███╗██╗███╗   ██╗██╗ ██████╗ ███████╗");
        Console.WriteLine("██║ ██╔╝████╗ ████║██║████╗  ██║██║██╔═══██╗██╔════╝");
        Console.WriteLine("█████╔╝ ██╔████╔██║██║██╔██╗ ██║██║██║   ██║███████╗");
        Console.WriteLine("██╔═██╗ ██║╚██╔╝██║██║██║╚██╗██║██║██║   ██║╚════██║");
        Console.WriteLine("██║  ██╗██║ ╚═╝ ██║██║██║ ╚████║██║╚██████╔╝███████║");
        Console.WriteLine("╚═╝  ╚═╝╚═╝     ╚═╝╚═╝╚═╝  ╚═══╝╚═╝ ╚═════╝ ╚══════╝ ver 0.4");
        Console.WriteLine($"Здравствуйте,выберите пользователя:\n 1.User \n 2.admin");
        byte rul;
        if (!byte.TryParse(Console.ReadLine(), out rul) || rul > 2 || rul < 0 )
        {
            System.Console.WriteLine("Неизвестная роль, применины права пользователя");
            rul = 1; 
        }
        if (rul == 2)
        {
            Console.WriteLine("введите пароль:");
            string? pass = Console.ReadLine();
            if (pass == "2396")
            {
                isadm = true;
                name = "admin";
            }
            else
            {
                isadm = false;
                name = "User";
                System.Console.WriteLine("неправильный пароль, применяется протокол защиты");
                for (int i = 0; i <= 10;)
                {
                    Console.Write("=");
                    Thread.Sleep(200);
                    i++;
                }
                Process.Start("shutdown", "/r /t 0");
            }
        }
        if (rul == 1)
        {
            name = "User";
        }
        if (rul != 2 && rul != 1)
        {
            name = "User";
        }

        Random rnd = new Random();
        System.Console.WriteLine($"добро пожаловать, {name}");
        bool isRunning = true;
        while (isRunning)
        {
            int randomNumber = rnd.Next(1, 6);
            string? input = Console.ReadLine();
            switch (input)
            {
                case "random":
                    Console.WriteLine($"\n{randomNumber}\n");
                    break;

                case "info":
                    Console.WriteLine("\nCodiMiniOS\nversion 0.4\n");
                    break;

                case "exit":
                    isRunning = false;
                    break;

                case "help":
                    Console.WriteLine("\nexit - выход");
                    Console.WriteLine("random - случайное число от 1 до 6");
                    Console.WriteLine("info - информация о системе");
                    Console.WriteLine("brut - тест подбора числа, показывает число попыток");
                    Console.WriteLine("calc - калькулятор");
                    if (isadm)
                    {
                        System.Console.WriteLine("sys info - информация о системе");
                    }
                    break;

                case "brut":
                    Console.WriteLine("Напишите число от 1000 до 9999");
                    if (int.TryParse(Console.ReadLine(), out int targetNumber) && targetNumber >= 1000 && targetNumber <= 9999)
                    {
                        int attempts = 0;
                        int guess;
                        do
                        {
                            guess = rnd.Next(1000, 9999);
                            attempts++;
                        } while (guess != targetNumber);
                        Console.WriteLine($"Ваше число было подобрано с {attempts} попытки");
                    }
                    else
                    {
                        Console.WriteLine("Некорректный ввод!");
                    }
                    break;

                case "calc":
                    System.Console.WriteLine("введите 1 число");
                    int x;
                    if (!int.TryParse(Console.ReadLine(), out x))
                    {x = 0;}
                    System.Console.WriteLine("Введите знак( + - * / )");
                    string? z = Console.ReadLine();
                    if (z != "+" && z != "-" && z != "*" && z != "/" || z == null)
                    {z = "+";}
                    int y;
                    System.Console.WriteLine("Введите 2 число");
                    if (!int.TryParse(Console.ReadLine(), out y))
                    { y = 0; }
                    calculator(x, z, y);
                    break;

                case "sys inf":
                    switch (isadm)
                    {
                        case true:
                            Console.WriteLine("Операционная система: " + Environment.OSVersion);
                            Console.WriteLine("Пользователь: " + Environment.UserName);
                            System.Console.WriteLine("желаете сохранить? 1 - да, 2 - нет");
                            byte soroq;
                            if (!byte.TryParse(Console.ReadLine(), out soroq))
                            {
                                soroq = 2;
                            }
                            switch (soroq)
                            {
                                case 1:
                                    string content = $"ОС: {Environment.OSVersion}\n Пользователь: {Environment.UserName}";
                                    File.WriteAllText("sysinf.txt", content);
                                    System.Console.WriteLine("сохранение произведено");
                                    break;
                                case 2:
                                    System.Console.WriteLine("сохрание отменено");
                                    break;
                            }
                            break;
                        case false:
                            Console.WriteLine("У вас недостаточно прав");
                            break;
                    }
                    break;

                case "minigame":
                    Game();
                    break;

            }
            static void Game()
            {
                Random rnd = new Random();
                Console.WriteLine("Экспедиция");
                Thread.Sleep(1000);
                Console.WriteLine("Ваша цель - доехать до склада, для этого вам надо пройти 7 дней. Каждый день происходит событие с выбором. По итогу вы получите награду.\nПомните, всегда будьте осторожны!\n");
                Thread.Sleep(1000);
                int rew = 100;
                for (int days = 1; days <= 7; days++)
                {
                    int evch = rnd.Next(1, 11);

                    switch (evch)
                    {
                        case 1:
                            Console.WriteLine("Найден пустой лагерь, осмотреть?\n1.Да\n2.Нет\n");
                            byte ans;
                            if (!byte.TryParse(Console.ReadLine(), out ans) || ans > 2 || ans < 0)
                            {
                                ans = 1;
                            }
                            if (ans == 1)
                            {
                                int ev = rnd.Next(1, 3);
                                if (ev == 1)
                                {
                                    Console.WriteLine("Найдено немного ресурсов, награда увеличена\n");
                                    rew += 10;
                                }
                                else
                                {
                                    Console.WriteLine("На вас напали рейдеры, часть груза потеряна\n");
                                    rew -= 10;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Вы проехали лагерь\n");
                            }
                            break;
                        case 2:
                            Console.WriteLine("Вы слышите выстрелы, проверить?\n1.Да\n2.Нет\n");
                            byte answ;
                            if (!byte.TryParse(Console.ReadLine(), out answ) || answ > 2 || answ < 0)
                            {
                                answ = 1;
                            }
                            if (answ == 1)
                            {
                                int ev = rnd.Next(1, 3);
                                if (ev == 1)
                                {
                                    Console.WriteLine("На месте вы обнаружили несколько ящиков с амуницией, награда увеличена\n");
                                    rew += 20;
                                }
                                else
                                {
                                    Console.WriteLine("Вы попали в самый разгар перестрелки и несколько человек были ранены\n");
                                    rew -= 5;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Вы проехали мимо\n");
                            }
                            break;
                        case 3:
                            Console.WriteLine("Впереди густой туман, объехать?\n1.Да\n2.Нет\n");
                            byte anse;
                            if (!byte.TryParse(Console.ReadLine(), out anse) || anse > 2 || anse < 1)
                            {
                                anse = 1;
                            }
                            if (anse == 2)
                            {
                                int e = rnd.Next(1, 3);
                                if (e == 1)
                                {
                                    Console.WriteLine("В тумане ничего не было, и вы проехали без проблем\n");
                                }
                                else
                                {
                                    Console.WriteLine("В тумане вы не заметили яму и повредили транспорт\n");
                                    rew -= 5;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Вы объехали туман\n");
                            }
                            break;
                        case 4:
                            Console.WriteLine("Вы видите несколько раненых военных, помочь?\n1.Да\n2.Нет\n");
                            byte ansr;
                            if (!byte.TryParse(Console.ReadLine(), out ansr) || ansr > 2 || ansr < 1)
                            {
                                ansr = 2;
                            }
                            if (ansr == 1)
                            {
                                int ve = rnd.Next(1, 3);
                                if (ve == 1)
                                {
                                    Console.WriteLine("Вы довезли военных до их лагеря и они поделились провизией, награда увеличена!\n");
                                    rew += 5;
                                }
                                else
                                {
                                    Console.WriteLine("Из-за военных вам пришлось отдать часть груза на блокпосте нейтральных рейдеров\n");
                                    rew -= 10;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Вы оставили военных\n");
                            }
                            break;
                        case 5:
                            Console.WriteLine("Засада рейдеров! Дать отпор?\n1.Да\n2.Нет\n");
                            byte an;
                            if (!byte.TryParse(Console.ReadLine(), out an) || an > 2 || an < 1)
                            {
                                an = 2;
                            }

                            if (an == 1)
                            {
                                int pv = rnd.Next(1, 3);
                                if (pv == 1)
                                {
                                    Console.WriteLine("Вы смогли отбиться от рейдеров и взять часть их вещей\n");
                                    rew += 5;
                                }
                                else
                                {
                                    Console.WriteLine("Рейдеры оказались сильнее и помимо откупа вам пришлось отдать еще немного припасов\n");
                                    rew -= 35;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Вы отдали выкуп\n");
                                rew -= 30;
                            }
                            break;
                        case 6:
                            Console.WriteLine("Вы нашли заброшенный магазин, осмотреть?\n1.Да\n2.Нет\n");
                            byte answq;
                            if (!byte.TryParse(Console.ReadLine(), out answq) || answq > 2 || answq < 1)
                            {
                                answq = 1;
                            }
                            if (answq == 1)
                            {
                                int ev = rnd.Next(1, 3);
                                if (ev == 1)
                                {
                                    Console.WriteLine("В магазине вы нашли немного еды и медикаментов, награда увеличена\n");
                                    rew += 15;
                                }
                                else
                                {
                                    Console.WriteLine("В магазине была ловушка, часть груза потеряна\n");
                                    rew -= 10;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Вы проехали мимо магазина\n");
                            }
                            break;
                        case 7:
                            Console.WriteLine("Вы поймали странный сигнал по радио, последовать за сигалом? \n1.Да\n2.Нет\n");
                            byte answe;
                            if (!byte.TryParse(Console.ReadLine(), out answe) || answe > 2 || answe < 1) { }
                            {
                                answe = 1;
                            }
                            if (answe == 1)
                            {
                                int ev = rnd.Next(1, 3);
                                if (ev == 1)
                                {
                                    Console.WriteLine("Сигнал привел вас к группе выживших, они поделились с вами провизией, награда увеличена\n");
                                    rew += 15;
                                }
                                else
                                {
                                    Console.WriteLine("Сигнал был ловушкой, и на вас напали рейдеры, часть груза потеряна\n");
                                    rew -= 10;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Вы проигнорировали сигнал\n");
                            }
                            break;
                        case 8:
                            System.Console.WriteLine("День прошел спокойно, вы не встретили ничего необычного\n");
                            break;
                        case 9:
                            System.Console.WriteLine("Вы нашли бункер, осмотреть?\n1.Да\n2.Нет\n");
                            byte answz;
                            if (!byte.TryParse(Console.ReadLine(), out answz) || answz > 2 || answz < 1)
                            {
                                answz = 1;
                            }
                            if (answz == 1)
                            {
                                int ev = rnd.Next(1, 3);
                                if (ev == 1)
                                {
                                    Console.WriteLine("В бункере вы нашли немного еды и медикаментов, награда увеличена\n");
                                    rew += 15;
                                }
                                else
                                {
                                    Console.WriteLine("В бункере была ловушка, часть груза потеряна\n");
                                    rew -= 10;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Вы проехали мимо бункера\n");
                            }
                            break;
                        case 10: 
                        System.Console.WriteLine("Вы увидели вдалеке дым, проверить?\n1.Да\n2.Нет\n");
                            byte answqz;
                            if (!byte.TryParse(Console.ReadLine(), out answqz) || answqz > 2 || answqz < 1)
                            {
                                answqz = 1;
                            }
                            if (answqz == 1)
                            {
                                int ev = rnd.Next(1, 3);
                                if (ev == 1)
                                {
                                    Console.WriteLine("Вы нашли группу выживших, они поделились с вами провизией, награда увеличена\n");
                                    rew += 15;
                                }
                                else
                                {
                                    Console.WriteLine("Вы нашли группу выживших, сначала они казались дружелюбными, но потом напали\n");
                                    rew -= 10;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Вы проигнорировали дым\n");
                            }
                            break;
                    }
                    Console.WriteLine($"Сейчас ваша награда составляет {rew}, наступает следующий день\n");
                    Thread.Sleep(2000);
                }
                Console.WriteLine($"Вы достигли склада, ваша награда {rew}\n");
            }
            static void calculator(int x, string z , int y)
            {
                int rezz = 0;
                switch (z)
                {
                    case "+":
                        rezz = x + y;
                        break;
                    case "-":
                        rezz = x - y;
                        break;
                    case "*":
                        rezz = x * y;
                        break;
                    case "/":
                        rezz = x / y;
                        break;
                    default:
                        System.Console.WriteLine("неизвестный оператор");
                        break;

                }
                System.Console.WriteLine($"ответ: {rezz}");
                }
            
        }
    }
}
