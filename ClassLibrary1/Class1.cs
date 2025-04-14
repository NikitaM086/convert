using System.Text.Json;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;
using System;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using System.Linq;
using System.Formats.Asn1;

namespace cs
{
    public class Class1
    {
        public static List<Course> courses = new List<Course>
        {
            new Course { Id = 1, Title = "Основы C#", Instructor = "Н. А. Мухин", StudentCount = 25, Rating = 5 },
            new Course { Id = 4, Title = "Печь пирожки", Instructor = "Мария Иванова", StudentCount = 86, Rating = 4.8 },
        };

        public static bool Success = false;
        public static string Message { get; set; }


        //public static void Main()
        //{
        //    while (true)
        //    {
        //        Console.WriteLine("\n===== МЕНЮ =====");
        //        Console.WriteLine("1. Загрузить данные из файла");
        //        Console.WriteLine("2. Сохранить данные в файл");
        //        Console.WriteLine("3. Вывести все курсы");
        //        Console.WriteLine("4. Сортировать по параметру");
        //        Console.WriteLine("5. Поиск по подстроке");
        //        Console.WriteLine("6. Добавить курс");
        //        Console.WriteLine("7. Удалить курс");
        //        Console.WriteLine("8. Изменить курс");
        //        Console.WriteLine("0. Выход");
        //        Console.Write("Выберите действие: ");

        //        switch (Console.ReadLine())
        //        {
        //            case "1":
        //                LoadData();
        //                break;
        //            case "2":
        //                SaveData();
        //                break;
        //            case "3":
        //                DisplayCourses();
        //                break;
        //            case "4":
        //                SortCourses();
        //                break;
        //            case "5":
        //                SearchCourses();
        //                break;
        //            case "6":
        //                AddCourse();
        //                break;
        //            case "7":
        //                DeleteCourse();
        //                break;
        //            case "8":
        //                EditCourse();
        //                break;
        //            case "0":
        //                return;
        //            default:
        //                Console.WriteLine("Неверный выбор.");
        //                break;
        //        }
        //    }
        //}

        public static void LoadData()
        {
            Console.Write("Введите имя файла: ");
            var path = "test.json";
            var result = FileManager.ReadFromFile<List<Course>>(path);
            if (result != null) courses = result;
            Success = true;
        }

        public static void SaveData()
        {
            Console.Write("Введите имя файла: ");
            var path = "test.json";
            FileManager.WriteToFile(courses, path);
            Success = true;
        }

        public static void DisplayCourses()
        {
            if (courses.Count == 0) Console.WriteLine("Нет данных.");
            else courses.ForEach(c => Console.WriteLine(c));
            Success = true;
        }

        public static void SortCourses()
        {
            Console.WriteLine("Поля: Id, Title, Instructor, StudentCount, Rating");
            Console.Write("Введите поле для сортировки: ");
            string field = "title";

            courses = field switch
            {
                "id" => courses.OrderBy(c => c.Id).ToList(),
                "title" => courses.OrderBy(c => c.Title).ToList(),
                "instructor" => courses.OrderBy(c => c.Instructor).ToList(),
                "studentcount" => courses.OrderBy(c => c.StudentCount).ToList(),
                "rating" => courses.OrderBy(c => c.Rating).ToList(),
                _ => courses
            };
            Success = true;
        }

        public static void SearchCourses()
        {
            Console.Write("Введите строку для поиска: ");
            var keyword = "";
            var results = courses.Where(c =>
                c.Title.ToLower().Contains(keyword) ||
                c.Instructor.ToLower().Contains(keyword)).ToList();

            if (results.Count == 0)
                Console.WriteLine("Ничего не найдено.");
            else
                results.ForEach(c => Console.WriteLine(c));
            Success = true;
        }

        public static void AddCourse()
        {
            var course = new Course();
            Console.Write("ID: "); course.Id = 3;
            Console.Write("Название: "); course.Title = "Котёл";
            Console.Write("Преподаватель: "); course.Instructor = "Андрей Андройдов";
            Console.Write("Студенты: "); course.StudentCount = -1;
            Console.Write("Рейтинг: "); course.Rating = 1.0;

            courses.Add(course);
            Success = true;
        }

        public static void DeleteCourse()
        {
            Console.Write("Введите ID курса для удаления: ");
            int id = 2;
            courses.RemoveAll(c => c.Id == id);
            Success = true;
        }

        public static void EditCourse()
        {
            Console.Write("Введите ID курса для изменения: ");
            int id = 1;
            var course = courses.FirstOrDefault(c => c.Id == id);
            if (course == null)
            {
                Console.WriteLine("Курс не найден.");
                return;
            }
            Success = true;

            Console.Write("Новое название (Enter чтобы оставить): ");
            var title = "С";
            if (!string.IsNullOrWhiteSpace(title)) course.Title = title;

            Console.Write("Новый преподаватель: ");
            var instructor = "Аркадий паровозов";
            if (!string.IsNullOrWhiteSpace(instructor)) course.Instructor = instructor;

            Console.Write("Новое число студентов: ");
            if (33 > 0) course.StudentCount = 33;

            Console.Write("Новый рейтинг: ");
            if (3.3 > 0) course.Rating = 3.3;
        }
    }


}

