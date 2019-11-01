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
        static string[] original = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "+", "-", "*", "/", "=", "," };

        static string[] cripto = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p" };

        static void Main()
        {
            Arquivo();
        }

        public static string Criptografar(string valor)
        {
            int numero = valor.Length;

            char[] letras = new char[numero];
            string[] letrascript = new string[numero];

            letras = valor.ToCharArray();


            for (int i = 0; i < letras.Length; i++)
            {
                for (int j = 0; j < original.Length; j++)
                {
                    if (Convert.ToString(letras[i]) == original[j])
                    {
                        letrascript[i] = cripto[j];
                    }
                }

            }

            string palavracripto = "";

            foreach (var item in letrascript)
            {
                palavracripto = palavracripto + "" + item;
            }

            return palavracripto;

        }

        public static string Decriptografar(string strValor1)
        {
            int numero = strValor1.Length;

            char[] letras = new char[numero];
            string[] letrascript = new string[numero];

            letras = strValor1.ToCharArray();


            for (int i = 0; i < letras.Length; i++)
            {
                for (int j = 0; j < original.Length; j++)
                {
                    if (Convert.ToString(letras[i]) == cripto[j])
                    {
                        letrascript[i] = original[j];
                    }
                }

            }

            string palavracripto = "";

            foreach (var item in letrascript)
            {
                palavracripto = palavracripto + "" + item;
            }

            return palavracripto;
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

            if(System.IO.File.Exists(@"C:\Temp\Retorno.txt")){
                try
                {
                    System.IO.File.Delete(@"C:\Temp\Retorno.txt");
                }
                catch (System.IO.IOException e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }

                string[] lines = System.IO.File.ReadAllLines(@"C:\Temp\Envio.txt");

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

            val1 = Decriptografar(val1);
            operador = Decriptografar(operador);
            val2 = Decriptografar(val2);

            result = Calcular(operador, val1, val2);

            string resultado;

            resultado = Criptografar(Convert.ToString(result));

            resultado = Binariar(resultado);

            string nomeArquivo = @"C:\Temp\Retorno.txt";

            StreamWriter writer = new StreamWriter(nomeArquivo);

            writer.WriteLine(lines[0]);

            writer.WriteLine(lines[1]);

            writer.WriteLine(lines[2]);

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

