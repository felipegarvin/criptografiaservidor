using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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

            string[] lines = System.IO.File.ReadAllLines(@"C:\Felipe\Teste.txt");

            string operador;
            string val1;
            string val2;
            double result;

            val1 = Convert.ToString(lines[0]);
            operador = Convert.ToString(lines[1]);
            val2 = Convert.ToString(lines[2]);
            
            result = Calcular(operador, val1, val2);

            string nomeArquivo = @"C:\Felipe\Teste2.txt";

            StreamWriter writer = new StreamWriter(nomeArquivo);

            writer.WriteLine(result);

            writer.Close();

        }
        public static double Calcular(string operador, string val1, string val2)
        {
            double result = 0;

            if (operador == "+")
            {
                result = Convert.ToDouble(val1) + Convert.ToDouble(val2);
            }
            else if (operador == "-")
            {
                result = Convert.ToDouble(val1) - Convert.ToDouble(val2);
            }
            else if (operador == "*")
            {
                result = Convert.ToDouble(val1) * Convert.ToDouble(val2);
            }
            else if (operador == "/")
            {
                result = Convert.ToDouble(val1) / Convert.ToDouble(val2);
            }
            else
            {
                result = 0;
            }

            return result;
        }

        }
}

