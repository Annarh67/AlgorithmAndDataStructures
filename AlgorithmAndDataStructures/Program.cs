using System;

namespace second_programm
{
    /// <summary>
    /// Консольная программа "Угадай число".
    /// Пользователь угадывает случайное число от 1 до 100.
    /// Программа ведёт статистику: минимальное, максимальное и среднее число попыток.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Главный метод программы.
        /// Запускает игровой процесс и управляет всей логикой игры.
        /// </summary>
        /// <param name="args">Аргументы командной строки</param>
        static void Main(string[] args)
        {
            /// <summary>
            /// Минимальное количество попыток среди всех игр.
            /// </summary>
            int min = 0;

            /// <summary>
            /// Максимальное количество попыток среди всех игр.
            /// </summary>
            int max = 0;

            /// <summary>
            /// Общее количество попыток за все игры.
            /// Используется для вычисления среднего значения.
            /// </summary>
            int count = 0;

            /// <summary>
            /// Количество сыгранных игр.
            /// </summary>
            int countGame = 0;

            /// <summary>
            /// Генератор случайных чисел.
            /// Используется для создания числа, которое должен угадать пользователь.
            /// </summary>
            Random rnd = new Random();

            /// <summary>
            /// Переменная для хранения ответа пользователя.
            /// Если пользователь вводит 'y', игра повторяется.
            /// </summary>
            char answer = 'y';

            /// <summary>
            /// Основной цикл игры.
            /// Повторяется пока пользователь хочет продолжать играть.
            /// </summary>
            do
            {
                /// <summary>
                /// Счётчик попыток в текущей игре.
                /// </summary>
                int counter = 0;

                /// <summary>
                /// Случайное число от 1 до 100, которое должен угадать пользователь.
                /// </summary>
                int number = rnd.Next(1, 101);

                /// <summary>
                /// Цикл угадывания числа.
                /// Работает пока пользователь не угадает число.
                /// </summary>
                while (true)
                {
                    counter++;

                    Console.WriteLine("Input number from [1;100]");

                    /// <summary>
                    /// Число, введённое пользователем.
                    /// </summary>
                    int userNumber = 0;

                    /// <summary>
                    /// Цикл проверки корректности ввода.
                    /// Пользователь имеет три попытки ввести корректное число.
                    /// </summary>
                    for (int i = 0; i < 3; i++)
                    {
                        /// <summary>
                        /// Проверка: является ли ввод числом и находится ли он в диапазоне 1–100.
                        /// </summary>
                        if (!int.TryParse(Console.ReadLine(), out userNumber)
                            || userNumber > 100
                            || userNumber < 1)
                        {
                            Console.WriteLine("Input number from [1;100]");
                        }
                        else break;

                        /// <summary>
                        /// Если пользователь три раза ввёл неправильное значение,
                        /// программа завершает работу.
                        /// </summary>
                        if (i == 2)
                        {
                            Console.WriteLine("Wrong input. Program stopped.");
                            return;
                        }
                    }

                    /// <summary>
                    /// Сравнение числа пользователя с загаданным числом.
                    /// </summary>
                    if (userNumber > number)
                        Console.WriteLine("Your number is greater");
                    else if (userNumber < number)
                        Console.WriteLine("Your number is less");
                    else
                    {
                        Console.WriteLine("You win!");

                        /// <summary>
                        /// Обновление минимального количества попыток.
                        /// </summary>
                        if (min == 0 || min > counter)
                            min = counter;

                        /// <summary>
                        /// Обновление максимального количества попыток.
                        /// </summary>
                        if (counter > max)
                            max = counter;

                        /// <summary>
                        /// Добавление количества попыток в общий счётчик.
                        /// </summary>
                        count += counter;

                        /// <summary>
                        /// Увеличение количества сыгранных игр.
                        /// </summary>
                        countGame++;

                        break;
                    }
                }

                /// <summary>
                /// Запрос пользователю о повторении игры.
                /// </summary>
                Console.WriteLine("Do you want play again?");

                /// <summary>
                /// Чтение ответа пользователя.
                /// </summary>
                answer = Convert.ToChar(Console.Read());

            } while (answer == 'y');

            /// <summary>
            /// Вывод статистики после завершения всех игр.
            /// </summary>
            Console.WriteLine($"min = {min} max = {max} avg = {(double)count / countGame}");
        }
    }
}