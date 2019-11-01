using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace criptografiaservidor
{
    public class Server
    {
        static void Main()
        {
            Arquivo();
        }


        public static void Arquivo()
        {
            //string text = System.IO.File.ReadAllText(@"C:\Felipe\Teste.txt");

            //System.Console.WriteLine("Contents of WriteText.txt = {0}", text);

            string[] lines = System.IO.File.ReadAllLines(@"C:\Felipe\Teste.txt");

            System.Console.WriteLine("Contents of WriteLines2.txt = ");
            foreach (string line in lines)
            {
                Console.WriteLine("\t" + line);
            }

            Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
    }
}

