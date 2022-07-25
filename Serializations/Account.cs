using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace Serializations
{
    [Serializable]
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
    }
}
