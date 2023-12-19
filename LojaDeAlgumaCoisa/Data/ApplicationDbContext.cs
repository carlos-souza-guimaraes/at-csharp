using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaDeAlgumaCoisa.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LojaDeAlgumaCoisa.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Carro> Carro { get; set; } = default!;
        public DbSet<Modelo> Modelo { get; set; } = default!;
    }
}
