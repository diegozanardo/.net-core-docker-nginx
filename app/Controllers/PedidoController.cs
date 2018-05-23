using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace app.Controllers
{
    [Route("api/[controller]")]
    public class PedidoController : Controller
    {
        readonly IPedidoService _pedidoService; 

        public PedidoController(IPedidoService pedidoService){
            _pedidoService = pedidoService ?? throw new ArgumentNullException(nameof(pedidoService));
        }
        
        [HttpGet]
        public async Task<IActionResult> ReadAllAsync()
        {
             var pedidos = await _pedidoService.ReadAllAsync();
             return Ok(pedidos);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> CreateAsync()
        {
            var pedido = await _pedidoService.CreateAsync();
            return Ok(pedido);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
