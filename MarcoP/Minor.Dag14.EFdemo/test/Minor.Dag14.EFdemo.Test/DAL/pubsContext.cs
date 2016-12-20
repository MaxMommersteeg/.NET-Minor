using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Minor.Dag14.EFdemo.Test.DAL;

namespace Minor.Dag14.EFdemo.Test
{
    public partial class pubsContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=pubs;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Boek>(new BoekMapping().Map);
            modelBuilder.Entity<Authors>(entity =>
            {
                entity.HasKey(e => e.AuId)
                    .HasName("UPKCL_auidind");

                entity.ToTable("authors");

                entity.HasIndex(e => new { e.AuLname, e.AuFname })
                    .HasName("aunmind");

                entity.Property(e => e.AuId)
                    .HasColumnName("au_id")
                    .HasColumnType("id");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasColumnType("varchar(40)");

                entity.Property(e => e.AuFname)
                    .IsRequired()
                    .HasColumnName("au_fname")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.AuLname)
                    .IsRequired()
                    .HasColumnName("au_lname")
                    .HasColumnType("varchar(40)");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.Contract).HasColumnName("contract");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasColumnType("char(12)")
                    .HasDefaultValueSql("'UNKNOWN'");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasColumnType("char(2)");

                entity.Property(e => e.Zip)
                    .HasColumnName("zip")
                    .HasColumnType("char(5)");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK_emp_id");

                entity.ToTable("employee");

                entity.HasIndex(e => new { e.Lname, e.Fname, e.Minit })
                    .HasName("employee_ind");

