using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_sinacor.Models
{
    public class ResumoFinanceiroModel
    {
        // Clearing
        public decimal ValorLiquidoDasOperacoes { get; set; }
        public decimal TaxaDeLiquidacao { get; set; }
        public decimal TaxaDeRegistro { get; set; }
       
        // Bolsa
        public decimal Emolumentos { get; set; }
       
        // Custos Operacionais
        public decimal TaxaOperacional { get; set; }
        public decimal TaxaDeCustodia { get; set; }
        public decimal Impostos { get; set; }
        public decimal IRRF { get; set; }
        public decimal Outros { get; set; }
    }
}
