using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CalculoDividaData.DataContexts;
using CalculoDividaModel.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using CalculoDividaServices.Services.Juros;
using System;

namespace CalculoDividaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParcelaController : ControllerBase
    {
        private readonly CalculoDividaContext _context;

        public ParcelaController(CalculoDividaContext context)
        {
            _context = context;

            if (_context.Parcelas.Count() == 0)
            {
                JurosSimples jurosSimples = new JurosSimples(3000.00, new DateTime(2019, 03, 15), 0.02, 3, 0.1);
                jurosSimples.GetParcelas().ForEach(s =>
                _context.Parcelas.Add(s));

                JurosComposto jurosComposto = new JurosComposto(3000.00, new DateTime(2019, 03, 15), 0.02, 3, 0.1);
                jurosComposto.GetParcelas().ForEach(c =>
                _context.Parcelas.Add(c));

                _context.SaveChanges();
            }
        }

        // GET: api/Parcela
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Parcela>>> GetParcelas()
        {
            return await _context.Parcelas.ToListAsync();
        }

        // GET: api/Parcela/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Parcela>> GetParcelaItem(long id)
        {
            var debito = await _context.Parcelas.FindAsync(id);

            if (debito == null)
            {
                return NotFound();
            }

            return debito;
        }
    }
}
