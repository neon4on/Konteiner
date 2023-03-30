using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kon
{
    class Program
    {
        /// <summary>
        /// Главное меню
        /// </summary>
        /// <returns></returns>
        static int Menu()
        {
            int select;

            do
            {
                Console.Clear();
                Console.WriteLine("Информация о книгах в библиотеке: \n\n");
                Console.WriteLine("1 - Добавить новую книги \n");
                Console.WriteLine("2 - Показать все книги \n");
                Console.WriteLine("3 - !!!\n");
                Console.WriteLine("4 - Взять книгу \n");
                Console.WriteLine("5 - Выход из программы \n");
                Console.Write("ВЫБОР: ");
                select = Convert.ToInt32(Console.ReadLine());
            } while ((select < 1) || (select > 5));

            return select;
        }

        public class Avia : IEquatable<Avia>
        {
            public string bookName { get; set; } // Название книги
            public string authorName { get; set; } //ФИО:
            public string yearName { get; set; } // Год издания

            public int countBook { get; set; } // Количество экземпляров

            public int UDK_Id { get; set; } // УДК

            public override string ToString()
            {
                return "Номер УДК: " + UDK_Id + ";  Название книги: " + bookName + ";  ФИО Автора: " + authorName + ";  Год издания: " + yearName + ";  Количество экземпляров: " + countBook;
            }
            public override bool Equals(object obj)
            {
                if (obj == null) return false;
                Avia objAsPart = obj as Avia;
                if (objAsPart == null) return false;
                else return Equals(objAsPart);
            }
            public override int GetHashCode()
            {
                return UDK_Id;
            }
            public bool Equals(Avia other)
            {
                if (other == null) return false;
                return (this.UDK_Id.Equals(other.UDK_Id));
            }


            static void Main(string[] args)
            {
                // В односвязанный список необходимо объект в котором будет несколько полей
                List<Avia> parts = new List<Avia>();
                Avia avia;
                parts.Add(new Avia() { bookName = "Русский Дон", UDK_Id = 1, authorName = "Каменских.В.Ю", yearName = "1917" , countBook = 3 });
                string a, c, d;
                int b, e;

                Console.ForegroundColor = ConsoleColor.Green;

                Console.SetWindowSize(200, 50);

                int select;
                do
                {
                    // вызываем главное меню и выполняем выбор пользователя
                    select = Menu();
                    switch (select)
                    {
                        case 1:
                            {

                                Console.Write("УДК: ");
                                b = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Название книги: ");
                                a = Console.ReadLine();
                                Console.Write("ФИО Автора: ");
                                c = Console.ReadLine();
                                Console.Write("Год издания: ");
                                d = Console.ReadLine();

                                for (int i = 0; i < parts.Count; i++)
                                {
                                    //parts[i]
                                    if (parts[i].UDK_Id == b)
                                    {
                                        parts[i].countBook++;
                                        Console.WriteLine("Новый экземпляр был успешно добавлен");
                                    }
                                    else
                                    {
                                        parts.Add(new Avia() { bookName = a, UDK_Id = b, authorName = c, yearName = d, countBook = 1 });
                                        Console.WriteLine("Новая книга была успешно добавлена");
                                    }
                                }

                                //foreach (Avia aPart in parts.ToArray())
                                //{
                                //    if (aPart.UDK_Id == b)
                                //    {
                                //        aPart.countBook++;
                                //        Console.WriteLine("Новый экземпляр был успешно добавлен");
                                //    }
                                //    else
                                //    {
                                //        parts.Add(new Avia() { bookName = a, UDK_Id = b, authorName = c, yearName = d, countBook = 1 });
                                //        Console.WriteLine("Новая книга была успешно добавлена");
                                //    }
                                //    Console.WriteLine(aPart);
                                //}

                                Console.ReadLine();
                                break;
                            }
                        case 2:
                            {
                                int i = 1;
                                Console.WriteLine("\n");

                                foreach (Avia aPart in parts)
                                {
                                    Console.Write($"({i})" + "\t");
                                    Console.WriteLine(aPart);
                                    i++;
                                }

                                Console.ReadLine();
                                break;
                            }
                        case 3:
                            {
                                //Вывод заявок по номеру рейса
                                //Console.WriteLine("Введите УДК книги, которую хотите взять: ");
                                //b = Convert.ToInt32(Console.ReadLine()) - 1;
                                //var firstElement = parts[b];
                                //Console.WriteLine(firstElement);

                                Console.ReadLine();
                                break;
                            }
                        case 4:
                            {
                                //Удаление книги по УДК
                                Console.WriteLine("Введите УДК книги, которую хотите взять: ");
                                b = Convert.ToInt32(Console.ReadLine());

                                foreach (Avia aPart in parts.ToArray())
                                {
                                    if (aPart.UDK_Id == b)
                                    {
                                        if (aPart.countBook == 1)
                                        {
                                            parts.Remove(new Avia() { UDK_Id = b });
                                            Console.WriteLine("\n");
                                        }
                                        else
                                        {
                                            aPart.countBook -= 1;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Требуемой книги в библиотеке нет, либо требуемая книга находится на руках");
                                    }
                                }
                                
                                Console.ReadLine();
                                break;
                            }
                    }
                } while (select != 5);
            }
        }
    }
}
