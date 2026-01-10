using System;
using System.Collections.Generic;

namespace ChrisCollege
{
    public class Person
    {
        public string Name;
        public string Role;

    }
    public class Class
    {
        public string Name;
        public int TotalStudents;
        public Person Teacher;
        public List<Person> Students_list;
        public bool IsOpen;

        public void OpenClass()
        {
            IsOpen = true;
            Console.Write(Name + " class is open");
        }

        public void CloseClass()
        {
            IsOpen = false;
            Console.WriteLine(Name + " class is closed");
        }

    }

    class Operations
    {


        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to chris college");

            Console.WriteLine("______________________________");
            CreateClass("Forex class");

            Person facilitator = new() { Name = "Ayomide chris", Role = "Teacher" };
            Person student_1 = new() { Name = "Ayomide Alfred", Role = "Student" };
            Person student_2 = new() { Name = "John Doe", Role = "Student" };
            Person student_3 = new() { Name = "Ayomide Alfred", Role = "Student" };
            Person[] students = [student_1, student_2, student_3, facilitator];

            for (int i = 0; i < students.Length; i++)
            {
                JoinClass(students[i], "Forex class");
            }
            Class _class = classList.Find(c => c.Name == "Forex class");
            Console.WriteLine(_class.Name + " Now have " + _class.TotalStudents + " Total students");
            Console.ReadKey();
        }


        public static List<Class> classList = [];
        static void CreateClass(string _name)
        {
            Class _class = new() { Name = _name, IsOpen = false, Students_list = [], Teacher = null, TotalStudents = 0, };
            classList.Add(_class);
            Console.WriteLine(_class.Name + " has been added to the class list");
        }
        static void JoinClass(Person person, string class_name)
        {
            Class result = classList.Find(c => c.Name == class_name);
            if (result == null)
            {
                Console.WriteLine("class does not exist");
                return;
            }

            if (!result.IsOpen)
            {
                if (person.Role != "Student")
                {
                    result.Teacher = person;
                    Console.WriteLine("______________________________");
                    Console.WriteLine(person.Name + " Joined the " + result.Name + "room as the facilator");
                }
                else
                {
                    result.Students_list.Add(person);

                    Console.WriteLine(person.Name + " , a student Joined " + result.Name);

                    result.TotalStudents++;
                }
            }
            else
            {
                Console.WriteLine("Permission denied, class has started, you are late!");
            }

        }
    }
}