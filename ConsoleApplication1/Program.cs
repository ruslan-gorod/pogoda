using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleApplication1.ServiceReference1;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            ServClient client = new ServClient();

            Console.WriteLine(client.GetData("2015-11-6"));

            client.Close();

            Console.Read();
             
        }
    }
}
