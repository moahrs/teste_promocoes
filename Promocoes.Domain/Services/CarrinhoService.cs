using Promocoes.Domain.Entities;
using Promocoes.Domain.Interfaces.Repositories;
using Promocoes.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Promocoes.Domain.Services
{
    public class CarrinhoService : ICarrinhoService
    {
        private ICarrinhoRepository _carrinhoRepository;

        public CarrinhoService(ICarrinhoRepository carrinhoRepository)
        {
            _carrinhoRepository = carrinhoRepository;
        }

        public bool CriaCarrinho()
        {
            return _carrinhoRepository.CriaCarrinho();
        }

        public Dictionary<int, Carrinho> AdicionaProduto(Produto produto, int qtdProd)
        {
            return _carrinhoRepository.AdicionaProduto(produto, qtdProd);
        }

        public Dictionary<int, Carrinho> RetiraProduto(int idProd)
        {
            return _carrinhoRepository.RetiraProduto(idProd);
        }

        public Dictionary<int, Carrinho> DevolveConteudo()
        {
            return _carrinhoRepository.DevolveConteudo();
        }
    }
}
