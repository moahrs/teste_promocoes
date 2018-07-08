using Promocoes.Domain;
using Promocoes.Domain.Entities;
using System.Collections.Generic;

namespace Promocoes.Application.Interface
{
    public interface ICarrinhoAppService
    {
        bool CriaCarrinho();
        Dictionary<int, Carrinho> AdicionaProduto(Produto produto, int qtdProd);
        Dictionary<int, Carrinho> RetiraProduto(int idProd);
        Dictionary<int, Carrinho> DevolveConteudo();
    }
}
