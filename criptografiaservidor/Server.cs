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

        public static string Binariar(string valor)
        {
                        int[] numeros = new int[5];

                        string ret = "";

                        foreach (char c in valor)
                        {
                            // Código numérico do caractere.
                            int asc = (int)c;
                            // Concatena a representação string dos 
                            // números binários separados por espaço.
                            ret += Convert.ToString(asc, 2) + " ";
                        }
                        // Exibe o resultado
                        return (ret);
            }

        public static string Desbinariar(string valor)
        {

            string[] strBin = valor.Trim().Split(' ');
            string rec = "";

            foreach (string ele in strBin)
            {
                // Converte a representação string do número
                // num caractere.
                char car = (char)Convert.ToInt32(ele, 2);
                // Concatena os caracteres.
                rec += car;
            }

            // Exibe o resultado.
            return rec;
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

            val1 = Desbinariar(val1);
            operador = Desbinariar(operador);
            val2 = Desbinariar(val2);

            result = Calcular(operador, val1, val2);

            string resultado;

            resultado = Binariar(Convert.ToString(result));

            string nomeArquivo = @"C:\Felipe\Teste2.txt";

            StreamWriter writer = new StreamWriter(nomeArquivo);

            writer.WriteLine(result);

            writer.WriteLine(resultado);

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

