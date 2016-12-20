using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Minor.Dag14.EFdemo.Test.DAL
{
    internal class BoekMapping
    {
        internal void Map(EntityTypeBuilder<Boek> boek)
        {
            boek.HasKey(e => e.TitleId)
                .HasName("UPKCL_titleidind");

            boek.ToTable("titles");

            boek.HasIndex(e => e.Title)
                .HasName("titleind");

            boek.Property(e => e.TitleId)
                .HasColumnName("title_id")
                .HasColumnType("tid");

            boek.Property(e => e.Advance)
                .HasColumnName("advance")
                .HasColumnType("money");

            boek.Property(e => e.Notes)
                .HasColumnName("notes")
                .HasColumnType("varchar(200)");

            boek.Property(e => e.Price)
                .HasColumnName("price")
                .HasColumnType("money");

            boek.Property(e => e.PubId)
                .HasColumnName("pub_id")
                .HasColumnType("char(4)");

            boek.Property(e => e.Pubdate)
                .HasColumnName("pubdate")
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()");

            boek.Property(e => e.Royalty).HasColumnName("royalty");

            boek.Property(e => e.Title)
                .IsRequired()
                .HasColumnName("title")
                .HasColumnType("varchar(80)");

            boek.Property(e => e.Type)
                .IsRequired()
                .HasColumnName("type")
                .HasColumnType("char(12)")
                .HasDefaultValueSql("'UNDECIDED'");

            boek.Property(e => e.YtdSales).HasColumnName("ytd_sales");

            boek.HasOne(d => d.Pub)
                .WithMany(p => p.Titles)
                .HasForeignKey(d => d.PubId)
                .HasConstraintName("FK__titles__pub_id__2D27B809");
        }
    }
}