﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using IronOcr;

namespace ScaningToTxt.Controllers
{
    class FindAndPerform
    {   
        public string pathToScan { get; set; }
        public string pathToText { get; set; }
        public string pathToScanWithName { get; set; }
        

        public FindAndPerform()
        {
            pathToScan =@"C:\Księgowa2019\Skany";
            pathToText= @"C:\Księgowa2019\Text";
            pathToScanWithName= @"C:\Księgowa2019\SkanZPoprawnaNazwa";

            if (!Directory.Exists(pathToText))
            {
                Directory.CreateDirectory(pathToText);
            }
            if (!Directory.Exists(pathToScanWithName))
            {
                Directory.CreateDirectory(pathToScanWithName);
            }
        }

        public void CreateTextFile()
        {
            string [] returnFiles = Directory.GetFiles(pathToScan);
            AdvancedOcr Ocr = new IronOcr.AdvancedOcr()
            {
                CleanBackgroundNoise = true,
                EnhanceContrast = true,
                EnhanceResolution = true,
                Language = IronOcr.Languages.Polish.OcrLanguagePack,
                Strategy = IronOcr.AdvancedOcr.OcrStrategy.Advanced,
                ColorSpace = AdvancedOcr.OcrColorSpace.Color,
                DetectWhiteTextOnDarkBackgrounds = true,
                InputImageType = AdvancedOcr.InputTypes.AutoDetect,
                RotateAndStraighten = true,
                ReadBarCodes = true,
                ColorDepth = 4
            };
            List<Task> tasks = new List<Task>();
            foreach (var file in returnFiles)
            {                
                tasks.Add(
                    Task.Factory.StartNew(() =>
                    {
                        OcrResult ocrResult = new OcrResult();
                        ocrResult = Ocr.Read(file);
                        string text = ocrResult.Text;
                        string name =Regex.Match(text,@"FAKTURA NR ([A-Za-z-0-9\/-]+)").Value;
                        name = name.Replace(@"\", "_");
                        name = name.Replace(@"/", "_");
                        ocrResult.SaveAsTextFile(pathToText+@"\"+name+".txt");                        
                        File.Copy(file, pathToScanWithName + @"\" + name+Path.GetExtension(file));
                    }) 
                );                

            }
            Task.WaitAll(tasks.ToArray());            
        }

        
    }


}
