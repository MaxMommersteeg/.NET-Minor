using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Minor.Dag17.FirstASPdemo.Entities;
using Microsoft.EntityFrameworkCore;

namespace Minor.Dag17.FirstASPdemo.Mappings
{
    public class SlakMapping
    {
        internal static void Map(EntityTypeBuilder<Slak> builder)
        {
            builder.ToTable("Naaktslakken");
        }
    }
}
