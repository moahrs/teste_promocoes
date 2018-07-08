using Promocoes.Domain;
using Promocoes.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Promocoes.Data.Repositories
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        public IEnumerable<Produto> BuscarPorDesc(string descProd)
        {
            return Db.TbProduto
                .Where(h => h.Descricao.Contains(descProd)).ToList();
        }
    }
}
