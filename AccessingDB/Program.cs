using System.Data;
using Microsoft.Data.SqlClient;
using System.Globalization;
using Microsoft.VisualStudio.Services.Account;

namespace AccessingDB
{
    class Program

{
        static void Main ()
        {

         Account account = new Account(9, 6000.0m);
         Console.WriteLine(account);

         account.Store(1);

         account = new Account(10, 6000.0m);
         Console.WriteLine(account);

         account.Store(2);

         Account clone = Account.Load(10);

         Console.WriteLine(clone);

        }
    }

}