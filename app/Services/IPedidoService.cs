using System.Collections.Generic;
using System.Threading.Tasks;
using app.Models;

namespace app.Services
{
    public interface IPedidoService
    {
        Task<IEnumerable<Pedido>> ReadAllAsync();
        Task<Pedido> CreateAsync();
    }
}