using Hackathon.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hackathon.Data.Configurations
{
    public class PessoaConfiguration : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> entity)
        {

            entity.HasOne(x => x.Endereco).WithOne().HasForeignKey<Pessoa>(x => x.EnderecoId);
            
        }
    }
}