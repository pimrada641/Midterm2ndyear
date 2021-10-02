using System;
using System.Collections.Generic; //include ไลบารี่เพื่อให้ใช้งาน List<> ได้

namespace _4
{
    class User //Class ผู้ใช้งาน
    {
        public static string name; //ตัวแปรที่เก็บค่าชื่อของผู้ใช้
        public static string password; //ตัวแปรที่เก็บค่ารหัสผ่านของผู้ใช้
        public static int type; //ตัวแปรที่เก็บค่าประเภทของผู้ใช้งาน (นักเรียนหรือพนักงาน)

    }
    class Student : User //Class ของนักเรียนซึ่งสืบทอด Class มาจาก Class User
    {
        public static string studentID; //ตัวแปรเก็บค่ารหัสนักเรียน
        public Student(string valueName, string valuePassword, string valueStudentID) //Constructor ของ Student เก็บค่าชื่อ รหัสผ่าน และรหัสนักเรียน
        {
            name = valueName;
            password = valuePassword;
            studentID = valueStudentID;
        }
        
    }
    class Employee : User //Class ของพนักงานซึ่งสืบทอด Class มาจาก Class User
    {
        public static string employeeID; //ตัวแปรเก็บค่ารหัสพนักงาน

        public Employee(string valueName, string valuePassword, string valueEmployeeID) //Constructor ของ Employee เก็บค่าชื่อ รหัสผ่าน และรหัสพนักงาน
        {
            name = valueName;
            password = valuePassword;
            employeeID = valueEmployeeID;
        }
    }
    class Book //Class ของหนังสือซึ่งจะมีเลขหนังสือและชื่อกำหนดไว้
    {
        public int bookID; //ตัวแปรเก็บค่าเลขหนังสือ
        public string bookName; //ตัวแปรเก็บค่าชื่อหนังสือ

