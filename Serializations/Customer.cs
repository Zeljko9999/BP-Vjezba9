using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace Serializations
{
    [Serializable]
    class Customer
    {
        private string name;
        private List<Account> accounts;
        public Customer(String name, List<Account> accounts)
        {
            this.name = name;
            this.accounts = accounts;
        }
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append(name + ": ");
            foreach (Account account in accounts)
                str.Append(account + ", ");
            return str.ToString();
        }
    }

}
