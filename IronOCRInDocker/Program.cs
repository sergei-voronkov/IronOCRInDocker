namespace IronOCRInDocker
{
    using IronOcr;
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Starting...");

            Installation.LicenseKey = "IRONOCR......";

            TesseractConfiguration configuration = new()
            {
                EngineMode = TesseractEngineMode.LstmOnly,
                TesseractVersion = TesseractVersion.Tesseract5
            };

            IronTesseract engine = new(configuration);
            engine.Language = OcrLanguage.EnglishBest;

            using OcrInput input = new();

            input.AddPdf(
                @"2021-09-15_122850.pdf");

            var result = engine.ReadAsync(input).Result;

            Console.WriteLine(result.Text.Substring(0, 200));
        }
    }
}