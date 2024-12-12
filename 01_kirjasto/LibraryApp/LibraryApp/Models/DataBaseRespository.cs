using LibraryApp.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Models
{
    public class DataBaseRespository
    {
        private string _connectionString;

        public DataBaseRespository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Book> GetNewBooks()
        {
            List<Book> Books = new();

            using var dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            using var command = new SqlCommand("select * from Book where PublicationYear >= year(getdate()) - 5", dbConnection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Book book = new()
                {
                    Id = Convert.ToInt32(reader["BookId"]),
                    Title = reader["Title"].ToString(),
                    ISBN = reader["ISBN"].ToString(),
                    PublicationYear = Convert.ToInt32(reader["PublicationYear"]),
                    AvailableCopies = Convert.ToInt32(reader["AvailableCopies"])
                };
                Books.Add(book);
            }

            return Books;
        }

        public int GetAvgAge()
        {
            List<Member> Members = new();

            using var dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            using var command = new SqlCommand("select avg(year(getdate()) - year(Birthday)) as Average from Member;", dbConnection);
            using var reader = command.ExecuteReader();
            reader.Read();
         

            return Convert.ToInt32(reader[0]);
        }

        public List<Book> GetMostBooks()
        {
            List<Book> Books = new();

            using var dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            using var command = new SqlCommand("select top 1 * from Book order by AvailableCopies desc", dbConnection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Book book = new()
                {
                    Id = Convert.ToInt32(reader["BookId"]),
                    Title = reader["Title"].ToString(),
                    ISBN = reader["ISBN"].ToString(),
                    PublicationYear = Convert.ToInt32(reader["PublicationYear"]),
                    AvailableCopies = Convert.ToInt32(reader["AvailableCopies"])
                };
                Books.Add(book);
            }

            return Books;
        }

        public List<string> GetLoaners()
        {
            List<string> Loans = new();

            using var dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            using var command = new SqlCommand("select FirstName, LastName, ISBN from Loan left join Member on Loan.MemberId = Member.MemberId left join Book on Loan.BookId = Book.BookId where Loan.MemberID is not null", dbConnection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                string loan = reader["FirstName"] + ", " + reader["LastName"] + ", " + reader["ISBN"];

                Loans.Add(loan);
            }

            return Loans;
        }
    }
}