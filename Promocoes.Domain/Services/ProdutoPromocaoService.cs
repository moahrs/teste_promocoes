using System.Collections.Generic;
using Promocoes.Domain.Interfaces.Repositories;
using Promocoes.Domain.Interfaces.Services;

namespace Promocoes.Domain.Services
{
    public class ProdutoPromocaoService : ServiceBase<ProdutoPromocao>, IProdutoPromocaoService
    {
        private IProdutoPromocaoRepository _produtoPromocaoRepository;

        public ProdutoPromocaoService(IProdutoPromocaoRepository produtoPromocaoRepository)
            : base(produtoPromocaoRepository)
        {
            _produtoPromocaoRepository = produtoPromocaoRepository;
        }

        public IEnumerable<ProdutoPromocao> BuscarPorDesc(string descPromo)
        {
            return _produtoPromocaoRepository.BuscarPorDesc(descPromo);
        }

        public IEnumerable<ProdutoPromocao> BuscarPorProd(int idProd)
        {
            return _produtoPromocaoRepository.BuscarPorProd(idProd);
        }

        public ProdutoPromocao BuscarPorProdAtivo(int idProd)
        {
            return _produtoPromocaoRepository.BuscarPorProdAtivo(idProd);
        }

        public void LimpaAtivosPorProd(int idProd)
        {
            _produtoPromocaoRepository.LimpaAtivosPorProd(idProd);
        }

        public void SetarAtivoPorPromo(int idPromo)
        {
            _produtoPromocaoRepository.SetarAtivoPorPromo(idPromo);
        }

        public void RemovePorProd(int idProd)
        {
            _produtoPromocaoRepository.RemovePorProd(idProd);
        }
    }
}
