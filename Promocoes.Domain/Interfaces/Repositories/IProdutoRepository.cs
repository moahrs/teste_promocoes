using System.Collections.Generic;

namespace Promocoes.Domain.Interfaces.Repositories
{
    public interface IProdutoRepository : IRepositoryBase<Produto>
    {
        IEnumerable<Produto> BuscarPorDesc(string descProd);
        decimal DevolveValorCalculado(int idProd, int qtdProd);
    }
}
