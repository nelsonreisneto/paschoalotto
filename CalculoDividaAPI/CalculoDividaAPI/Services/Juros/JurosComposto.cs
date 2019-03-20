using CalculoDividaModel.Models;
using System;
using System.Collections.Generic;

namespace CalculoDividaServices.Services.Juros
{

    // Formula do Juros: EMI = ((p*r/12) (1+r/12)^n) / ((1+r/12)^n - 1 ) -> onde P = Valor do empréstimo, r = taxa de juros mensal = taxa anual de juros/12/100 , n = duração do empréstimo em número de meses
    public class JurosComposto : IJuros
    {
        private double DividaInicial;
        private double TaxaJuros;
        private double Comissao;
        private int TotalParcelas;
        private DateTime DtAcordo = DateTime.Now;
        private DateTime DtVencimento;

        public JurosComposto(double dividaInicial, DateTime vencimento, double taxaJuros, int totalParcelas, double comissao)
        {
            DividaInicial = dividaInicial;
            TaxaJuros = taxaJuros;
            DtVencimento = vencimento;
            TotalParcelas = totalParcelas;
            Comissao = comissao;
        }

        public Debito Resultado()
        {
                return new Debito
                {
                    ValorOriginal = DividaInicial,
                    ValorFinal = Math.Round(ValorTotalDivida(), 2),
                    ValorJuros = Math.Round(ValorJuros(), 2),
                    QntParcelas = TotalParcelas,
                    Parcelas = GetParcelas(),
                    DtVencimento = DtVencimento,
                    Telefone = "(xx) xxxx-xxxx",
                    DiasAtraso = DiferencaDias(DtVencimento, DtAcordo),
                    Comissao = Math.Round(ValorTotalComissionado(), 2)
                };
        }

        public double ValorParcela()
        {
                return ValorTotalDivida() / TotalParcelas;
        }

        public double ValorTotalDivida()
        {
                double valor;
                valor = DividaInicial * Math.Pow((1 + TaxaJuros), DiferencaDias(DtVencimento, DtAcordo));
                return valor;
        }

        public double ValorTotalComissionado()
        {
                double total = ValorTotalDivida();
                return total + Comissao * ValorTotalDivida();            
        }

        public double ValorJuros()
        {           
                return ValorTotalDivida() - DividaInicial;
            
        }

        public List<Parcela> GetParcelas()
        {
            List<Parcela> parcelas = new List<Parcela>();
            for (int i = 0; i < TotalParcelas; i++)
            {
                parcelas.Add(new Parcela
                {
                    Numero = i + 1,
                    Valor = Math.Round(ValorParcela(), 2),
                    DtVencimento = DtAcordo.AddMonths(i)
                });
            }
            return parcelas;
        }

        private int DiferencaMes(DateTime dataInicial, DateTime dataFinal)
        {
            int diferenca = 12 * (dataInicial.Year - dataFinal.Year) + dataInicial.Month - dataFinal.Month;
            return Math.Abs(diferenca);
        }

        private int DiferencaDias(DateTime dataInicial, DateTime dataFinal)
        {
            TimeSpan dif = dataFinal - dataInicial;
            return dif.Days;
        }
    }
}
