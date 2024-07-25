using ApiRequestWs;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http;
using CnpjValidate;
using CnpjVerify;


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
            try
            {
                var empresaBrasil = await DadosEmpresaWs.GetEmpresa(cnpj);
                Console.WriteLine(empresaBrasil.capital_social);
                Console.WriteLine(empresaBrasil.razao_social);
            }
            catch (Exception ex)
            {
                throw(ex);

            }

        }
    }
}