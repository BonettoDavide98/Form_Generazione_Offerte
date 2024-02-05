using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Offerte.Datatype
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string CodiceEsterno { get; set; }
        public string RagioneSociale { get; set; }
        public string Indirizzo { get; set; }
        public string NumeroCivico { get; set; }
        public string CodiceERP { get; set; }
        public string Piva { get; set; }
        public string IndirizzoBreve { get; set; }
        public string Cap { get; set; }
        public string Citta { get; set; }
        public string Provincia { get; set; }
        public string Telefono { get; set; }
        public string Fax { get; set; }
        public string Conto { get; set; }
        public int IdAzienda { get; set; }
        public bool Attivo { get; set; }
        public DateTime UltimaModifica { get; set; }

        public string CondizionePagamento { get; set; }
    }
}
