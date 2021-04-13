using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_sinacor.Models
{
    public class NotaNegociacaoModel
    {
        public NotaNegociacaoModel()
        {
            this.NegociosRealizados = new List<NegociosRealizadosModel>();
            this.ResumoDosNegocios = new ResumoDosNegociosModel();
            this.ResumoFinanceiro = new ResumoFinanceiroModel();
        }

        public string File { get; set; }
        public string TextFromFile { get; set; }

        public string NumeroNota { get; set; }
        public DateTime Pregao { get; set; }

        public List<Models.NegociosRealizadosModel> NegociosRealizados { get; set; }
        public Models.ResumoDosNegociosModel ResumoDosNegocios { get; set; }
        public Models.ResumoFinanceiroModel ResumoFinanceiro { get; set; }
    }
}
