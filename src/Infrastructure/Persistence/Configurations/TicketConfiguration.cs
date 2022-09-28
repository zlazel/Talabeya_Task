using Talabeya_Task.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Talabeya_Task.Infrastructure.Persistence.Configurations;

public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.Property(t => t.Phone)
            .HasMaxLength(15)
            .IsRequired();

        builder.Property(x=>x.Goverenorate).IsRequired();
        builder.Property(x=>x.City).IsRequired();
        builder.Property(x=>x.District).IsRequired();
    }
}
