using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Serializations
{
    class Program
    {
        public static Customer CreateCustomer()
        {
        List<Account> accounts = new List<Account>();
        Account a = new Account(1, 100m);
        Account b = new Account(2, 200m);
        Account c = new Account(3, 300m);
        accounts.Add(a);
        accounts.Add(b);
        accounts.Add(c);
        Customer customer = new Customer("Iva", accounts);
        return customer;
        }

        static void Main()
        {
            Customer customer = CreateCustomer();
            Console.WriteLine(customer);
            String fileName = "Customer.dat";
            BinaryFormatter formatter = new BinaryFormatter();
            Stream output = File.Create(fileName);
            try
            {
                formatter.Serialize(output, customer);
            }
            catch (SerializationException x)
            {
                Console.WriteLine(x.Message);
            }
            finally
            {
                output.Close();
            } 

            Customer clone = null;
            Stream input = File.OpenRead(fileName);

            try
            {
                clone = (Customer)formatter.Deserialize(input);
            }
            catch (SerializationException x)
            {
                Console.WriteLine(x.Message);
            }
            finally
            {
                input.Close();
            }

            Console.WriteLine(clone);

        }
    }
}

