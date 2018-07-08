using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Promocoes.Domain.Configuration
{
    public class ProdutoConfiguration : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfiguration()
        {
            HasKey(x => x.ProdutoID);
            Property(x => x.ProdutoID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Codigo)
                .IsVariableLength()
                .IsRequired()
                .HasMaxLength(20);
            Property(x => x.Descricao)
                .IsVariableLength()
                .IsRequired()
                .HasMaxLength(100);
            Property(x => x.Preco)
                .IsRequired();
        }
    }
}
