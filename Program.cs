using System;
using System.Data.SqlClient;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите имя пользователя:");
        string username = Console.ReadLine();

        // УЯЗВИМОСТЬ: SQL Injection (использование пользовательского ввода напрямую в запросе)
        string query = "SELECT * FROM Users WHERE Username = '" + username + "'";

        using (SqlConnection connection = new SqlConnection("Server=localhost;Database=TestDB;Trusted_Connection=True;"))
        {
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader["Username"]);
            }
            reader.Close();
        }
    }
}
