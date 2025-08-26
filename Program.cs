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
        Console.WriteLine("██╗      ██████╗ ███╗   ██╗ ██████╗     ██████╗  ██████╗  █████╗ ██████╗ ");
        Console.WriteLine("██║     ██╔═══██╗████╗  ██║██╔════╝     ██╔══██╗██╔═══██╗██╔══██╗██╔══██╗");
        Console.WriteLine("██║     ██║   ██║██╔██╗ ██║██║  ███╗    ██████╔╝██║   ██║███████║██║  ██║");
        Console.WriteLine("██║     ██║   ██║██║╚██╗██║██║   ██║    ██╔══██╗██║   ██║██╔══██║██║  ██║");
        Console.WriteLine("███████╗╚██████╔╝██║ ╚████║╚██████╔╝    ██║  ██║╚██████╔╝██║  ██║██████╔╝");
        Console.WriteLine("╚══════╝ ╚═════╝ ╚═╝  ╚═══╝ ╚═════╝     ╚═╝  ╚═╝ ╚═════╝ ╚═╝  ╚═╝╚═════╝ ");
        Random rnd = new Random();
        bool isRunning = true;
        while (isRunning)
        {
            Console.WriteLine("1. Начать игру\n2. Выйти из игры\n 3. информация об игре");

            byte choice;
            if (!byte.TryParse(Console.ReadLine(), out choice) || choice > 2 || choice < 1)
            {
                choice = 2;     
            }
            switch (choice)
            {
                case 1:
                    vibor();
                    break;
                case 2:
                    isRunning = false;
                    break;
                case 3:
                    Console.WriteLine("Игра представляет из себя текстовый квест, в котором вы выбираете маршрут и принимаете решения, влияющие на награду в конце пути. В игре есть элементы случайности, которые добавляют непредсказуемости и разнообразия в игровой процесс. Цель игры - достичь цели с максимальной наградой, принимая обдуманные решения и справляясь с неожиданными событиями на пути.");
                    break;
            }
            static void vibor()
            {
                Console.WriteLine("Выберите маршрут:\n1.соседний лагерь:короткий, и мало оплачиваемый маршрут \n2.пригород:Дорога до пригорода займет больше времени, около 5 дней, но и награда будет больше \n3. бункер военных: Дорога до военного бункера займет около 7 дней, но и награда будет максимальная ");
                byte dif;
                byte days = 0;
                if (!byte.TryParse(Console.ReadLine(), out dif) || dif > 3 || dif < 1)
                {
                    dif = 2;
                }
                switch (dif)
                {
                    case 1:
                        Thread.Sleep(1000);
                        Game(2);
                        
                        break;
                    case 2:
                        Thread.Sleep(1000);
                        Game(5);
                        break;
                    case 3:
                        Thread.Sleep(1000);
                        Game(7);
                        break;
                }
            }
            static void Game(byte dayz)
            {
                Random rnd = new Random();
                Thread.Sleep(1000);
                Console.WriteLine("Помните, всегда будьте осторожны!\n");
                Thread.Sleep(1000);
                byte rew = 100;
                byte evch = 0;
                for (byte day = 1; day <= dayz; day++)
                    
                {
                    switch (dayz)
                    
                    {
                        case 2:
                            evch = Convert.ToByte(rnd.Next(1, 5));
                            break;
                        case 5:
                            evch = Convert.ToByte(rnd.Next(3, 7));
                            break;
                        case 7:
                            evch = Convert.ToByte(rnd.Next(5, 11));
                            break;  
                    }
                    switch (evch)
                    {
                        case 4:
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
                        case 7:
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
                        case 2:
                            Console.WriteLine("Впереди густой туман, объехать?\n1.Да\n2.Нет\n");
                            byte anse;
                            if (!byte.TryParse(Console.ReadLine(), out anse) || anse > 2 || anse < 1)
                            {
                                anse = 1;
                            }
                            if (anse == 2)
                            {
                                byte e = Convert.ToByte(rnd.Next(1, 3));
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
                        case 5:
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
                        case 9:
                            Console.WriteLine("Засада рейдеров! Дать отпор?\n1.Да\n2.Нет\n");
                            byte an;
                            if (!byte.TryParse(Console.ReadLine(), out an) || an > 2 || an < 1)
                            {
                                an = 2;
                            }

                            if (an == 1)
                            {
                                byte pv = Convert.ToByte(rnd.Next(1, 3));
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
                        case 3:
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
                        case 6:
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
                        case 1:
                            System.Console.WriteLine("День прошел спокойно, вы не встретили ничего необычного\n");
                            break;
                        case 10:
                            System.Console.WriteLine("Вы нашли военный бункер, осмотреть?\n1.Да\n2.Нет\n");
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
                                    Console.WriteLine("В бункере вы нашли остатки снаряжения и медикаментов, награда увеличена\n");
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
                        case 8:
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
            
        }
    }
}
