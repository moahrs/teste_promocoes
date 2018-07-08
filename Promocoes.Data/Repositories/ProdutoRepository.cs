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

        public decimal DevolveValorCalculado(int idProd, int qtdProd)
        {
            int varQtdInteiro;
            int varQtdRestante;
            decimal valorCalculado = 0;
            Produto dadosProduto;

            dadosProduto = Db.TbProduto.Where(h => h.ProdutoID == idProd).FirstOrDefault();

            if (dadosProduto.PromocaoID != 0)
            {
                switch (dadosProduto.PromocaoID)
                {
                    case 1: // Pague 1 e Leve 2
                        varQtdInteiro = qtdProd / 2;
                        varQtdRestante = qtdProd - (2 * varQtdInteiro);

                        valorCalculado = (dadosProduto.Preco * varQtdInteiro) + (dadosProduto.Preco * varQtdRestante);

                        break;
                    case 2: // 3 por 10 reais
                        varQtdInteiro = qtdProd / 3;
                        varQtdRestante = qtdProd - (3 * varQtdInteiro);

                        valorCalculado = (10 * varQtdInteiro) + (dadosProduto.Preco * varQtdRestante);

                        break;
                }
            }
            else
            {
                valorCalculado = dadosProduto.Preco * qtdProd;
            }

            return valorCalculado;
        }
    }
}
