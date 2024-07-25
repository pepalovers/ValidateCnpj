using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Text;


namespace CnpjVerify
{

    public class Validation
    {
        //public static void Main(string[] args)
        //{
        //    Console.WriteLine("Write the CNPJ:");
        //    string cnpj = Console.ReadLine();
        //    bool IsValid = Check(cnpj);
        //    Console.WriteLine(IsValid);

        //    if (IsValid == !false)
        //    {
        //        string formatedCnpj = Format(cnpj);
        //        Console.WriteLine(formatedCnpj);
        //    }
        //    else
        //    {
        //        Console.WriteLine("Invalid CNPJ");
        //    }
        //}

        public bool CheckTrue(string cnpj)
        {
            string cleanedCnpj = Regex.Replace(cnpj, @"[^\d]", "");
            return cleanedCnpj.Length == 14;
        }

        public string CompleteCnpj(string cnpj)
        {
            Validation validation = new Validation();
            bool validate = validation.CheckTrue(cnpj);
            if (validate == true)
            {
                string cleanedCnpj = Regex.Replace(cnpj, @"[^\d]", "");
                return cleanedCnpj;
            }
            else
            {
                return "CNPJ Invalido";
            }
        }
        public string Format(string cnpj)
        {

            string cleanToFormat = Regex.Replace(cnpj, @"[^\d]", "");

            cleanToFormat = cleanToFormat.Insert(2, ".");
            cleanToFormat = cleanToFormat.Insert(6, ".");
            cleanToFormat = cleanToFormat.Insert(10, "/");
            cleanToFormat = cleanToFormat.Insert(15, "-");

            return cleanToFormat;
        }


    }
}