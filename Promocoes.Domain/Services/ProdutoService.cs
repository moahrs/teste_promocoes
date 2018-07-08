using System.Collections.Generic;
using Promocoes.Domain.Interfaces.Repositories;
using Promocoes.Domain.Interfaces.Services;

namespace Promocoes.Domain.Services
{
    public class ProdutoService : ServiceBase<Produto>, IProdutoService
    {
        private IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository) 
            : base(produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public IEnumerable<Produto> BuscarPorDesc(string descProd)
        {
            return _produtoRepository.BuscarPorDesc(descProd);
        }

        public decimal DevolveValorCalculado(int idProd, int qtdProd)
        {
            return _produtoRepository.DevolveValorCalculado(idProd, qtdProd);
        }
    }
}
