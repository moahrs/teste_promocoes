using System.Collections.Generic;
using Promocoes.Application.Interface;
using Promocoes.Domain;
using Promocoes.Domain.Interfaces.Services;

namespace Promocoes.Application
{
    public class ProdutoAppService : AppServiceBase<Produto>, IProdutoAppService
    {
        private readonly IProdutoService _produtoService;

        public ProdutoAppService(IProdutoService produtoService)
            : base(produtoService)
        {
            _produtoService = produtoService;
        }

        public IEnumerable<Produto> BuscarPorDesc(string descProd)
        {
            return _produtoService.BuscarPorDesc(descProd);
        }

        public decimal DevolveValorCalculado(int idProd, int qtdProd)
        {
            return _produtoService.DevolveValorCalculado(idProd, qtdProd);
        }
    }
}