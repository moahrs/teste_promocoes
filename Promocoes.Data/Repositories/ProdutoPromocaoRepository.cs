using Promocoes.Domain;
using Promocoes.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Promocoes.Data.Repositories
{
    public class ProdutoPromocaoRepository : RepositoryBase<ProdutoPromocao>, IProdutoPromocaoRepository
    {
        public IEnumerable<ProdutoPromocao> BuscarPorDesc(string descPromo)
        {
            return Db.TbProdutoPromocao
                .Where(h => h.Descricao.Contains(descPromo)).ToList();
        }

        public IEnumerable<ProdutoPromocao> BuscarPorProd(int idProd)
        {
            return Db.TbProdutoPromocao
                .Where(h => (h.ProdutoID == idProd)).ToList();
        }

        public void LimpaAtivosPorProd(int idProd)
        {
            var result = Db.TbProdutoPromocao
                .Where(h => (h.ProdutoID == idProd && h.Ativo == true));

            foreach (var rec in result)
            {
                rec.Ativo = false;
            }
            Db.SaveChanges();
        }

        public void SetarAtivoPorPromo(int idPromo)
        {
            var rec = Db.TbProdutoPromocao.FirstOrDefault(x => x.PromocaoID == idPromo);

            if (rec != null)
            {
                rec.Ativo = true;
                Db.SaveChanges();
            }
        }

        public ProdutoPromocao BuscarPorProdAtivo(int idProd)
        {
            return Db.TbProdutoPromocao
                .Where(h => (h.ProdutoID == idProd && h.Ativo == true)).FirstOrDefault();
        }

        public void RemovePorProd(int idProd)
        {
            Db.TbProdutoPromocao.RemoveRange(Db.TbProdutoPromocao.Where(h => h.PromocaoID == idProd));
            Db.SaveChanges();
        }
    }
}
