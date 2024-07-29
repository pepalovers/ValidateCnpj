using ApiRequestWs;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http;
using CnpjVerify;
using ApiRequestBrasil;
using System.Timers;
using System.Diagnostics;


namespace MainProg
{
    class Program
    {
        static void Main(string[] args)
        {
            Validation validation = new Validation();
            Console.WriteLine("Write the CNPJ:");
            var cnpj = Console.ReadLine();
            bool IsValid = validation.CheckTrue(cnpj);
            string finalCnpj = validation.CompleteCnpj(cnpj);
            Console.WriteLine(finalCnpj);

            if (IsValid == !false)
            {
                teste(finalCnpj);
            }
            else
            {
                Console.WriteLine("Invalid CNPJ");
            }



        }
        async static void teste(string cnpj)
        {
            //Contador
            int contador = 0;

            //Cronometro
            Stopwatch cronometro = new Stopwatch();
            int tempoTotal = 60;

            Console.WriteLine("Consulta iniciada ás {0:HH:mm:ss.fff}", DateTime.Now);
            cronometro.Start();

            try
            {
                var empresaBrasil = await DadosEmpresaBrasil.GetEmpresa(cnpj);
                Console.WriteLine(empresaBrasil.razao_social);
 
            }
            catch (Exception ex)
            {
                var empresaWs = await DadosEmpresaWs.GetEmpresa(cnpj);

                if (empresaWs != null)
                {
                    Console.WriteLine(empresaWs.razao_social);
                    contador = contador + 1;

                    if (contador <= 3)
                    {
                        Console.WriteLine(cronometro.ElapsedMilliseconds);
                        if (cronometro.Elapsed.TotalSeconds > tempoTotal)
                        {
                            Console.WriteLine("Zerando contador");
                            Console.WriteLine("Cronometro iniciado as {0:HH:mm:ss.fff}", DateTime.Now);
                            cronometro.Reset();
                            cronometro.Start();
                            contador = 0;
                        }
                        else if (contador == 3)
                        {
                            Console.WriteLine("Limite de consultas atingido, por favor aguarde 1 minuto até a próxima consulta");
                            contador = 0;
                            Thread.Sleep(60000);
                        }

                    }

                }
            }

        }
    }
}