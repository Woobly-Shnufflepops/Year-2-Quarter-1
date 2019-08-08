using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace NestedTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            //Nested or inner tasks are tasks that are created
            //and started within a task (outer task)
            Task outerTask = Task.Factory.StartNew(() =>
            {
                //Display a message to indicate that the outer
                //task has started
                Console.WriteLine("Outer Task started...");

                //Start other inner or nested tasks
                Task nestedTask1 = Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("nested task 1 started...");
                    //have this task spin around
                    Thread.SpinWait(500000000);
                    Console.WriteLine("Nested task 1 completing...");
                });

                Task nestedTask2 = Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("nested task 2 started...");
                    //have this task spin around
                    Thread.SpinWait(500000000);
                    Console.WriteLine("Nested task 2 completing...");
                });

                Task nestedTask3 = Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("nested task 3 started...");
                    //have this task spin around
                    Thread.SpinWait(500000000);
                    Console.WriteLine("Nested task 3 completing...");
                });

                //Outer task does not actually wait for its innerTasks
                //to complete before it completes itself.
                //The outer task may be done before its innerTasks are
                //done
                //There are different ways to make the outer tasks wait
                //for its inner tasks
                //Option 1: Use the Wait method

                //If it's waiting for just one inner task
                nestedTask1.Wait();
                //or
                //nestedTask2.Wait(); //Waiting for nestedTask2 to complete

                //If you want the outertask to wait for 2 or more nested
                //tasks, then lump them together into a single WaitAll 
                //statement
                Task.WaitAll(nestedTask1, nestedTask2, nestedTask3);
                Console.WriteLine("Outer Task completing...");
                
            });
            Console.ReadLine();
        }
    }
}
//Another option to cause the outer task to wait for the nested tasks is
//when the nested tasks have to return a value, and the outer task job
//is to read the returned value in the statement nestedTask1.Result

//If the outerTask has the statement nestedTask1.Result, it causes the
//outerTask to wait until the nestedTasks returns the value(s)
//(So it is a block statement)

//Assignment:
//Have an outerTask start three nestedTasks, where each does some work
//(for loop) and returns some value.
//The outerTask is to compute the average of all three returned values and
//display it (do that in a windows application)
