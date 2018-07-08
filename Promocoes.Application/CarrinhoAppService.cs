using Promocoes.Application.Interface;
using Promocoes.Domain;
using Promocoes.Domain.Entities;
using Promocoes.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Promocoes.Application
{
    public class CarrinhoAppService : ICarrinhoAppService
    {
        private readonly ICarrinhoService _carrinhoService;

        public CarrinhoAppService(ICarrinhoService carrinhoService)
        {
            _carrinhoService = carrinhoService;
        }

        public bool CriaCarrinho()
        {
            return _carrinhoService.CriaCarrinho();
        }

        public Dictionary<int, Carrinho> AdicionaProduto(Produto produto, int qtdProd)
        {
            return _carrinhoService.AdicionaProduto(produto, qtdProd);
        }

        public Dictionary<int, Carrinho> RetiraProduto(int idProd)
        {
            return _carrinhoService.RetiraProduto(idProd);
        }

        public Dictionary<int, Carrinho> DevolveConteudo()
        {
            return _carrinhoService.DevolveConteudo();
        }
    }
}
