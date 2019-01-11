using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronOcr;


namespace ScaningToTxt
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] paths = { @"C:\Księgowa2019\Skany\Faktura1.jpg" };
            Console.WriteLine("To jest argument args[0]={0}", args[0]);
           
            Console.ReadKey();
        }
    }
}
