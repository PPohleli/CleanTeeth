using CleanTeeth.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Persistence
{
    public class CleanTeethDbContext : DbContext
    {
        public CleanTeethDbContext(DbContextOptions<CleanTeethDbContext> options) : base(options)
        {
            
        }
        protected CleanTeethDbContext()
        {
            
        }

        DbSet<DentalOffice> DentalOffices { get; set; }
    }
}
