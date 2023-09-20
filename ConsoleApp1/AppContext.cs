using EF.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF{
    public class AppContext : DbContext{
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public AppContext(){

            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder){

            builder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=EF;Trusted_Connection=True;Trust Server Certificate=True;");
        }
    }
}
