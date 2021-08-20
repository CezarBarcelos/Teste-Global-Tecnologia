using System;
using System.Diagnostics;

namespace TesteGlobalTecnologia
{
    class Program
    {
        static Stopwatch relogio = new Stopwatch();
        static string valIni = string.Empty;
        static string valFin = string.Empty;

        /// <summary>
        /// Método principal
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {
                do
                {
                    Console.WriteLine("Informe o valor inicial: ");
                    valIni = Console.ReadLine();
                } while (!ValidaInt(valIni));

                do
                {
                    Console.WriteLine("Informe o valor final: ");
                    valFin = Console.ReadLine();
                } while (!ValidaInt(valFin));

                relogio.Start();
                Console.WriteLine("\n\nProcessando...aguarde.");

                long[] divisores = ObtemDivisores(Convert.ToInt32(valIni), Convert.ToInt32(valFin));
                long resultado = ObtemMenorDivisor(divisores);

                Console.WriteLine("O Menor divisor da sequencia [ " + divisores[0] + " - " + divisores[divisores.Length - 1] + " ]: " + resultado);
                Console.WriteLine("Tempo gasto: " + relogio.ElapsedMilliseconds + "ms");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Monta o intervalo de Divisores
        /// </summary>
        /// <param name="valIni">Valor inicial da Sequencia</param>
        /// <param name="valFin">Valor final da Sequencia</param>
        /// <returns></returns>
        static long[] ObtemDivisores(int valIni, int valFin)
        {
            long[] divisores = new long[valFin];

            try
            {
                for (int i = 0; i < valFin; i++)
                {
                    divisores[i] = i + 1;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return divisores;
        }

        /// <summary>
        /// Obtem o menor Divisor de uma sequencia de números inteiros
        /// </summary>
        /// <param name="divisores">Sequencia de Divisores</param>
        /// <returns>Retorna o Menor divisor</returns>
        public static long ObtemMenorDivisor(long[] divisores)
        {
            int counter = 0;
            int maxCounter = 0;
            long dividendo = 1;

            try
            {
                while (true)
                {
                    for (int i = 0; i < divisores.Length; i++)
                    {
                        if (!VerificaDivisaoExata(dividendo, divisores[i]))
                        {
                            break;
                        }
                        else
                        {
                            counter++;
                            if (counter > maxCounter)
                            {
                                maxCounter = counter;
                            }
                            if (counter == divisores.Length) { return dividendo; }
                        }
                    }

                    dividendo++;
                    if (dividendo % 100000000 == 0)
                    {
                        Console.WriteLine("Ciclos: " + dividendo + " - Máx. Seq. Divisores: [ " + maxCounter + " ]");
                    }
                    counter = 0;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Verifica se a divisão é exata
        /// </summary>
        /// <param name="dividendo">Dividendo</param>
        /// <param name="divisor">Divisor</param>
        /// <returns></returns>
        private static bool VerificaDivisaoExata(long dividendo, long divisor)
        {
            try
            {
                if (dividendo % divisor == 0) { return true; }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return false;
        }

        /// <summary>
        /// Valida se o valor de entrada é apenas dígitos
        /// </summary>
        /// <returns></returns>
        private static bool ValidaInt(string val)
        {
            for (int i = 0; i < val.Length; i++)
            {
                if(!Char.IsDigit(val[i]))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("O valor não é um número válido.");
                    Console.ForegroundColor = ConsoleColor.White;
                    return false;
                }
            }

            return true;
        }
    }
}
