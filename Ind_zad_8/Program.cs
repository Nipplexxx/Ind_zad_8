using System;
using System.Collections.Generic;

namespace Course
{
    class Student
    {
        // Поля класса
        public string Имя { get; set; }
        public string Фамилия { get; set; }
        public string Группа { get; set; }
        public double СреднийБалл { get; set; }

        // Конструктор
        public Student(string имя, string фамилия, string группа, double среднийБалл)
        {
            Имя = имя;
            Фамилия = фамилия;
            Группа = группа;
            СреднийБалл = среднийБалл;
        }

        public void ОтобразитьИнформация()
        {
            Console.WriteLine("Информация о студенте:");
            Console.WriteLine($"Имя: {Имя}");
            Console.WriteLine($"Фамилия: {Фамилия}");
            Console.WriteLine($"Группа: {Группа}");
            Console.WriteLine($"Средний балл: {СреднийБалл:F2}");
            Console.WriteLine($"Стипендия: {ПолучитьСтипендию()} рублей");
        }

        // Стипуха
        public int ПолучитьСтипендию()
        {
            return СреднийБалл > 4.5 ? 1000 : 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Список студентов
            List<Student> студенты = new List<Student>
            {
                new Student("Павел", "Елецков", "Pz.Kpfw.VI", 4.6),
                new Student("Анна", "Смирнова", "ИС-02", 4.2),
                new Student("Иван", "Иванов", "ИС-01", 4.8),
                new Student("Мария", "Петрова", "БИ-04", 4.0),
                new Student("Сергей", "Кузнецов", "ФТ-03", 3.9)
            };

            // Цикл
            while (true)
            {
                Console.WriteLine("Выберите студента для получения информации:");
                for (int i = 0; i < студенты.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {студенты[i].Имя} {студенты[i].Фамилия}");
                }
                Console.WriteLine("0. Выйти из программы");

                if (!int.TryParse(Console.ReadLine(), out int выборСтудента) || выборСтудента < 0 || выборСтудента > студенты.Count)
                {
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    continue;
                }

                if (выборСтудента == 0)
                {
                    break;
                }

                Student выбранныйСтудент = студенты[выборСтудента - 1];

                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Отобразить информацию о студенте");
                Console.WriteLine("2. Посчитать стипендию");

                string выбор = Console.ReadLine();

                if (выбор == "1")
                {
                    выбранныйСтудент.ОтобразитьИнформация();
                }
                else if (выбор == "2")
                {
                    Console.WriteLine($"Стипендия: {выбранныйСтудент.ПолучитьСтипендию()} рублей");
                }
                else
                {
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                }

                Console.WriteLine();
            }
        }
    }
}
