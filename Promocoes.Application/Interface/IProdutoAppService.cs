using Promocoes.Domain;
using System.Collections.Generic;

namespace Promocoes.Application.Interface
{
    public interface IProdutoAppService : IAppServiceBase<Produto>
    {
        IEnumerable<Produto> BuscarPorDesc(string descProd);
        decimal DevolveValorCalculado(int idProd, int qtdProd);
    }
}
