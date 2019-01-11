using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronOcr;
using System.IO;
using ScaningToTxt.Controllers;


namespace ScaningToTxt
{
    class Program
    {
        static void Main(string[] args)
        {
            FindAndPerform findAndPerform = new FindAndPerform();
            Console.WriteLine("Cześć Mamo,\n ten program zaciagnie wszystkie pliki które sa w: \n " +
                "{0} \n zrobi z nich pliki txt ktore umiesci w \n {1}" +
                "\n i skopiuje skan do folderu \n {2}\n, zmieni im nazwy na odpowiadajace numerowi faktury.\n POWODZENIA! ", findAndPerform.pathToScan, findAndPerform.pathToText, findAndPerform.pathToScanWithName);

            findAndPerform.CreateTextFile();

            Console.WriteLine("Szczesliwe skonczylem zadanie. Zobacz teraz w folderze \n {0} \n czy sa wszystkie dane",findAndPerform.pathToText);
           
            Console.ReadKey();
        }
    }
}
