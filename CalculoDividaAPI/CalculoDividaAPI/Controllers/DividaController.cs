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
    public class DividaController : ControllerBase
    {
        private readonly CalculoDividaContext _context;

        public DividaController(CalculoDividaContext context)
        {
            _context = context;

            if (_context.Debitos.Count() == 0)
            {
                JurosSimples jurosSimples = new JurosSimples(3000.00, new DateTime(2019,03,15), 0.02, 3, 0.1);
                _context.Debitos.Add(jurosSimples.Resultado());

                JurosComposto jurosComposto = new JurosComposto(3000.00, new DateTime(2019, 03, 15), 0.02, 3, 0.1);
                _context.Debitos.Add(jurosComposto.Resultado());
                
                _context.SaveChanges();
            }
        }

        // GET: api/Debito
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Debito>>> GetDebitos()
        {
            return await _context.Debitos.ToListAsync();
        }

        // GET: api/Debito/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Debito>> GetDebitoItem(long id)
        {
            var debito = await _context.Debitos.FindAsync(id);

            if (debito == null)
            {
                return NotFound();
            }

            return debito;
        }
    }
}