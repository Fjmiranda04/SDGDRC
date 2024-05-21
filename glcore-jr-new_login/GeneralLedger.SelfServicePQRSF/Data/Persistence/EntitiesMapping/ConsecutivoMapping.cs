using GeneralLedger.SelfServiceCore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeneralLedger.SelfServiceCore.Data.Persistence.EntitiesMapping
{
    public class ConsecutivoMapping : IEntityTypeConfiguration<Consecutivo>
    {
        public void Configure(EntityTypeBuilder<Consecutivo> builder)
        {
            builder.HasNoKey();
            builder.Property(a => a.consecutivo).HasMaxLength(10).HasColumnType("VARCHAR");
        }
    }
}