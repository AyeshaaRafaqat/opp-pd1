using System;

namespace UETApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleHelper.SetConsoleColor();
            AppHeader.Display();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to UET Management System");
                Console.WriteLine("1. Register as Student");
                Console.WriteLine("2. Register as Organization");
                Console.WriteLine("3. Update Student Record");
                Console.WriteLine("4. Update Organization Record");
                Console.WriteLine("5. Delete Student Record");
                Console.WriteLine("6. Delete Organization Record");
                Console.WriteLine("7. Exit");
                Console.Write("Enter your choice: ");
                
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        SubHeader.DisplayForStudents();
                        DataHandler.HandleSignUp(1);
                        break;
                    case 2:
                        SubHeader.DisplayForOrganizations();
                        DataHandler.HandleSignUp(2);
                        break;
                    case 3:
                        SubHeader.DisplayForStudents();
                        DataHandler.UpdateRecord(1);
                        break;
                    case 4:
                        SubHeader.DisplayForOrganizations();
                        DataHandler.UpdateRecord(2);
                        break;
                    case 5:
                        SubHeader.DisplayForStudents();
                        DataHandler.DeleteRecord(1);
                        break;
                    case 6:
                        SubHeader.DisplayForOrganizations();
                        DataHandler.DeleteRecord(2);
                        break;
                    case 7:
                        Console.WriteLine("Exiting... Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