                entity.Property(e => e.EmpId)
                    .HasColumnName("emp_id")
                    .HasColumnType("empid");

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasColumnName("fname")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.HireDate)
                    .HasColumnName("hire_date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.JobId)
                    .HasColumnName("job_id")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.JobLvl)
                    .HasColumnName("job_lvl")
                    .HasDefaultValueSql("10");

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasColumnName("lname")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.Minit)
                    .HasColumnName("minit")
                    .HasColumnType("char(1)");

                entity.Property(e => e.PubId)
                    .IsRequired()
                    .HasColumnName("pub_id")
                    .HasColumnType("char(4)")
                    .HasDefaultValueSql("'9952'");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.JobId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__employee__job_id__47DBAE45");

                entity.HasOne(d => d.Pub)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.PubId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__employee__pub_id__4AB81AF0");
            });

            modelBuilder.Entity<Jobs>(entity =>
            {
                entity.HasKey(e => e.JobId)
                    .HasName("PK__jobs__6E32B6A5F7ACFB61");

                entity.ToTable("jobs");

                entity.Property(e => e.JobId).HasColumnName("job_id");

                entity.Property(e => e.JobDesc)
                    .IsRequired()
                    .HasColumnName("job_desc")
                    .HasColumnType("varchar(50)")
                    .HasDefaultValueSql("'New Position - title not formalized yet'");

                entity.Property(e => e.MaxLvl).HasColumnName("max_lvl");

                entity.Property(e => e.MinLvl).HasColumnName("min_lvl");
            });

            modelBuilder.Entity<PubInfo>(entity =>
            {
                entity.HasKey(e => e.PubId)
                    .HasName("UPKCL_pubinfo");

                entity.ToTable("pub_info");

                entity.Property(e => e.PubId)
                    .HasColumnName("pub_id")
                    .HasColumnType("char(4)");

                entity.Property(e => e.Logo)
                    .HasColumnName("logo")
                    .HasColumnType("image");

                entity.Property(e => e.PrInfo)
                    .HasColumnName("pr_info")
                    .HasColumnType("text");

                entity.HasOne(d => d.Pub)
                    .WithOne(p => p.PubInfo)
                    .HasForeignKey<PubInfo>(d => d.PubId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__pub_info__pub_id__4316F928");
            });

            modelBuilder.Entity<Publishers>(entity =>
            {
                entity.HasKey(e => e.PubId)
                    .HasName("UPKCL_pubind");

                entity.ToTable("publishers");

                entity.Property(e => e.PubId)
                    .HasColumnName("pub_id")
                    .HasColumnType("char(4)");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.Country)
                    .HasColumnName("country")
                    .HasColumnType("varchar(30)")
                    .HasDefaultValueSql("'USA'");

                entity.Property(e => e.PubName)
                    .HasColumnName("pub_name")
                    .HasColumnType("varchar(40)");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasColumnType("char(2)");
            });

            modelBuilder.Entity<Sales>(entity =>
            {
                entity.HasKey(e => new { e.StorId, e.OrdNum, e.TitleId })
                    .HasName("UPKCL_sales");

                entity.ToTable("sales");

                entity.HasIndex(e => e.TitleId)
                    .HasName("titleidind");

                entity.Property(e => e.StorId)
                    .HasColumnName("stor_id")
                    .HasColumnType("char(4)");

                entity.Property(e => e.OrdNum)
                    .HasColumnName("ord_num")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.TitleId)
                    .HasColumnName("title_id")
                    .HasColumnType("tid");

                entity.Property(e => e.OrdDate)
                    .HasColumnName("ord_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Payterms)
                    .IsRequired()
                    .HasColumnName("payterms")
                    .HasColumnType("varchar(12)");

                entity.Property(e => e.Qty).HasColumnName("qty");

                entity.HasOne(d => d.Stor)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.StorId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__sales__stor_id__36B12243");

                entity.HasOne(d => d.Title)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.TitleId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__sales__title_id__37A5467C");
            });

            modelBuilder.Entity<Stores>(entity =>
            {
                entity.HasKey(e => e.StorId)
                    .HasName("UPK_storeid");

                entity.ToTable("stores");

                entity.Property(e => e.StorId)
                    .HasColumnName("stor_id")
                    .HasColumnType("char(4)");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasColumnType("char(2)");

                entity.Property(e => e.StorAddress)
                    .HasColumnName("stor_address")
                    .HasColumnType("varchar(40)");

                entity.Property(e => e.StorName)
                    .HasColumnName("stor_name")
                    .HasColumnType("varchar(40)");

                entity.Property(e => e.Zip)
                    .HasColumnName("zip")
                    .HasColumnType("char(5)");
            });

            modelBuilder.Entity<Titleauthor>(entity =>
            {
                entity.HasKey(e => new { e.AuId, e.TitleId })
                    .HasName("UPKCL_taind");

                entity.ToTable("titleauthor");

                entity.HasIndex(e => e.AuId)
                    .HasName("auidind");

                entity.HasIndex(e => e.TitleId)
                    .HasName("titleidind");

                entity.Property(e => e.AuId)
                    .HasColumnName("au_id")
                    .HasColumnType("id");

                entity.Property(e => e.TitleId)
                    .HasColumnName("title_id")
                    .HasColumnType("tid");

                entity.Property(e => e.AuOrd).HasColumnName("au_ord");

                entity.Property(e => e.Royaltyper).HasColumnName("royaltyper");

                entity.HasOne(d => d.Au)
                    .WithMany(p => p.Titleauthor)
                    .HasForeignKey(d => d.AuId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__titleauth__au_id__30F848ED");

                entity.HasOne(d => d.Title)
                    .WithMany(p => p.Titleauthor)
                    .HasForeignKey(d => d.TitleId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__titleauth__title__31EC6D26");
            });

            modelBuilder.Entity<Boek>(boek =>
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
            });
        }

        public virtual DbSet<Authors> Authors { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Jobs> Jobs { get; set; }
        public virtual DbSet<PubInfo> PubInfo { get; set; }
        public virtual DbSet<Publishers> Publishers { get; set; }
        public virtual DbSet<Sales> Sales { get; set; }
        public virtual DbSet<Stores> Stores { get; set; }
        public virtual DbSet<Titleauthor> Titleauthor { get; set; }
        public virtual DbSet<Boek> Boeken { get; set; }

        // Unable to generate entity type for table 'dbo.roysched'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.discounts'. Please see the warning messages.
    }
}