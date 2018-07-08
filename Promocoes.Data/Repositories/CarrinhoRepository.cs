using Promocoes.Domain;
using Promocoes.Domain.Entities;
using Promocoes.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;

namespace Promocoes.Data.Repositories
{
    public class CarrinhoRepository : ICarrinhoRepository
    {
        public static Dictionary<int, Carrinho> DictCarrinho;

        public bool CriaCarrinho()
        {
            try
            {
                DictCarrinho = new Dictionary<int, Carrinho>();
                return true;
            }
            catch (InvalidCastException e)
            {
                return false;
            }
        }

        public Dictionary<int, Carrinho> AdicionaProduto(Produto produto, int qtdProd)
        {
            Carrinho meuCarAtu = new Carrinho();
            ProdutoRepository produtoRep = new ProdutoRepository();

            if (!DictCarrinho.ContainsKey(produto.ProdutoID))
            {
                meuCarAtu.prodID = produto.ProdutoID;
                meuCarAtu.codProd = produto.Codigo;
                meuCarAtu.descProd = produto.Descricao;
                meuCarAtu.qtdProd = qtdProd;
                meuCarAtu.precoProd = produtoRep.DevolveValorCalculado(produto.ProdutoID, qtdProd);

                DictCarrinho.Add(produto.ProdutoID, meuCarAtu);
            }
            else
            {
                DictCarrinho[produto.ProdutoID].qtdProd = qtdProd;
                DictCarrinho[produto.ProdutoID].precoProd = produtoRep.DevolveValorCalculado(produto.ProdutoID, qtdProd);
            }

            return DictCarrinho;
        }

        public Dictionary<int, Carrinho> RetiraProduto(int idProd)
        {
            if (DictCarrinho.ContainsKey(idProd))
            {
                DictCarrinho.Remove(idProd);
            }

            return DictCarrinho;
        }

        public Dictionary<int, Carrinho> DevolveConteudo()
        {
            return DictCarrinho;
        }
    }
}
