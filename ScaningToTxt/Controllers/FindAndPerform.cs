using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
            OcrResult results = Ocr.Read(returnFiles);
            results.SaveAsTextFile(pathToText);
            Console.WriteLine(results.Text);
        }

        
    }


}
