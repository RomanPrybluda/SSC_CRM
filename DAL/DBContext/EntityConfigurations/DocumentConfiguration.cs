﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.DBContext.EntityConfigurations
{
    internal class DocumentConfiguration : IEntityTypeConfiguration<Entity.Document>
    {
        public void Configure(EntityTypeBuilder<Entity.Document> builder)
        {
            builder.HasKey(document => document.DocumentId);

            builder.HasOne(doc => doc.Ship)
                    .WithMany(ship => ship.Documents)
                    .HasForeignKey(ship => ship.ShipId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.Property(document => document.DocumentId)
                    .HasDefaultValueSql("NEWID()");

            builder.Property(document => document.DocumenNumber)
                    .IsRequired();

            builder.Property(document => document.DocumenName)
                    .IsRequired();

            builder.Property(document => document.ShipName)
                    .IsRequired();

            builder.Property(document => document.ShipImoNumber)
                    .IsRequired();
        }
    }
}
