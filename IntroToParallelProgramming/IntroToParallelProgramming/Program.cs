using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace IntroToParallelProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            //synchronous call
            //DisplayEvenValues();
            //DisplayOddValues();

            //Asynchronous call
            Action action1 = DisplayEvenValues;
            Task t1 = new Task(action1);

            Action action2 = DisplayOddValues;
            Task t2 = new Task(action2);

            //using lambda expressions
            Task t3 = new Task(()=>
            {
                Random rand1 = new Random();
                for (int i = 1; i <= 100; i++)
                {
                    int x = rand1.Next(70000, 100000);
                    if (x % 3 == 0)
                    {
                        Console.WriteLine("Main id: {0} x: {1}", Task.CurrentId, x);
                    }
                    Thread.Sleep(30);
                }
            });

            Task t4 = new Task(() =>
            {
                StreamReader sr = new StreamReader(@"Program.cs");
                string content = sr.ReadToEnd();
                Console.WriteLine(content);
                sr.Close();
            });

            t4.Start();
            Console.ReadLine();
            t3.Start();

            //start the task
            t1.Start();
            t2.Start();

            Random rand = new Random();
            for (int i = 1; i <= 100; i++)
            {
                int x = rand.Next(10000, 20000);
                if (x % 5 == 0)
                {
                    Console.WriteLine("Main id: {0} x: {1}", Task.CurrentId, x);
                }
                Thread.Sleep(30);
            }

            Console.ReadLine(); // puase
        }
        static void DisplayEvenValues()
        {
            Random rand = new Random();
            for(int i = 1; i <= 100; i++)
            {
                int x = rand.Next(10000, 20000);
                if(x % 2 == 0)
                {
                    Console.WriteLine("Task id: {0} x: {1}", Task.CurrentId, x);
                }
                Thread.Sleep(30);
            }
        }
        static void DisplayOddValues()
        {
            Random rand = new Random();
            for (int i = 1; i <= 100; i++)
            {
                int x = rand.Next(30000, 40000);
                if (x % 2 == 1)
                {
                    Console.WriteLine("Task id: {0} x: {1}", Task.CurrentId, x);
                }
                Thread.Sleep(30);
            }
        }
    }
}
//Exercise:
//use a task to read and display the content of a text file
//you can use c# source file (.cs) as the text file
