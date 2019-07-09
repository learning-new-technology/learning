//using API.Models;
using API.Models;
using BusinessDomain;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccess
{
    public class ResortDbContext : DbContext
    {
        public virtual DbSet<Resort> Resort { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Data Source=192.168.1.230;Initial Catalog=Research_Angular_NetCore;User ID=sa;Password=admin@123;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
