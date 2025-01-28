using System;
using System.Data.SqlClient;

namespace UETApp
{
    static class ConsoleHelper
    {
        public static void SetConsoleColor()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Clear();
        }

        public static void ResetColor()
        {
            Console.ResetColor();
        }
    }

    static class AppHeader
    {
        public static void Display()
        {
            Console.WriteLine("******************************************");
            Console.WriteLine("*               @   @   @                *");
            Console.WriteLine("*           @   T   U  N   @             *");
            Console.WriteLine("*         @   R           I  @           *");
            Console.WriteLine("*        @  O               T  @         *");
            Console.WriteLine("*        @  P               Y  @         *");
            Console.WriteLine("*        @  P               B  @         *");
            Console.WriteLine("*          @ O             R  @          *");
            Console.WriteLine("*           @  E  G  D   I  @            *");
            Console.WriteLine("*              @  @  @   @               *");
            Console.WriteLine("******************************************");
            ConsoleHelper.ResetColor();
        }
    }

    static class SubHeader
    {
        public static void DisplayForStudents()
        {
            Console.WriteLine(" ############################## ");
            Console.WriteLine(" #     STUDENT  INTERFACE     # ");
            Console.WriteLine(" ############################## ");
        }

        public static void DisplayForOrganizations()
        {
            Console.WriteLine(" ################################ ");
            Console.WriteLine(" #     ORGANIZATION INTERFACE   # ");
            Console.WriteLine(" ################################ ");
        }
    }

    static class DataHandler
    {
        private const string ConnectionString = "YourConnectionStringHere";

        public static void HandleSignUp(int roleChoice)
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Email: ");
            string email = Console.ReadLine();

            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            string role = roleChoice == 1 ? "Student" : "Organization";
            SaveToDatabase(name, email, password, role);
            Console.WriteLine("Registration successful!");
        }

        private static void SaveToDatabase(string name, string email, string password, string role)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = role == "Student"
                    ? "INSERT INTO Students (Name, Email, Password) VALUES (@Name, @Email, @Password)"
                    : "INSERT INTO Organizations (Name, Email, Password) VALUES (@Name, @Email, @Password)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateRecord(int roleChoice)
        {
            Console.Write("Enter Email of the record to update: ");
            string email = Console.ReadLine();

            Console.Write("Enter New Name: ");
            string newName = Console.ReadLine();

            Console.Write("Enter New Password: ");
            string newPassword = Console.ReadLine();

            string role = roleChoice == 1 ? "Student" : "Organization";
            UpdateInDatabase(email, newName, newPassword, role);
            Console.WriteLine("Record updated successfully!");
        }

        private static void UpdateInDatabase(string email, string newName, string newPassword, string role)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = role == "Student"
                    ? "UPDATE Students SET Name = @NewName, Password = @NewPassword WHERE Email = @Email"
                    : "UPDATE Organizations SET Name = @NewName, Password = @NewPassword WHERE Email = @Email";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NewName", newName);
                    command.Parameters.AddWithValue("@NewPassword", newPassword);
                    command.Parameters.AddWithValue("@Email", email);
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteRecord(int roleChoice)
        {
            Console.Write("Enter Email of the record to delete: ");
            string email = Console.ReadLine();

            string role = roleChoice == 1 ? "Student" : "Organization";
            DeleteFromDatabase(email, role);
            Console.WriteLine("Record deleted successfully!");
        }

        private static void DeleteFromDatabase(string email, string role)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = role == "Student"
                    ? "DELETE FROM Students WHERE Email = @Email"
                    : "DELETE FROM Organizations WHERE Email = @Email";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
