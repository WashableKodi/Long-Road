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
using System.Text.Json;
using Microsoft.VisualBasic;
public static class After
{
    public static bool gam = false;
}

internal class Long_Road
{

    static void Main()
    {
        Random rnd = new Random();
        bool isRunning = true;
        while (isRunning)

        {
            Zagalovok();
            Console.WriteLine("1. Начать игру\n2. Выйти из игры\n3. информация об игре \n4.Достижения");
            sbyte choice;
            choice = Convert.ToSByte(Console.ReadLine());
            if (choice < 1 || choice > 4)
            {
                System.Console.WriteLine("Неверный ввод, попробуйте снова.");
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
                case 4:
                    opened_achievements();
                    Thread.Sleep(1000);
                    break;
                default:
                    Console.WriteLine("Неверный ввод, попробуйте снова.");
                    break;

            }




            static void vibor()
            {
                Console.WriteLine("Выберите маршрут:\n1.соседний лагерь: короткий, и мало оплачиваемый маршрут \n2.пригород: Дорога до пригорода займет больше времени, около 5 дней, но и награда будет больше \n3.бункер военных: Дорога до военного бункера займет около 7 дней, но и награда будет максимальная ");
                sbyte dif;
                sbyte days = 0;
                if (!sbyte.TryParse(Console.ReadLine(), out dif) || dif > 3 || dif < 1)
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


            static void opened_achievements()
            {
                var Achievements = AchievementManager.Read();
                achievement();
                if (Achievements.AA)
                {
                    Console.WriteLine("Магнат - Достигнуть награды в 150 или больше");
                }
                if (Achievements.AB)
                {
                    Console.WriteLine("Боец - Отразить 3 или больше засад рейдеров");
                }
                if (Achievements.AC)
                {
                    Console.WriteLine("Исследователь - Осмотреть 5 или больше заброшенных мест");
                }
                if (Achievements.AD)
                {
                    Console.WriteLine("Лидер - встретить 5 или больше групп выживших");
                }
                if (Achievements.AE)
                {
                    Console.WriteLine("Милосердный - Помочь 3 или больше людям на пути");
                }
                if (Achievements.AF)
                {
                    Console.WriteLine("Пацифист - Не участвовать в боях с рейдерами");
                }
                else
                {
                    Console.WriteLine("У вас нет открытых достижений");
                }
                Console.ReadKey();
            }




            static void Game(byte dayz)
            {
                var Achievements = AchievementManager.Read();
                Random rnd = new Random();
                Thread.Sleep(1000);
                Console.WriteLine("Помните, всегда будьте осторожны!\n");
                Thread.Sleep(1000);

                short rew = 100;
                sbyte evch = 0;
                sbyte med = 5;
                sbyte food = 7;
                sbyte ammo = 3;
                sbyte fuel = 10;
                sbyte repair = 5;
                sbyte money = 120;

                for (sbyte day = 1; day <= dayz && rew > 0; day++)
                {
                    switch (dayz)
                    {
                        case 2:
                            evch = Convert.ToSByte(rnd.Next(1, 5));
                            break;
                        case 5:
                            evch = Convert.ToSByte(rnd.Next(3, 7));
                            break;
                        case 7:
                            evch = Convert.ToSByte(rnd.Next(5, 11));
                            break;
                    }

                    switch (evch)
                    {
                        case 1:
                            Console.WriteLine("День прошел спокойно, вы не встретили ничего необычного\n");
                            break;

                        case 2:
                            Console.WriteLine("Впереди густой туман, объехать?\n1.Да -2 топлива \n2.Нет\n");
                            sbyte anse;
                            if (!sbyte.TryParse(Console.ReadLine(), out anse) || anse > 2 || anse < 1)
                            {
                                anse = 1;
                            }
                            if (anse == 2)
                            {
                                sbyte e = Convert.ToSByte(rnd.Next(1, 3));
                                if (e == 1)
                                {
                                    Console.WriteLine("В тумане ничего не было, и вы прохали без проблем\n");
                                }
                                else
                                {
                                    Console.WriteLine("В тумане вы не заметили яму и повредили транспорт\n");
                                    repair -= 2;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Вы объехали туман\n");
                                fuel -= 2;
                            }
                            break;

                        case 3:
                            Console.WriteLine("Вы нашли заброшенный магазин, осмотреть?\n1.Да -2 топлива\n2.Нет\n");
                            sbyte answq;
                            if (!sbyte.TryParse(Console.ReadLine(), out answq) || answq > 2 || answq < 1)
                            {
                                answq = 1;
                            }
                            if (answq == 1)
                            {
                                Achievements.C++;
                                int ev = rnd.Next(1, 3);
                                if (ev == 1)
                                {
                                    Console.WriteLine("В магазине вы нашли немного еды и медикаментов, награда увеличена\n");
                                    food += 3;
                                    med += 2;
                                    fuel -= 2;
                                }
                                else
                                {
                                    Console.WriteLine("В магазине ничего не было\n");
                                    fuel -= 2;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Вы проехали мимо магазина\n");
                            }
                            break;

                        case 4:
                            Console.WriteLine("Найден пустой лагерь, осмотреть?\n1.Да\n2.Нет\n");
                            sbyte ans;
                            if (!sbyte.TryParse(Console.ReadLine(), out ans) || ans > 2 || ans < 1)
                            {
                                ans = 1;
                            }
                            if (ans == 1)
                            {
                                int ev = rnd.Next(1, 3);
                                if (ev == 1)
                                {
                                    Console.WriteLine("Найдено немного еды, запасы еды увеличены\n");
                                    food += 3;
                                }
                                else
                                {
                                    Console.WriteLine("На вас напали рейдеры!\n");
                                    if (ammo >= 2)
                                    {
                                        Console.WriteLine("К счастью у вас была аммуниция, и вы смогли отбиться от них\n");
                                        ammo -= 1;
                                    }
                                    else
                                    {
                                        Console.WriteLine("У вас не было аммуниции, и вы потеряли часть медикаментов в бою\n");
                                        med -= 2;
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Вы проехали лагерь\n");
                            }
                            break;

                        case 5:
                            Console.WriteLine("Вы видите несколько раненых военных, помочь?\n1.Да\n2.Нет\n");
                            sbyte ansr;
                            if (!sbyte.TryParse(Console.ReadLine(), out ansr) || ansr > 2 || ansr < 1)
                            {
                                ansr = 2;
                            }
                            if (ansr == 1)
                            {
                                Achievements.E++;
                                int ve = rnd.Next(1, 3);
                                if (ve == 1)
                                {
                                    Console.WriteLine("Вы довезли военных до их лагеря и они поделились провизией, награда увеличена!\n");
                                    food += 3;
                                }
                                else
                                {
                                    Console.WriteLine("Из-за военных вам пришлось отдать 20 монет на блокпосте рейдеров\n");
                                    money -= 20;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Вы оставили военных\n");
                            }
                            break;

                        case 6:
                            Console.WriteLine("Вы поймали странный сигнал по радио, последовать за сигналом? \n1.Да ( -1 топливо)\n2.Нет\n");
                            sbyte answe;
                            if (!sbyte.TryParse(Console.ReadLine(), out answe) || answe > 2 || answe < 1)
                            {
                                answe = 1;
                            }
                            if (answe == 1)
                            {
                                fuel -= 1;
                                int ev = rnd.Next(1, 3);
                                if (ev == 1 && ammo > 2 && fuel > 1)
                                {
                                    Console.WriteLine("Сигнал привел вас к группе выживших, на которых напали рейдеры. Вы помогли им отбиться и они поделились с вами провизией\n");
                                    food += 3;
                                    ammo -= 2;
                                    Achievements.D++;
                                }
                                else if (ev == 1 && (ammo <= 2 || fuel <= 1))
                                {
                                    Console.WriteLine("Сигнал привел вас к группе выживших, на которых напали рейдеры. Вы не смогли им помочь из-за нехватки припасов\n");
                                }
                                else
                                {
                                    Console.WriteLine("На месте оказался пустой лагерь в котором вы ничего не нашли\n");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Вы проигнорировали сигнал\n");
                            }
                            break;

                        case 7:
                            Console.WriteLine("Вы слышите выстрелы, проверить?\n1.Да\n2.Нет\n");
                            sbyte answ;
                            if (!sbyte.TryParse(Console.ReadLine(), out answ) || answ > 2 || answ < 1)
                            {
                                answ = 1;
                            }
                            if (answ == 1)
                            {
                                int ev = rnd.Next(1, 3);
                                if (ev == 1)
                                {
                                    Console.WriteLine("На месте вы обнаружили несколько ящиков с амуницией\n");
                                    ammo += 3;
                                }
                                else
                                {
                                    Console.WriteLine("Вы попали в самый разгар перестрелки и несколько человек были ранены\n");
                                    med -= 3;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Вы проехали мимо\n");
                            }
                            break;

                        case 8:
                            Console.WriteLine("Вы увидели вдалеке дым, проверить?\n1.Да\n2.Нет\n");
                            sbyte answqz;
                            if (!sbyte.TryParse(Console.ReadLine(), out answqz) || answqz > 2 || answqz < 1)
                            {
                                answqz = 1;
                            }
                            if (answqz == 1)
                            {
                                int ev = rnd.Next(1, 3);
                                if (ev == 1)
                                {
                                    Console.WriteLine("Вы нашли группу выживших, они поделились с вами провизией, награда увеличена\n");
                                    food += 3;
                                }
                                else
                                {
                                    Console.WriteLine("Вы нашли группу выживших, сначала они казались дружелюбными, но потом напали\n");
                                    if (ammo >= 2)
                                    {
                                        Console.WriteLine("К счастью у вас была аммуниция, и вы смогли отбиться от них\n");
                                        ammo -= 2;
                                    }
                                    else
                                    {
                                        Console.WriteLine("У вас не было аммуниции, и вы потеряли часть медикаментов в бою\n");
                                        med -= 5;
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Вы проигнорировали дым\n");
                            }
                            break;

                        case 9:
                            Console.WriteLine("Засада рейдеров! Дать отпор?\n1.Да\n2.Нет\n");
                            sbyte an;
                            if (!sbyte.TryParse(Console.ReadLine(), out an) || an > 2 || an < 1)
                            {
                                an = 2;
                            }

                            if (an == 1)
                            {
                                Achievements.F++;
                                byte pv = Convert.ToByte(rnd.Next(1, 3));
                                if (pv == 1)
                                {
                                    Console.WriteLine("Вы смогли отбиться от рейдеров и взять часть их вещей\n");
                                    Achievements.B++;
                                    ammo += 2;
                                }
                                else
                                {
                                    Console.WriteLine("Рейдеры оказались сильнее и помимо откупа вам пришлось отдать еще немного припасов\n");
                                    money -= 25;
                                    food -= 2;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Вы отдали выкуп\n");
                                money -= 20;
                            }
                            break;

                        case 10:
                            Console.WriteLine("Вы нашли военный бункер, осмотреть?\n1.Да\n2.Нет\n");
                            sbyte answz;
                            if (!sbyte.TryParse(Console.ReadLine(), out answz) || answz > 2 || answz < 1)
                            {
                                answz = 1;
                            }
                            if (answz == 1)
                            {
                                Achievements.C++;
                                int ev = rnd.Next(1, 3);
                                if (ev == 1)
                                {
                                    Console.WriteLine("В бункере вы нашли остатки снаряжения и медикаментов, награда увеличена\n");
                                    ammo += 5;
                                    med += 5;
                                }
                                else
                                {
                                    Console.WriteLine("В бункере были зомби, часть медикаментов потеряна\n");
                                    med -= 10;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Вы проехали мимо бункера\n");
                            }
                            break;
                    }



                    if (med <= 0 || food <= 0 || fuel <= 0 || repair <= 0)
                    {
                        Console.WriteLine("Вы не смогли продолжить путь из-за нехватки припасов. Игра окончена.\n");
                        rew = 0;
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"У вас {food} единиц еды, {money} монет, {fuel} единиц топлива, {med} медикаментов и {ammo} аммуниции. Наступает следующий день (-1 топливо, -1 еда)\n");
                        fuel -= 1;
                        food -= 1;
                        Thread.Sleep(2000);
                    }
                }

                if (rew > 0)
                {
                    rew += money;
                    Console.WriteLine($"Вы достигли цели, ваша награда {rew}\n");
                    After.gam = true;

                    Achievements.A = Convert.ToByte(rew);
                    AchievementManager.Write(Achievements);
                    achievement();
                }

                Achievements.F = 0;
                AchievementManager.Write(Achievements);
            }
            static void Zagalovok()
            {
                Console.WriteLine("██╗      ██████╗ ███╗   ██╗ ██████╗     ██████╗  ██████╗  █████╗ ██████╗ ");
                Console.WriteLine("██║     ██╔═══██╗████╗  ██║██╔════╝     ██╔══██╗██╔═══██╗██╔══██╗██╔══██╗");
                Console.WriteLine("██║     ██║   ██║██╔██╗ ██║██║  ███╗    ██████╔╝██║   ██║███████║██║  ██║");
                Console.WriteLine("██║     ██║   ██║██║╚██╗██║██║   ██║    ██╔══██╗██║   ██║██╔══██║██║  ██║");
                Console.WriteLine("███████╗╚██████╔╝██║ ╚████║╚██████╔╝    ██║  ██║╚██████╔╝██║  ██║██████╔╝");
                Console.WriteLine("╚══════╝ ╚═════╝ ╚═╝  ╚═══╝ ╚═════╝     ╚═╝  ╚═╝ ╚═════╝ ╚═╝  ╚═╝╚═════╝ ");
            }



            static void achievement()
            {
                var Achievements = AchievementManager.Read();
                //магнат
                if (Achievements.A >= 150)
                {
                    if (!Achievements.AA && After.gam)
                    {
                        Console.WriteLine("Достижение разблокировано: Магнат - Достигнуть награды в 150 или больше");
                    }
                    Achievements.AA = true;
                }
                //боец
                if (Achievements.B >= 3)
                {
                    if (!Achievements.AB && After.gam)
                    {
                        Console.WriteLine("Достижение разблокировано: Боец - Отразить 3 или больше засад рейдеров");
                    }
                    Achievements.AB = true;
                }
                //исследователь
                if (Achievements.C >= 5)
                {
                    if (!Achievements.AC && After.gam)
                    {
                        Console.WriteLine("Достижение разблокировано: Исследователь - Осмотреть 5 или больше заброшенных мест");
                    }
                    Achievements.AC = true;

                }
                //лидер
                if (Achievements.D >= 5)
                {
                    if (!Achievements.AD && After.gam)
                    {
                        Console.WriteLine("Достижение разблокировано: Лидер - встретить 5 или больше групп выживших");
                    }
                    Achievements.AD = true;
                }
                //милосердный
                if (Achievements.E >= 3)
                {
                    if (!Achievements.AE && After.gam)
                    {
                        Console.WriteLine("Достижение разблокировано: Милосердный - Помочь 3 или больше людям на пути");
                    }
                    Achievements.AE = true;
                }
                //пацифист
                if (Achievements.F == 0)
                {
                    if (!Achievements.AF && After.gam)
                    {
                        Console.WriteLine("Достижение разблокировано: Пацифист - Не участвовать в боях с рейдерами");
                    }
                    Achievements.AF = true;

                }
                AchievementManager.Write(Achievements);
            }
        }
    }
}




    public class Achievements
{
    public byte A { get; set; }
    public byte B { get; set; }
    public byte C { get; set; }
    public byte D { get; set; }
    public byte E { get; set; }
    public byte F { get; set; }
    public bool AA { get; set; }
    public bool AB { get; set; }
    public bool AC { get; set; }
    public bool AD { get; set; }
    public bool AE { get; set; }
    public bool AF { get; set; }

}





public static class AchievementManager
{
    private static string file = "achievements.json";

    public static Achievements Read()
    {
        if (File.Exists(file))
        {
            string json = File.ReadAllText(file);
            return JsonSerializer.Deserialize<Achievements>(json);
        }
        return new Achievements();
    }


    public static void Write(Achievements achievements)
    {
        string json = JsonSerializer.Serialize(achievements, new JsonSerializerOptions
        {
            WriteIndented = true
        });
        File.WriteAllText(file, json);
    }


    public static void Change(string variableName, byte newValue)
    {
        var achievements = Read();

        switch (variableName.ToUpper())
        {
            case "A": achievements.A = newValue; break;
            case "B": achievements.B = newValue; break;
            case "C": achievements.C = newValue; break;
            case "D": achievements.D = newValue; break;
            case "E": achievements.E = newValue; break;
        }

        Write(achievements);
    }

    }