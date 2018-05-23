using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using app.Models;

namespace app.Services {
    public class PedidoService : IPedidoService {
        public Task<Pedido> CreateAsync () {
            var pedido = new Pedido { Id = new Guid (), DataCriacao = DateTime.Now };
            return pedido;
        }

        public Task<IEnumerable<Pedido>> ReadAllAsync () {
            throw new System.NotImplementedException ();
        }
    }
}