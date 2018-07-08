using System.Collections.Generic;
using Promocoes.Application.Interface;
using Promocoes.Domain;
using Promocoes.Domain.Interfaces.Services;

namespace Promocoes.Application
{
    public class ProdutoPromocaoAppService : AppServiceBase<ProdutoPromocao>, IProdutoPromocaoAppService
    {
        private readonly IProdutoPromocaoService _produtoPromocaoService;

        public ProdutoPromocaoAppService(IProdutoPromocaoService produtoPromocaoService)
            : base(produtoPromocaoService)
        {
            _produtoPromocaoService = produtoPromocaoService;
        }

        public IEnumerable<ProdutoPromocao> BuscarPorDesc(string descPromo)
        {
            return _produtoPromocaoService.BuscarPorDesc(descPromo);
        }

        public IEnumerable<ProdutoPromocao> BuscarPorProd(int idProd)
        {
            return _produtoPromocaoService.BuscarPorProd(idProd);
        }

        public ProdutoPromocao BuscarPorProdAtivo(int idProd)
        {
            return _produtoPromocaoService.BuscarPorProdAtivo(idProd);
        }

        public void LimpaAtivosPorProd(int idProd)
        {
            _produtoPromocaoService.LimpaAtivosPorProd(idProd);
        }

        public void SetarAtivoPorPromo(int idPromo)
        {
            _produtoPromocaoService.SetarAtivoPorPromo(idPromo);
        }

        public void RemovePorProd(int idProd)
        {
            _produtoPromocaoService.RemovePorProd(idProd);
        }
    }
}