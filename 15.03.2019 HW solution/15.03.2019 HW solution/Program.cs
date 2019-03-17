using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15._03._2019_HW_solution
{
    class Program
    {
        static void Main(string[] args)
        {
            MyProtectedUniqueList a = new MyProtectedUniqueList("Iliya");
            a.Add("Programmer");
            a.Add("Computer");
            a.Add("Mascoret");

            Console.WriteLine(a);
            try
            {
                a.Add("");
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}
