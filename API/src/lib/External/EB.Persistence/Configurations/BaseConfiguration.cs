using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EB.Persistence.Configurations;

internal class BaseConfiguration<T> : IEntityTypeConfiguration<T> where T : class
{
    public void Configure(EntityTypeBuilder<T> builder)
    {
        throw new NotImplementedException();
    }
}
