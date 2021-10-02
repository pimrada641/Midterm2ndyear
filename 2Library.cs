using System;
using System.Collections.Generic;

namespace _4
{
    class User
    {
        public static string name;
        public static string password;
        public static int type;

    }
    class Student : User
    {
        public static string studentID;
        public Student(string valueName, string valuePassword, string valueStudentID)
        {
            name = valueName;
            password = valuePassword;
            studentID = valueStudentID;
        }
        
    }
    class Employee : User
    {
        public static string employeeID;

        public Employee(string valueName, string valuePassword, string valueEmployeeID)
        {
            name = valueName;
            password = valuePassword;
            employeeID = valueEmployeeID;
        }
    }
    class Book
    {
        public int bookID;
        public string bookName;

        public Book(int valuebookID , string valuebookName)
        {
            bookID = valuebookID;
            bookName = valuebookName;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            bool loop = true;
            while (loop)
            {
                 mainmenu();
            }
        }
        static void mainmenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Digital Library");
            Console.WriteLine("----------------");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Register");
            Console.Write("Select Menu: ");
            int select = int.Parse(Console.ReadLine());
            selectMenu(select);
        }
        static void selectMenu(int select)
        {
            switch (select)
            {
                case 1: login(); break;
                case 2: register(); break;
            }
        }
        static void register()
        {
            Console.Clear();
            Console.WriteLine("Register new Person");
            Console.WriteLine("----------------");
            Console.Write("Input name: ");
            User.name = Console.ReadLine();

            Console.Write("Input Password: ");
            User.password = Console.ReadLine();

            Console.Write("Input User Type 1 = Student, 2 = Employee: ");
            User.type = int.Parse(Console.ReadLine());
            if(User.type == 1)
            {
                Console.Write("Input Student ID: ");
                Student.studentID = Console.ReadLine();
                Student newStudent = new Student(User.name, User.password, Student.studentID);
            }
            if (User.type == 2)
            {
                Console.Write("Input Employee ID: ");
                Employee.employeeID = Console.ReadLine();
                Employee employee = new Employee(User.name, User.password, Employee.employeeID);
            }

        }
        static void login()
        {
            Console.Clear();
            Console.WriteLine("Login Screen");
            Console.WriteLine("----------------");
            Console.Write("Input name: ");
            string inputname = Console.ReadLine();
            Console.Write("Input password: ");
            string inputpassword = Console.ReadLine();
            checkUser(inputname,inputpassword);

            void checkUser(string valueInputname,string valueInputpassword)
            {
                if(valueInputname == User.name && valueInputpassword == User.password)
                {
                    if(User.type == 1)
                    {
                        Console.Clear();
                        studentInterface();
                    }
                    else if (User.type == 2)
                    {
                        Console.Clear();
                        employeeInterface();
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect");
                    Console.ReadLine();
                }
                
            }
        }
        static void employeeInterface()
        {
            Console.Clear();
            Console.WriteLine("Employee Managment");
            Console.WriteLine("----------------");
            Console.WriteLine("Name : {0}",User.name);
            Console.WriteLine("Employee ID : {0}", Employee.employeeID);
            Console.WriteLine("----------------");
            Console.WriteLine("1.Get List Books");
            Console.Write("Input Menu: ");
            int watchlist = int.Parse(Console.ReadLine());
            if(watchlist == 1)
            {
                bookList();
            }
        }
        static void studentInterface()
        {
            Console.Clear();
            Console.WriteLine("Student Managment");
            Console.WriteLine("----------------");
            Console.WriteLine("Name : {0}", User.name);
            Console.WriteLine("Student ID : {0}", Student.studentID);
            Console.WriteLine("----------------");
            Console.WriteLine("1.Borrow Book");
            Console.Write("Input Menu: ");
            int watchlist = int.Parse(Console.ReadLine());
            if (watchlist == 1)
            {
                bookList();
            }
        }
        static void bookList()
        {
            Console.Clear();
            Console.WriteLine("Book List");
            Console.WriteLine("----------------");

            List<Book> userlist = new List<Book>();

            List<Book> booklist = new List<Book>();

            Book nowiunderstand = new Book(1, "Now I UNDERSTAND");
            Book revolutionarywealth = new Book(2, "REVOLUTIONARY WEALTH");
            Book sixdegrees = new Book(3, "Six Degrees");
            Book lesvacances = new Book(4, "Les Vacances");

            booklist.Add(nowiunderstand);
            booklist.Add(revolutionarywealth);
            booklist.Add(sixdegrees);
            booklist.Add(lesvacances);

            foreach (Book item in booklist)
            {
                Console.WriteLine("Book ID: " + item.bookID);
                Console.WriteLine("Book name: " + item.bookName);
            }
            if(User.type == 1)
            {
                string inputid = "y";
                while (inputid != "exit")
                {
                Console.Write("Input book ID: ");
                inputid = Console.ReadLine();
               
                    if(inputid == "1")
                    {
                        userlist.Add(nowiunderstand);
                        Console.WriteLine("Book name: Now I UNDERSTAND");
                        Console.WriteLine("");
                    }
                    if (inputid == "2")
                    {
                        userlist.Add(revolutionarywealth);
                        Console.WriteLine("REVOLUTIONARY WEALTH");
                        Console.WriteLine("");
                    }
                    if (inputid == "3")
                    {
                        userlist.Add(sixdegrees);
                        Console.WriteLine("Six Degrees");
                        Console.WriteLine("");
                    }
                    if (inputid == "4")
                    {
                        userlist.Add(lesvacances);
                        Console.WriteLine("Les Vacances");
                        Console.WriteLine("");
                    }
                }
                Console.Clear();
                Console.WriteLine("Name : {0}", User.name);
                Console.WriteLine("Student ID : {0}", Student.studentID);
                Console.WriteLine("Book List");
                Console.WriteLine("----------------");
                foreach (Book item in userlist)
                {
                    Console.WriteLine("Book ID: " + item.bookID);
                    Console.WriteLine("Book name: " + item.bookName);
                }

            }
            Console.ReadLine();
        }
    }
}
