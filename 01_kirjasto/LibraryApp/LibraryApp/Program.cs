using LibraryApp.Models;
using Microsoft.Data.SqlClient;

class Program
{
    static void Main(string[] args)
    {
        var builder = new SqlConnectionStringBuilder
        {
            DataSource = "(localdb)\\MSSQLLocalDB",
            InitialCatalog = "library"
        };

        var connectionString = builder.ConnectionString;

        var connection = new DataBaseRespository(connectionString);

        var teht = connection.GetNewBooks();

        var teht2 = connection.GetAvgAge();

        var teht3 = connection.GetMostBooks();

        var teht4 = connection.GetLoaners();

        foreach (var member in teht)
        {
            Console.WriteLine(member.Title);
        }
        
            Console.WriteLine(teht2);

        foreach (var member in teht3)
        {
            Console.WriteLine(member.Title);
        }

        foreach (var answer in teht4)
        {
            Console.WriteLine(answer);
        }

    }
}
