using System;
using System.Collections.Generic;  //เพิ่มไลบารี่ที่ทำให้ใช้ List ได้

namespace _1
{
    class Score //class ไว้เก็บค่าของคะแนนที่ทำผิด
    {
        public static int score; //ตัวแปรของคะแนนที่ทำผิด ตั้งเป็น static เพื่อให้นำไปใช้ใน class อื่นๆ ได้
    }
    class Words //class ของคำศัพท์ และจำนวนตัวอักษรในแต่ละคำ
    {
        public static string word;  //ตัวแปรคำศัพท์ ตั้งเป็น static เพื่อให้นำไปใช้ใน class อื่นๆ ได้
        public static int wordlength; //จำนวนตัวอักษรของคำศัพท์นั้นๆ  ตั้งเป็น static เพื่อให้นำไปใช้ใน class อื่นๆ ได้
    }
    class Input //class ของ input จากผู้ใช้
    {
        public char input; //ตัวแปร input จากผู้ใช้ต่างๆ ได้แก่ ตัวเลือกที่หน้าเมนู และคำตอบของผู้ใช้
        public Input(char valueInput)  //Constructor ของ Input เอาแยก input หน้าเมนูกับ input คำตอบของผู้ใช้ใน class main 
        {
            input = valueInput;   //เชื่อมตัวแปรใน class main กับตัวแปรใน class นี้
        }
    }
    class Program  //class main หลักของโปรแกรมนี้ยังไงล่าาา
    {
        static void Main(string[] args) //method main ของโปรแกรม
        {
            Mainmenu(); // ส่งไม้ต่อไปต่อไปที่ Method เมนูหลักของเกมที่แยกไว้ทำไมไม่รู้
        }

        static void Mainmenu()   //Method เมนูหลักของเกม
        {
            Console.WriteLine("Welcome to HangmanGame"); //แสดงผลข้อความต้อนรับ
            Console.WriteLine("----------------------"); //แสดงผลขีดขีดขีด
            Console.WriteLine("1. Play Game");   //แสดงผลตัวเลือก1
            Console.WriteLine("2. Exit");        //แสดงผลตัวเลือก2
            Console.Write("Please Select Menu : ");  //แสดงผลข้อความที่บอกให้ผู้ใช้ input ตัวเลือกที่ต้องการ

            inputmainmenu();    //ไปทำงานต่อใน Method input คำตอบจาก User
        }

        static void inputmainmenu() //Method ที่ใช้รับคำตอบที่หน้าเมนูจากผู้ใช้
        {
            Input ans = new Input(char.Parse(Console.ReadLine()));  //สร้าง object ใหม่สำหรับรับคำตอบของผู้ใช้แล้วนำค่าไปเก็บใน class Input 
            if (ans.input == '1') //เงื่อนไข ถ้าคำตอบของผู้ใช้คือ '1'
            {
                Console.Clear();    //ล้างข้อความบนหน้าจอ
                Random();       //ทำงานต่อใน Method Random เพื่อสุ่มคำศัพท์ขึ้นมา 1 คำ
            }
            else if(ans.input == '2'){ }   //เงื่อนไขอื่น ถ้าคำตอบคือ '2' ให้จบการทำงาน
        }

        static void Random() //Method ที่ใช้สุ่มคำศัพท์ขึ้นมา 1 ใน 3 คำ จาก class Words
        {
            Random random = new Random();  //สร้าง object random

            int resultRandom = random.Next(0, 3);  //กำหนดตัวแปรแทนลำดับของคำศัพท์ที่สุ่มมาได้จาก 0-2
            var words = new List<string>   
                    {"tennis","football","badminton" };   //สร้างลิสต์ของคำศัพท์ทั้ง 3 คำ

            Words.word = words[resultRandom];    //นำคำศัพท์ในลำดับที่มีค่าเท่ากับ resultRandom ไปเก็บในตัวแปร word ของ class Words
            Words.wordlength = words[resultRandom].Length;  //นำจำนวนตัวอักษรของคำศัพท์ที่ถูกสุ่มได้ไปเก็บในตัวแปร wordlength ของ class Words
            HangMan();   //ทำงานต่อใน Method HangmMan
        }