        public Book(int valuebookID , string valuebookName) //Constructor ของหนังสือที่ใช้เก็บค่าเลขและชื่อหนังสือ
        {
            bookID = valuebookID;
            bookName = valuebookName;
        }
    }
    class Program //Class Main ของโปรแกรม
    {
        static void Main(string[] args) //Method Main ของโปรแกรม
        {
            bool loop = true; //ตั้งค่า loop เป็นจริงเพื่อให้โปรแกรมรันวนกลับมาได้
            while (loop) //ลูปเพื่อให้โปรแกรมวนกลับมาทำงานซ้ำ
            {
                 mainmenu(); //เข้าสู่ Method หน้าเมนูของโปรแกรม
            }
        }
        static void mainmenu() //Method หน้าเมนูของโปรแกรม
        {
            Console.Clear(); //กำจัดข้อความทั้งหมดบนหน้าจอ
            Console.WriteLine("Welcome to Digital Library"); //แสดงผลข้อความต้อนรับ
            Console.WriteLine("----------------"); //แสดงผลข้อความ
            Console.WriteLine("1. Login"); //แสดงผลตัวเลือก 1
            Console.WriteLine("2. Register"); //แสดงผลตัวเลือก 2
            Console.Write("Select Menu: "); //แสดงผลเพื่อให้ผู้ใช้ input คำตอบ
            int select = int.Parse(Console.ReadLine()); //กำหนดตัวแปร select เพื่อรับค่าจากผู้ใช้ว่าต้องการเลือกตัวเลือกใดในหน้าเมนู
            selectMenu(select); //นำค่าที่ได้จากผู้ใช้ไปประมวลผลในฟังก์ชั่น selectMenu
        }
        static void selectMenu(int select) //ฟังก์ชั่น selectMenu นำค่าที่ได้มาประมวลผลว่าผู้ใช้ต้องการไปที่หน้าใด
        {
            switch (select) //ทางแยกตัวเลือกต่างๆ 
            {
                case 1: login(); break; //ถ้าค่าที่ผู้ใช้กรอกเป็น 1 ให้ไปที่หน้า Login แล้วจบตัวเลือกนี้
                case 2: register(); break; //ถ้าค่าที่ผู้ใช้กรอกเป็น 2 ให้ไปที่หน้า Register แล้วจบตัวเลือกนี้
            }
        }
        static void register() //หน้า Register เพื่อลงทะเบียนข้อมูล
        {
            Console.Clear(); //กำจัดข้อความทั้งหมดบนหน้าจอ
            Console.WriteLine("Register new Person"); //แสดงผลข้อความต้อนรับ
            Console.WriteLine("----------------"); //แสดงผลข้อความ
            Console.Write("Input name: "); //แสดงผลข้อความให้ผู้ใช้กรอกชื่อ
            User.name = Console.ReadLine(); //รับค่าจากผู้ใช้แล้วนำไปเก็บที่ Class User ในตัวแปร name

            Console.Write("Input Password: "); //แสดงผลข้อความให้ผู้ใช้กรอกรหัสผ่าน
            User.password = Console.ReadLine(); //รับค่าจากผู้ใช้แล้วนำไปเก็บที่ Class User ในตัวแปร password

            Console.Write("Input User Type 1 = Student, 2 = Employee: "); //แสดงผลข้อความให้ผู้ใช้กรอกประเภทของผู้ใช้
            User.type = int.Parse(Console.ReadLine()); //รับค่าจากผู้ใช้แล้วนำไปเก็บที่ Class User ในตัวแปร type
            if(User.type == 1) //เงื่อนไข ถ้าผู้ใช้เลือก 1 หรือ เป็นนักเรียน
            {
                Console.Write("Input Student ID: "); //แสดงผลข้อความให้ผู้ใช้กรอกรหัสนักเรียน
                Student.studentID = Console.ReadLine(); //รับค่าจากผู้ใช้แล้วนำไปเก็บที่ Class Student ในตัวแปร studentID
                Student newStudent = new Student(User.name, User.password, Student.studentID); //นำค่าทั้งหมดไปใส่ไว้ใน class ต่างๆ ตามประเภท
            }
            if (User.type == 2) //เงื่อนไข ถ้าผู้ใช้เลือก 1 หรือ เป็นพนักงาน
            {
                Console.Write("Input Employee ID: "); //แสดงผลข้อความให้ผู้ใช้กรอกรหัสหนักงาน
                Employee.employeeID = Console.ReadLine(); //รับค่าจากผู้ใช้แล้วนำไปเก็บที่ Class Emplyoee ในตัวแปร employeeID
                Employee employee = new Employee(User.name, User.password, Employee.employeeID); //นำค่าทั้งหมดไปใส่ไว้ใน class ต่างๆ ตามประเภท
            }

        }
        static void login() //หน้า login สำหรับลงชื่อเข้าใช้งาน
        {
            Console.Clear(); //กำจัดข้อความทั้งหมดบนหน้าจอ
            Console.WriteLine("Login Screen"); //แสดงผลข้อความต้อนรับ
            Console.WriteLine("----------------"); //แสดงผลข้อความ
            Console.Write("Input name: "); //แสดงผลข้อความเพื่อให้ผู้ใช้กรอกชื่อ
            string inputname = Console.ReadLine(); //กำหนดตัวแปร inputname เพื่อรับค่าที่ผู้ใช้กรอก
            Console.Write("Input password: "); //แสดงผลข้อความเพื่อให้ผู้ใช้กรอกรหัส
            string inputpassword = Console.ReadLine(); //กำหนดตัวแปร inputpassword เพื่อรับค่าที่ผู้ใช้กรอก
            checkUser(inputname,inputpassword); //นำเข้าฟังก์ชั่น checkUser

            void checkUser(string valueInputname,string valueInputpassword) //ฟังกฺชั่น checkUser นำค่าที่รับมาจากผู้ใช้มาเปรียบเทียบว่ามีชื่อและรหัสนี้ในระบบหืรอไม่
            {
                if(valueInputname == User.name && valueInputpassword == User.password) //เงื่อนไข ถ้าชื่อและรหัสตรงกับค่าในระบบ
                {
                    if(User.type == 1) //เงื่อนไข ถ้าเป็นนักเรียน
                    {
                        studentInterface(); //เข้าหน้าต่างของนักเรียน
                    }
                    else if (User.type == 2) //เงื่อนไข ถ้าเป็นหนักงาน
                    {
                        employeeInterface(); //เข้าหน้าต่างของพนักงาน
                    }
                }
                else //เงื่อนไข อื่นๆ
                {
                    Console.WriteLine("Incorrect"); //แสดงผล ไม่่ถูกต้อง
                    Console.ReadLine(); //ให้ผู้ใช้กดเพื่อดำเนินการต่อ
                }
                
            }
        }
        static void employeeInterface() //หน้าต่างของพนักงาน
        {
            Console.Clear(); //เคลียร์หน้าจอ
            Console.WriteLine("Employee Managment"); //แสดงผลข้อความ
            Console.WriteLine("----------------"); //แสดงผลข้อความ
            Console.WriteLine("Name : {0}",User.name); //แสดงผลชื่อผู้ใช้
            Console.WriteLine("Employee ID : {0}", Employee.employeeID); //แสดงผลรหัสพนักงานของผู้ใช้
            Console.WriteLine("----------------"); //แสดงผลข้อความ
            Console.WriteLine("1.Get List Books"); //แสดงผลข้อความว่าสามารถทำอะไรได้บบ้าง
            Console.Write("Input Menu: "); //แสดงผลข้อความรับค่าจากผู้ใช้
            int watchlist = int.Parse(Console.ReadLine()); //ตัวแปร watchlist รับค่าจากผู้ใช้
            if(watchlist == 1) //เงื่อนไขเมื่อเลือก 1 หรือ เลือกดูหนังสือ
            {
                bookList(); //เข้าหน้าต่างรายชื่อหนังสือ
            }
        }
        static void studentInterface() //หน้าต่างของนักเรียน
        {
            Console.Clear(); //เคลียร์หน้าจอ
            Console.WriteLine("Student Managment"); //แสดงผลข้อความ
            Console.WriteLine("----------------"); //แสดงผลข้อความ
            Console.WriteLine("Name : {0}", User.name);  //แสดงผลชื่อผู้ใช้
            Console.WriteLine("Student ID : {0}", Student.studentID); //แสดงผลรหัสนักเรียน
            Console.WriteLine("----------------"); //แสดงผลข้อความ
            Console.WriteLine("1.Borrow Book"); //แสดงผลข้อความว่าสามารถทำอะไรได้บบ้าง
            Console.Write("Input Menu: "); //แสดงผลข้อความรับค่าจากผู้ใช้
            int watchlist = int.Parse(Console.ReadLine()); //ตัวแปร watchlist รับค่าจากผู้ใช้
            if (watchlist == 1) //เงื่อนไขเมื่อเลือก 1 หรือ เลือกยืมหนังสือ
            {
                bookList(); //เข้าหน้าต่างรายชื่อหนังสือ
            }
        }
        static void bookList() //หน้าต่างรายชื่อหนังสือ
        {
            Console.Clear(); //เคลียร์หน้าจอ
            Console.WriteLine("Book List"); //แสดงผลข้อความ
            Console.WriteLine("----------------"); //แสดงผลข้อความ

            List<Book> userlist = new List<Book>(); //สร้างลิสต์หนังสือของผู้ใช้

            List<Book> booklist = new List<Book>(); //สร้างลิสต์หนังสือทั้งหมด

            Book nowiunderstand = new Book(1, "Now I UNDERSTAND"); //กำหนดหนังสือเล่มแรก และหมายเลขหนังสือ
            Book revolutionarywealth = new Book(2, "REVOLUTIONARY WEALTH"); //กำหนดหนังสือเล่ม2 และหมายเลขหนังสือ
            Book sixdegrees = new Book(3, "Six Degrees"); //กำหนดหนังสือเล่ม3 และหมายเลขหนังสือ
            Book lesvacances = new Book(4, "Les Vacances"); //กำหนดหนังสือเล่ม4 และหมายเลขหนังสือ
 
            booklist.Add(nowiunderstand); //เพิ่มหนังสือลงในลิสต์หนังสือทั้งหมด
            booklist.Add(revolutionarywealth); //เพิ่มหนังสือลงในลิสต์หนังสือทั้งหมด
            booklist.Add(sixdegrees); //เพิ่มหนังสือลงในลิสต์หนังสือทั้งหมด
            booklist.Add(lesvacances); //เพิ่มหนังสือลงในลิสต์หนังสือทั้งหมด

            foreach (Book item in booklist) //แสดงผลหนังสือทั้งหมดในลิสต์หนังสือทั้งหมดโดยการลูปทีละเล่ม
            {
                Console.WriteLine("Book ID: " + item.bookID); //แสดงผลรหัสหนังสือ 
                Console.WriteLine("Book name: " + item.bookName);  //แสดงผลชื่อหนังสือ
            }
            if(User.type == 1) //เงื่อนไข ถ้าผู้ใช้เป็นนักเรียน
            {
                string inputid = "y"; //คำหนดค่า default ของคำตอบของผู้ใช้เป็น y
                while (inputid != "exit") //ลูปเมื่อคำตอบของผู้ใช้ไม่ใช่ exit
                {
                Console.Write("Input book ID: ");  //แสดงผลข้อความ
                inputid = Console.ReadLine(); //รับค่าคำตอบจากผู้ใช้ว่าต้องการยืมหนังสือเล่มใด
               
                    if(inputid == "1") //เงื่อนไขเมื่อผู้ใช้เลือกเล่มที่ 1
                    {
                        userlist.Add(nowiunderstand); //เพิ่มหนังสือเล่มที่ 1 ลงในลิสต์ของผู้ใช้
                        Console.WriteLine("Book name: Now I UNDERSTAND"); //แสดงผลหนังสือเล่ม 1
                        Console.WriteLine(""); //ขึ้นบรรทัดใหม่
                    }
                    if (inputid == "2") //เงื่อนไขเมื่อผู้ใช้เลือกเล่มที่ 2
                    {
                        userlist.Add(revolutionarywealth); //เพิ่มหนังสือเล่มที่ 2 ลงในลิสต์ของผู้ใช้
                        Console.WriteLine("REVOLUTIONARY WEALTH"); //แสดงผลหนังสือเล่ม 2
                        Console.WriteLine(""); //ขึ้นบรรทัดใหม่
                    }
                    if (inputid == "3") //เงื่อนไขเมื่อผู้ใช้เลือกเล่มที่ 3
                    {
                        userlist.Add(sixdegrees); //เพิ่มหนังสือเล่มที่ 3 ลงในลิสต์ของผู้ใช้
                        Console.WriteLine("Six Degrees"); //แสดงผลหนังสือเล่ม 3
                        Console.WriteLine(""); //ขึ้นบรรทัดใหม่
                    }
                    if (inputid == "4") //เงื่อนไขเมื่อผู้ใช้เลือกเล่มที่ 4
                    {
                        userlist.Add(lesvacances); //เพิ่มหนังสือเล่มที่ 4 ลงในลิสต์ของผู้ใช้
                        Console.WriteLine("Les Vacances"); //แสดงผลหนังสือเล่ม 4
                        Console.WriteLine(""); //ขึ้นบรรทัดใหม่
                    }
                }
                Console.Clear(); //เคลียร์หน้าจอ
                Console.WriteLine("Name : {0}", User.name);//เมื่อผู้ใช้กรอก exit เพื่อทำลายลูป While จะแสดงผลชื่อนักเรียน
                Console.WriteLine("Student ID : {0}", Student.studentID); //แสดงผลรหัสนักเรียน
                Console.WriteLine("Book List"); //แสดงผลข้อความ
                Console.WriteLine("----------------"); //แสดงผลข้อความ
                foreach (Book item in userlist) //แสดงผลหนังสือทั้งหมดในลิสต์ของผู้ใช้แบบลูปทีละเล่ม
                {
                    Console.WriteLine("Book ID: " + item.bookID); //แสดงผลรหัสหนังสือที่ยืม
                    Console.WriteLine("Book name: " + item.bookName); //แสดงผลชื่อหนังสือที่ยืม
                }

            }
            Console.ReadLine(); //รับค่าจากผู้ใช้ก่อนกลับหน้าหลักอีกครั้ง
        }
    }
}
