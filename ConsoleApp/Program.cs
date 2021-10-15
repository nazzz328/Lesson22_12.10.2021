using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ConsoleApp
{
    class Program
    {
        static object locker = new object();
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            var task1 = Task.Run(() => { FallingString(0); });
            var task11 = Task.Run(() => { FallingString(0); Thread.Sleep(new Random().Next(0, 2000)); });
            var task2 = Task.Run(() => { FallingString(7); });
            var task22 = Task.Run(() => { FallingString(7); Thread.Sleep(new Random().Next(0, 2000)); });
            var task3 = Task.Run(() => { FallingString(9); });
            var task33 = Task.Run(() => { FallingString(9); Thread.Sleep(new Random().Next(0, 2000)); });
            var task4 = Task.Run(() => { FallingString(23); });
            var task44 = Task.Run(() => { FallingString(23); Thread.Sleep(new Random().Next(0, 2000)); });
            var task5 = Task.Run(() => { FallingString(45); });
            var task55 = Task.Run(() => { FallingString(45); Thread.Sleep(new Random().Next(0, 2000)); });
            var task6 = Task.Run(() => { FallingString(48); });
            var task66 = Task.Run(() => { FallingString(48); Thread.Sleep(new Random().Next(0, 2000)); });
            var task7 = Task.Run(() => { FallingString(53); });
            var task77 = Task.Run(() => { FallingString(53); Thread.Sleep(new Random().Next(0, 2000)); });
            var task8 = Task.Run(() => { FallingString(64); });
            var task88 = Task.Run(() => { FallingString(64); Thread.Sleep(new Random().Next(0, 2000)); });
            var task9 = Task.Run(() => { FallingString(67); });
            var task99 = Task.Run(() => { FallingString(67); Thread.Sleep(new Random().Next(0, 2000)); });
            var task10 = Task.Run(() => { FallingString(78); });
            var task1010 = Task.Run(() => { FallingString(78); Thread.Sleep(new Random().Next(0, 2000)); });
            var task111 = Task.Run(() => { FallingString(86); });
            var task1111 = Task.Run(() => { FallingString(86); Thread.Sleep(new Random().Next(0, 2000)); });
            Console.ReadLine();
        }

        public static void RandomString(int lineLength, int leftShift)
        {
            lock (locker)
            {
                var random = new Random();
                string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                char[] arrayOfChars = Enumerable.Repeat(chars, lineLength).Select(s => s[random.Next(s.Length)]).ToArray();
                arrayOfChars[0] = ' ';
                for (int i = 0; i < arrayOfChars.Length; i++)
                {
                    if (i == arrayOfChars.Length - 1)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.CursorLeft = leftShift;
                        Console.WriteLine(arrayOfChars[i]);
                        Console.ResetColor();
                    }
                    else if (i == arrayOfChars.Length - 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.CursorLeft = leftShift;
                        Console.WriteLine(arrayOfChars[i]);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.CursorLeft = leftShift;
                        Console.WriteLine(arrayOfChars[i]);
                        Console.ResetColor();
                    }
                }
            }
        }
        public static void FallingString(int leftShift)
        {
            Thread.Sleep(new Random().Next(0, 2000));
            while (true)
            {

                int lineLength = new Random().Next(10, 15);
                int j = 0;
                lock (locker)
                {
                    Console.CursorTop = 0;
                }
                for (; j < 40; j++)
                {
                    if (j < (25))
                    {
                        lock (locker)
                        {
                            Console.CursorLeft = leftShift;
                            Console.CursorTop = j;
                        }
                        lock (locker)
                        {
                            RandomString(lineLength, leftShift);
                        }
                        Thread.Sleep(20);
                    }
                    else
                    {
                        lock (locker)
                        {
                            Console.CursorLeft = leftShift;
                            Console.CursorTop = j;
                        }
                        Console.Write(" ");
                        Thread.Sleep(50);
                    }
                }

            }
        }
    }
}

