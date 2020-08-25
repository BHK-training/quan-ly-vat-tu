using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quan_ly_vat_tu.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {


        }
        public DbSet<Kho> Kho { get; set; }
        public DbSet<VatTu> VatTu { get; set; }
    }
}
