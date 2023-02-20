using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiCQRS.Models;

namespace WebApiCQRS.Data.EntitiesConfigration
{
    //https://www.learnentityframeworkcore.com/configuration/fluent-api
    //https://stackoverflow.com/questions/63072918/how-does-ef-core-databasegeneratedoption-computed-work-on-guid-property
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(e => e.UUID)
            .HasDefaultValueSql("(newid())");
        }
    }
}
