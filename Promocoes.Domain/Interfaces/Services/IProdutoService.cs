using System.Collections.Generic;

namespace Promocoes.Domain.Interfaces.Services
{
    public interface IProdutoService : IServiceBase<Produto>
    {
        IEnumerable<Produto> BuscarPorDesc(string descProd);
    }
}
