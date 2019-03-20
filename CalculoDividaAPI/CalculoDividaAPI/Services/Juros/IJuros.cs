using CalculoDividaModel.Models;

namespace CalculoDividaServices.Services.Juros
{
    interface IJuros
    {
        Debito Resultado();
        double ValorTotalDivida();
        double ValorTotalComissionado();
        double ValorParcela();
        double ValorJuros();
    }
}
