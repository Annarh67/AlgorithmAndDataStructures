using System;


namespace second_programm
{
    /// <summary>
    /// Консольная программа "Угадай число".
    /// Пользователь угадывает случайное число от 1 до 100.
    /// Ведётся подсчёт минимального, максимального и среднего количества попыток.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Главный метод программы.
        /// Запускает игровой цикл, обрабатывает ввод пользователя
        /// и выводит статистику после завершения игры.
        /// </summary>
        /// <param name="args">Аргументы командной строки</param>
        static void Main(string[] args)
        {
            // минимальное количество попыток
            int min = 0;

            // максимальное количество попыток
            int max = 0;

            // общее количество попыток за все игры
            int count = 0;

            // количество сыгранных игр
            int countGame = 0;

            // генератор случайных чисел
            Random rnd = new Random();

            // переменная для повторения игры
            char answer = 'y';

            // цикл повторения игры
            do
            {
                int counter = 0; // счётчик попыток в одной игре
                int number = rnd.Next(1, 101); // случайное число

                while (true)
                {
                    counter++;
                    Console.WriteLine("Input number from [1;100]");

                    int userNumber = 0;

                    for (int i = 0; i < 3; i++)
                    {
                        if (!int.TryParse(Console.ReadLine(), out userNumber)
                            || userNumber > 100
                            || userNumber < 1)
                        {
                            Console.WriteLine("Input number from [1;100]");
                        }
                        else break;

                        if (i == 2)
                        {
                            Console.WriteLine("Wrong input. Program stopped.");
                            return;
                        }
                    }

                    if (userNumber > number)
                        Console.WriteLine("Your number is greater");
                    else if (userNumber < number)
                        Console.WriteLine("Your number is less");
                    else
                    {
                        Console.WriteLine("You win!");

                        if (min == 0 || min > counter)
                            min = counter;

                        if (counter > max)
                            max = counter;

                        count += counter;
                        countGame++;

                        break;
                    }
                }

                Console.WriteLine("Do you want play again?");
                answer = Convert.ToChar(Console.Read());

            } while (answer == 'y');

            Console.WriteLine($"min = {min} max = {max} avg = {(double)count / countGame}");
        }
    }
}