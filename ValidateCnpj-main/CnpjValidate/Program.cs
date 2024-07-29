using ApiRequestWs;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http;
using CnpjVerify;
using ApiRequestBrasil;
using System.Threading;
using ArrayCnpj;




namespace MainProg
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] cnpj = {"00.360.305/0001-04", "02.828.446/0001-34", "72.610.132/0001-46",
    "01.874.354/0001-28",
    "04.220.692/0001-34",
    "26.159.125/0001-52",
    "12.146.377/0001-32",
    "06.034.513/0001-08",
    "02.006.030/0001-30",
    "13.080.788/0001-35",
    "15.358.677/0001-73","11.695.583/0001-39", "07.744.937/0001-10", "39.501.564/0001-43", "07.023.840/0001-19",
    "07.126.280/0001-28", "03.431.231/0001-48", "00.711.033/0001-40", "07.282.933/0001-68",
    "09.159.197/0001-80", "08.114.089/0001-29", "25.144.592/0001-46", "02.415.536/0001-01",
    "58.337.668/0001-09", "05.378.545/0001-50", "17.315.744/0001-06", "02.930.089/0001-10",
    "02.287.137/0001-02", "07.251.445/0001-93", "06.914.095/0001-35", "07.473.520/0001-60",
    "08.354.018/0001-01", "06.978.026/0001-95", "05.103.099/0001-70", "13.715.241/0001-69",
    "18.440.324/0001-06", "86.825.619/0001-50", "69.030.377/0001-90", "09.389.786/0001-55",
    "14.104.964/0001-94", "13.878.352/0001-96"};
        

        
            Validation validation = new Validation();
            foreach(string consulta  in cnpj)
            {
                bool IsValid = validation.CheckTrue(consulta);
                string finalCnpj = validation.CompleteCnpj(consulta);
                Console.WriteLine(finalCnpj);

                if (IsValid == !false)
                {

                    teste(finalCnpj);
                    continue;


                }
                else
                {
                    Console.WriteLine("Digite corretamente o CNPJ");
                }
            }



        }
        async static void teste(string cnpj)
        {

            while (true)
            {
                var empresa = await DadosEmpresaBrasil.GetEmpresa(cnpj);
               
                if (empresa != null)
                {
                    Console.WriteLine(empresa.razao_social);
                    break;
                }
                else
                {
                    Console.WriteLine("Erro, executando outra consulta");

                    var empresaBrasil = await DadosEmpresaWs.GetEmpresa(cnpj);
       
                        
                    if (empresaBrasil != null)
                    {
                        Console.WriteLine(empresaBrasil.razao_social);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Erro, aguarde 10 segundos até a próxima consulta");
                        Thread.Sleep(10000);
                        break;
                            
                    }
                }
            }

            
            
        }
    }
}