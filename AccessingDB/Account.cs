using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;

namespace AccessingDB
{
    class Account
    {
        private int number;
        private decimal balance;
        public Account(int number, decimal balance)
        {
            this.number = number;
            this.balance = balance;
        }
        public override string ToString()
        {
            return number + "-" + balance;
        }

        static String connectionStr =
            @"Data Source=(localdb)\MSSQLLocalDB;
            Initial Catalog=EasyBank;
            Integrated Security=True";
        public void Store(int customerId)
        {
            CultureInfo culture = new CultureInfo("en-US");
            string insert = @"INSERT INTO Accounts VALUES (" + number + ", " + customerId + ", "
            + " CAST ('" + balance.ToString("C3", culture) + "' AS MONEY))";

            SqlConnection connection =
            new SqlConnection(connectionStr);

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = insert;
                // Console.WriteLine("INSERT: " + command.CommandText);
                int count = command.ExecuteNonQuery();
            }
            catch (SqlException x)
            {
                Console.WriteLine(x.Message);
            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }

        public static Account Load(int number)
        {
            string query =
            @"SELECT * FROM Accounts WHERE accountId=" + number;
            // Console.WriteLine("QUERY: " + query);
            SqlConnection connection =
           new SqlConnection(connectionStr);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = query;
                SqlDataReader reader =
               command.ExecuteReader();
                reader.Read();
                /*
                 Console.WriteLine("Column Name: " + reader.GetName(2));
                Console.WriteLine("SQL Type: " + reader.GetDataTypeName(2));
                Console.WriteLine(".NET Type: " + reader.GetFieldType(2));
                */
                Account account = new
               Account(number, reader.GetDecimal(2));
                reader.Close();
                return account;
            }
            catch (SqlException x)
            {
                Console.WriteLine(x.Message);
            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return null;
        }
    }
}
