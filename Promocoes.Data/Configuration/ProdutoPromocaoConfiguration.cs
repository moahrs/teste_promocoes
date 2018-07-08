using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Promocoes.Domain.Configuration
{
    public class ProdutoPromocaoConfiguration : EntityTypeConfiguration<ProdutoPromocao>
    {
        public ProdutoPromocaoConfiguration()
        {
            HasKey(x => x.PromocaoID);
            Property(x => x.PromocaoID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Codigo)
                .IsRequired();
            Property(x => x.ProdutoID)
                .IsRequired();
            Property(x => x.Descricao)
                .IsVariableLength()
                .IsRequired()
                .HasMaxLength(120);
            Property(x => x.Preco)
                .IsRequired();
        }
    }
}
