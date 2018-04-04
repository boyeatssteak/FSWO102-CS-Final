using System;
using System.Collections.Generic;

namespace ToDo
{
    class Program
    {
        static void Main(string[] args)
        {
            var tasks = new List<string>();
            var status = new List<bool>();

            void menu() {
                Console.WriteLine("## MENU ##");
                Console.WriteLine(" ");
                Console.WriteLine("1. Add a task");
                Console.WriteLine("2. Remove a task");
                Console.WriteLine("3. Mark a task complete");
                Console.WriteLine("4. List the tasks");
                Console.WriteLine("----------------------------");
                Console.WriteLine("What would you like to do?");
                Console.Write("> ");
                string selection = Console.ReadLine();
                Console.WriteLine("You chose " + selection);
                Console.WriteLine("============================");
                if (selection == "1") {
                    addTask();
                } else if (selection == "2") {
                    removeTask();
                } else if (selection == "3") {
                    completeTask();
                } else if (selection == "4") {
                    listTasks();
                } else {
                    Console.WriteLine("Invalid selection, please try again");
                    menu();
                }
            }

            void addTask() {
                Console.Clear();
                Console.WriteLine("============================");
                Console.WriteLine("Please enter the name of the task to add:");
                Console.Write("> ");
                string taskName = Console.ReadLine();
                tasks.Add(taskName);
                status.Add(false);
                Console.Clear();
                Console.WriteLine("Task added!");
                Console.WriteLine("============================");
                menu();
            }
            
            void removeTask() {
                Console.Clear();
                Console.WriteLine("============================");
                for (int i = 0; i < tasks.Count; i++) {
                    Console.Write((i+1) + ". " + tasks[i]);
                    if(status[i] == true) {
                        Console.WriteLine(" (COMPLETED)");
                    } else {
                        Console.WriteLine(" ");
                    }
                }
                Console.WriteLine("----------------------------");
                Console.WriteLine("What task would you like to remove?");
                Console.Write("> ");
                string toRemove = Console.ReadLine();
                if(Int32.Parse(toRemove) <= tasks.Count) {
                    tasks.RemoveAt(Int32.Parse(toRemove)-1);
                    status.RemoveAt(Int32.Parse(toRemove)-1);
                    Console.Clear();
                    Console.WriteLine("Removed item " + toRemove);
                } else {
                    Console.Clear();
                    Console.WriteLine("Sorry, invalid selection.");
                }
                Console.WriteLine("============================");
                menu();
            }

            void completeTask() {
                Console.Clear();
                Console.WriteLine("============================");
                for (int i = 0; i < tasks.Count; i++) {
                    if(status[i] == false) {
                        Console.WriteLine((i+1) + ". " + tasks[i]);
                    }
                }
                Console.WriteLine("----------------------------");
                Console.WriteLine("What task would you like to mark complete?");
                Console.Write("> ");
                string toComplete = Console.ReadLine();
                if(Int32.Parse(toComplete) <= tasks.Count) {
                    status[Int32.Parse(toComplete)-1] = true;
                    Console.Clear();
                    Console.WriteLine("Marked item " + toComplete + " complete.");
                } else {
                    Console.Clear();
                    Console.WriteLine("Sorry, invalid selection.");
                }
                Console.WriteLine("============================");
                menu();
            }

            void listTasks() {
                Console.Clear();
                Console.WriteLine("============================");
                if(tasks.Count == 0) {
                    Console.WriteLine("No tasks to show!");
                } else {
                    Console.WriteLine("Here are the current tasks:");
                    for (int i = 0; i < tasks.Count; i++) {
                        Console.Write(" - " + tasks[i]);
                        if(status[i] == true) {
                            Console.WriteLine(" (COMPLETED)");
                        } else {
                            Console.WriteLine(" ");
                        }
                    }
                }
                Console.WriteLine("----------------------------");
                menu();
            }
            Console.Clear();
            menu();
        }
    }
}
