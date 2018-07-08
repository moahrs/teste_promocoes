using Promocoes.Domain.Entities;
using System.Collections.Generic;

namespace Promocoes.Domain.Interfaces.Repositories
{
    public interface ICarrinhoRepository
    {
        bool CriaCarrinho();
        Dictionary<int, Carrinho> AdicionaProduto(Produto produto, int qtdProd);
        Dictionary<int, Carrinho> RetiraProduto(int idProd);
        Dictionary<int, Carrinho> DevolveConteudo();
    }
}
