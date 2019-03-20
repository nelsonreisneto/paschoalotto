using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalculoDividaModel.Models
{
    public class Debito
    {
        [Key]
        public long DebitoId { get; set; }
        public DateTime DtVencimento { get; set; }
        public int QntParcelas { get; set; }
        public double ValorOriginal { get; set; }
        public int DiasAtraso { get; set; }
        public double ValorJuros { get; set; }
        public double ValorFinal { get; set; }
        public string Telefone { get; set; }
        public List<Parcela> Parcelas { get; set; }
        public double Comissao { get; set; }

        public override string ToString()
        {
            return "Data de vencimento: " + DtVencimento + " - " +
                   " Dias atraso: " + DiasAtraso + " dias - " +
                   " Valor original: " + ValorOriginal + " - " +
                   " Valor final: " + ValorFinal + " - " +
                   " Telefone de orientação para ligar e negociar com um colaborador: " + Telefone + " / ";
        }
    }
}