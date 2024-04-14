using System.Collections;
using System.Diagnostics.Metrics;
using Library_10;
using System.Collections.Generic;
namespace Лаба12_часть2
{
    internal class Program
    {
        static sbyte InputSbyteNumber(string msg = "Введите число")  //функция для проверки введенного числа на тип sbyte
        {
            Console.WriteLine(msg); //вывод сообщения msg
            bool isConvert; //объявление переменной, отвечающей за проверку на корректность
            sbyte number; //переменная, которой будет присвоено корректно введенное число
            do
            {
                isConvert = sbyte.TryParse(Console.ReadLine(), out number); //проверка на принадлежность типу sbyte
                if (!isConvert) Console.WriteLine("Неправильно введено число. Возможно вы ввели слишком длинное число. Попробуйте заново"); //в случае провала, вывод сообщения о некорректном вводе числа
            } while (!isConvert); //повторение цикла до тех пор, пока пользователь не введет корректное число
            return number; //ф-ция принимает значение введенного корректного числа
        }

        static void SearchAndRemove(MyHashTable<Library_10.Instrument> table)
        {
            Library_10.Instrument tool = new Library_10.Instrument();
            Console.WriteLine("Введите элемент, который нужно найти и удалить");
            tool.Init();
            Console.WriteLine($"Выполним поиск элемента {tool} в хеш-таблице:");
            Console.WriteLine(table.Contains(tool));
            if (table.Contains(tool))
            {
                Console.WriteLine("Выполним удаление этого элемента из хеш-таблицы");
                table.RemoveData(tool);
                Console.WriteLine("Выполним поиск элемента еще раз, чтобы убедиться в том, что он удален:");
                Console.WriteLine(table.Contains(tool));
            }
            Console.WriteLine("Операция прошла успешно");
        }

        static void Main(string[] args)
        {
            MyHashTable < Library_10.Instrument > table = new MyHashTable<Library_10.Instrument>();
            sbyte answer1; //объявление переменных, которые отвечают за выбранный пункт меню
            do
            {
                Console.WriteLine("1. Сформировать хеш-таблицу");
                Console.WriteLine("2. Выполниить поиск, удаление и посик удаленного элемента в хеш-таблице");
                Console.WriteLine("3. Вывести хеш-таблицу");
                Console.WriteLine("4. Добавить элемент");
                Console.WriteLine("5. Выход");
                answer1 = InputSbyteNumber();

                switch (answer1)
                {
                    case 1: //формирование хеш-таблицы и вывод на экран
                        {
                            try
                            {
                                sbyte size = InputSbyteNumber("Введите размер списка");
                                table = new MyHashTable<Library_10.Instrument>(size);
                                Console.WriteLine("Таблица сформирована");
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine($"Выполнение провалено: {e.Message}");
                            }
                            break;
                        }
                    case 2: //поиск и удаление
                        {
                            try
                            {
                                SearchAndRemove(table);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine($"Выполнение провалено: {e.Message}");
                                Console.WriteLine("Возможно вы не создали таблицу");
                            }
                            break;
                        }
                    case 3: //вывод списка
                        {
                            try
                            {
                                table.Print();
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine($"Выполнение провалено: {e.Message}");
                            }
                            break;
                        }
                    case 4:
                        {
                            try
                            {
                                Library_10.Instrument tool = new Library_10.Instrument();
                                tool.Init();
                                Console.WriteLine($"Добавим в хеш-таблицу элемент {tool}");
                                table.AddPoint(tool);
                                Console.WriteLine("Операция выпонена");
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine($"Выполнение провалено: {e.Message}");
                                Console.WriteLine("Возможно вы не создали таблицу");
                            }
                            break;
                        }
                    case 5: //выход из меню
                        {
                            Console.WriteLine("Демонстрация завершена");
                            break;
                        }
                    default: //неправильный ввод пункта меню
                        {
                            Console.WriteLine("Неправильно задан пункт меню");
                            break;
                        }
                }
            } while (answer1 != 5); //цикл повторяется пока пользователь не введет число 4
        }
    }
}