        static void HangMan()   //Method ของเกมสำหรับเล่นเกม Hangman
        {
            char[] arrayblank = new char[Words.wordlength];   //สร้าง arrayblank แทน array คำตอบที่ผู้ใช้หามาเติมในช่องว่าง โดยมีขนาดเท่ากับจำนวนตัวอักษรของคำศัพท์

            for (int i = 0; i < Words.wordlength; i++) //ลูบที่สร้างเพื่อให้ arrayblank เป็นนช่องว่างก่อนในครั้งแรกที่เล่นเกม ตามจำนวนตัวอักษรของคำศัพท์ที่สุ่มได้
            {
                arrayblank[i] = '_';
            }  

            while(Score.score < 6)  //ลูปที่สร้างเพื่อลูปเกมจนกว่าผู้ใช้จะเล่นชนะหรือแพ้
            {
                Console.WriteLine("Play Game Hangman");  //แสดงผลข้อความเพื่อให้บอกผู้ใช้รู้ว่าเข้าสู่เกมแล้วนะจ้ะ
                Console.WriteLine("------------------");  //แสดงผลข้อความขีด
                Console.WriteLine("Incorrect Score: {0}", Score.score); //แสดงผลคะแนนของผู้ใช้ โดยดึงตัวเลขมาจากตัวแปร score ใน Class Score
                char[] array = Words.word.ToCharArray(); //เปลี่ยน string คำศัพท์ที่สุ่มได้เป็น array

                for (int k = 0; k < Words.wordlength; k++) //ลูปแสดงผลช่องว่างตัวจำนวนตัวอักษรของคำศัพท์
                {
                    Console.Write(arrayblank[k] + " ");
                }
                Console.WriteLine();  //ขึ้นบรรทัดใหม่

                String.lastanswer = new string(arrayblank);   //เปลี่ยน arrayblank เป็น string แล้วนำไปเก็บไว้ใน Class String 

                Console.WriteLine("Input letter alphabet: "); //แสดงผลข้อความว่าให้ input คำตอบ
                if (String.ansnow == Words.word)   //เงื่อนไขเช็คว่าชนะเกมหรือยัง โดยจะเช็ค string คำตอบในปัจจุบันกับ string คำตอบที่ถูกต้อง ถ้าตรงกัน win จะเป็น true และขึ้นข้อความว่า คุณชนะ
                {
                    Console.WriteLine("You win!!!");
                    break; //จบบการทำงานของลูป
                }
                Input inputans2 = new Input(char.Parse(Console.ReadLine())); //สร้าง object ใหม่สำหรับรับคำตอบของผู้ใช้แล้วนำค่าไปเก็บใน class Input 

                for (int j = 0; j < Words.wordlength; j++) //ลูปเช็คคำตอบของผู้ใช้กับตัวอักษรใน array คำตอบว่าตรงกันหรือไม่โดยเช็คทีละตัวตามจำนวนตัวอักษร
                {
                    if (inputans2.input == array[j]) //เงื่อนไขเช็คคำตอบว่าตัวอักษรที่ผู้ใช้ input ตรงกับคำตอบที่ถูกใน array array หรือไม่โดยไล่ทีละตัวใน array ของคำตอบ
                    {
                        arrayblank[j] = inputans2.input;  //ถ้ามีถูก ให้เปลี่ยนตัวอักษรใน arrayblank หรืออาร์เรย์ช่องว่างที่เป็นคำตอบที่ผู้ใช้หามาได้ให้เป็นตัวอักษรนั้น
                    }
                }
                String.ansnow = new string(arrayblank); //นำคำตอบที่เพิ่งตอบไปเก็บเป็นค่า string ansnow ใน class String
                if (String.lastanswer == String.ansnow) //เปรียบเทียบคำตอบที่เพิ่งตอบไป กับคำตอบก่อนหน้าว่ามีอะไรเปลี่ยนไปหรือไม่ ถ้ามีตัวอักษรที่ถูก คำตอบก็จะเปลี่ยนไปจากก่อนหน้า แต่ถ้าไม่มี คำตอบก็จะเหมือนเดิม หลังจากนั้นก็จะบวกคะแนนตอบผิดเก็บไว้ใน class Score
                {
                    Score.score += 1;
                }
                
                Console.Clear(); //เคลียร์ตัวอักษรทั้งหมดบนหน้าจอ
            }
            if (Score.score == 6) { Console.WriteLine("Game Over"); }  //ถ้าคะแนนผิดถึง 6 เมื่อไร่ จะแสดงผล Game over ทันที
            
        }
    }
    class String   //Class String ไว้เก็บค่าเมื่อเปลี่ยน Array เป็น String
    {
        public static string ansnow; //ตัวแปรแทนคำตอบล่าสุด
        public static string lastanswer;  //ตัวแปรแทนคำตอบก่อนหน้าที่จะเป็นคำตอบล่าสุด
    }

}
