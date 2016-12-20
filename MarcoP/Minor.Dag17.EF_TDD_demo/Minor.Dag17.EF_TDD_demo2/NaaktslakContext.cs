using System;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

public class NaaktslakContext : DbContext
{
    public NaaktslakContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Naaktslak> Naaktslakken { get; set; }
}