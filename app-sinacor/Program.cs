using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace app_sinacor
{
    class Program
    {
        private static readonly string _notasFolder
            = @"C:\Users\qualy\Downloads\D";

        private static List<Models.NotaNegociacaoModel> _minhas_notas = new List<Models.NotaNegociacaoModel>();

        static void Main(string[] args)
        {
            GetStringsFromFiles();
            GetValuesFromNota();
            PrintAll();
            PrintIRPFSwingTrade();
        }

        private static void PrintAll()
        {
            foreach (var nota in _minhas_notas)
            {
                var v0 = nota.Pregao.ToShortDateString();
                var v1 = nota.ResumoDosNegocios.Vendas_a_Vista.ToString("N2");
                var v2 = nota.ResumoFinanceiro.IRRF.ToString("N2");
                Console.WriteLine($"{v0} | IRRF {v2} | Venda {v1}");
            }
        }

        private static void PrintIRPFSwingTrade()
        {
            var groupsByPregao = _minhas_notas
                .GroupBy(a => a.Pregao.ToString("MM/yyyy"))
                .Select(a => new
                {
                    Mes = a.Key,
                    Vendas_a_Vista = a.Sum(a => a.ResumoDosNegocios.Vendas_a_Vista),
                    IRRF = a.Sum(a => a.ResumoFinanceiro.IRRF)
                });

            foreach (var item in groupsByPregao)
            {
                var v0 = item.Mes;
                var v1 = item.Vendas_a_Vista.ToString("N2");
                var v2 = item.IRRF.ToString("N2");
                Console.WriteLine($"Mes {v0} | IRRF {v2} | Venda {v1}");
            }
        }

        private static void GetValuesFromNota()
        {
            _minhas_notas
                .ForEach(nota => 
                    new Services.NotaNegociacaoService(nota)
                        .ExtractValuesFromNotaString());
        }

        private static void GetStringsFromFiles()
        {
            Directory.GetFiles(_notasFolder)
               .ToList()
               .ForEach(file =>
                   _minhas_notas.Add(
                       new Models.NotaNegociacaoModel()
                       {
                           File = file,
                           TextFromFile =
                           Services.PdfService.ExtractTextFromPdf(file)
                       }));
        }
    }
}
