using System;
using System.Text;

namespace Lab4
{
    // Клас особи
    class Person
    {
        public string Name { get; set; } //ім'я
        public int Age { get; set; }   // вік
        public string Role { get; set; }  // роль

        public Person(string N, string R, int A)
        {
            Name = N;
            Age = A;
            Role = R;
        }

        public string GetName() { return Name; }
    }

    // Клас для оцінки студентів
    class StudentAssessment
    {
        double[] assessment = new double[10];

        public double StRating(Random arand)
        {
            double rating = 0;
            for (int i = 0; i < 10; i++)
            {
                assessment[i] = arand.Next(56, 101); // генерація випадкових оцінок від 56 до 100
                rating += assessment[i];
                Console.Write(assessment[i].ToString() + ", ");
            }
            Console.WriteLine();
            return rating / 10; // повертаємо середнє значення
        }
    }

    // Клас студент
    class Student : Person
    {
        public string Faculty { get; set; }
        public string Group { get; set; }
        public int Course { get; set; }

        // Створення екземплярів класу StudentAssessment
        StudentAssessment assessment1 = new StudentAssessment();
        StudentAssessment assessment2 = new StudentAssessment();

        public Student(string N, string R, int A, string F, string G, int C)
            : base(N, R, A)
        {
            Faculty = F;
            Group = G;
            Course = C;
        }

        public void MyRating(Random arand)
        {
            // обчислення рейтингу
            double Rating1 = assessment1.StRating(arand);
            double Rating2 = assessment2.StRating(arand);
            double SemesterRating = (Rating1 + Rating2) / 2;

            Console.WriteLine("Рейтинг студента = " + SemesterRating);
            if (SemesterRating >= 82)
                Console.WriteLine("Привіт відмінникам");
            else if (SemesterRating <= 60)
                Console.WriteLine("Перездача! Треба краще вчитися!");
            else
                Console.WriteLine("Можна вчитися ще краще!");
        }
    }

    // Клас Факультет
    class Faculty
    {
        public string Name { get; set; }
        public Department Department1 { get; set; }
        public Department Department2 { get; set; }

        public Faculty(string name)
        {
            Name = name;
            Department1 = new Department();
            Department2 = new Department();
        }

        public void DisplayDepartments()
        {
            Console.WriteLine($"Факультет: {Name}");
            Department1.DisplayDepartmentInfo();
            Department2.DisplayDepartmentInfo();
        }
    }

    // Клас Кафедра
    class Department
    {
        public string DepartmentName { get; set; }
        public int NumberOfTeachers { get; set; }
        private string[] subjects = new string[5]; // максимум 5 дисциплін

        public void SetDepartmentName(string name)
        {
            DepartmentName = name;
        }

        public void SetNumberOfTeachers(int number)
        {
            NumberOfTeachers = number;
        }

        // Індексатор для дисциплін
        public string this[int index]
        {
            get { return subjects[index]; }
            set { subjects[index] = value; }
        }

        public void DisplayDepartmentInfo()
        {
            Console.WriteLine($"Кафедра: {DepartmentName}, Кількість викладачів: {NumberOfTeachers}");
            Console.WriteLine("Дисципліни:");
            foreach (var subject in subjects)
            {
                if (!string.IsNullOrEmpty(subject))
                {
                    Console.WriteLine(subject);
                }
            }
        }
    }

    // Статичний клас
    static class ArrayUtilities
    {
        public static int CountOccurrences(int[] array, int value)
        {
            int count = 0;
            foreach (var item in array)
            {
                if (item == value) count++;
            }
            return count;
        }

        public static (int max, int min) FindMaxMin(int[] array)
        {
            int max = array[0];
            int min = array[0];
            foreach (var item in array)
            {
                if (item > max) max = item;
                if (item < min) min = item;
            }
            return (max, min);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            // Тестування студентів
            Student newSt = new Student("Іванов", "студент", 20, "КННІ", "K-01", 3);
            Random arand = new Random();
            newSt.MyRating(arand);

            // Тестування факультету та кафедр
            Faculty faculty = new Faculty("Комп'ютерних наук");
            faculty.Department1.SetDepartmentName("Інформаційних технологій");
            faculty.Department1.SetNumberOfTeachers(10);
            faculty.Department1[0] = "Програмування";
            faculty.Department1[1] = "Алгоритми";
            faculty.Department1[2] = "Бази даних";

            faculty.Department2.SetDepartmentName("Високих технологій");
            faculty.Department2.SetNumberOfTeachers(5);
            faculty.Department2[0] = "Машинне навчання";
            faculty.Department2[1] = "Комп'ютерна графіка";

            faculty.DisplayDepartments();

            // Тестування статичного класу
            int[] array1 = { 1, 2, 5, 3, 7, 5, 1, 3, 4 };
            int occurrences = ArrayUtilities.CountOccurrences(array1, 5);
            Console.WriteLine($"Кількість вказаних цифр 5 в масиві: {occurrences}");

            int[] array2 = { 4, 5, 2, 3, 8, 7, 6, 1 };
            var (max, min) = ArrayUtilities.FindMaxMin(array2);
            Console.WriteLine($"Максимальний елемент: {max}, Мінімальний елемент: {min}");

            Console.ReadKey();
        }
    }
}
