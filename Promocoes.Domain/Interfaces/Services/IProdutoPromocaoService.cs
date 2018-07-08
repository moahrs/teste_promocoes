using System.Collections.Generic;

namespace Promocoes.Domain.Interfaces.Services
{
    public interface IProdutoPromocaoService : IServiceBase<ProdutoPromocao>
    {
        IEnumerable<ProdutoPromocao> BuscarPorDesc(string descPromo);
        IEnumerable<ProdutoPromocao> BuscarPorProd(int idProd);
        ProdutoPromocao BuscarPorProdAtivo(int idProd);
        void LimpaAtivosPorProd(int idProd);
        void SetarAtivoPorPromo(int idPromo);
        void RemovePorProd(int idProd);
    }
}
