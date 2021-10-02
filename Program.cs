using System;
using System.Collections.Generic;

namespace _3Improve
{
    class Input
    {
        public static string select;
        public static string decide = "y";
    }
    class Program
    {
        static void Main(string[] args)
        {
            selectFlower();
        }
        static void selectFlower()
        {
            do
            {
                Console.WriteLine("Select number for buy flower");
                showFlowerList();
                Input.select = (Console.ReadLine());
                addinlist();
                Console.WriteLine("You can stop this progress? exit for >> exit >> progress and press any key for continue");
                Input.decide = (Console.ReadLine());
                if (Input.decide == "exit")
                {
                    Console.Write("Current my cart");
                    FlowerStore.showCart();
                }
            } while (Input.decide != "exit");
            
        }
        static void addinlist()
        {
            if (Input.select == "1" || Input.select == "2")
            {
                FlowerStore flowerStore = new FlowerStore();
                int newInput = Int16.Parse(Input.select);
                FlowerStore.addToCart(flowerStore.flowerList[newInput-1]);
                Console.WriteLine("Added " + flowerStore.flowerList[newInput-1]);
            }
            else
            {
                Console.WriteLine("Not Added to cart. found select number of flower");
            }
        }
        static void showFlowerList()
        {
            FlowerStore flowerStore = new FlowerStore();
            foreach (string i in flowerStore.flowerList)
            {
                Console.Write((flowerStore.flowerList.IndexOf(i)+1) + "");
                Console.WriteLine();
            }
        }
    }
    class FlowerStore
    {
        public List<string> flowerList = new List<string>();
        static List<string> cart = new List<string>();

        public FlowerStore()
        {
            flowerList.Add("Rose");
            flowerList.Add("Lotus");
        }
        public static void addToCart(string name)
        {
            cart.Add(name);
        }

        public static void showCart()
        {
            if (cart.Count == 0)
            {
                Console.WriteLine("Cart is empty");
            }
            else
            {
                Console.WriteLine("My Cart :");
                foreach (string i in cart)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
