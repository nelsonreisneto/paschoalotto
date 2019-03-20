using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CalculoDividaModel.Models
{
    public class Parcela
    {
        [Key]
        public long ParcelaId { get; set; }
        public int Numero { get; set; }
        public double Valor { get; set; }        
        public DateTime DtVencimento { get; set; }

        [ForeignKey("DebitoId")]
        public int DebitoId { get; set; }

        public override string ToString()
        {
            return Numero + " - " +
                   " Valor: " + Valor + " - " +
                   " Data Vencimento: " + DtVencimento;
        }

    }
}
