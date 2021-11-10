using BlazorProject.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorProject.Server.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Blog> Blogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                    .HasIndex(u => new { u.Email }).IsUnique();

            modelBuilder.Entity<Blog>()
                        .HasOne<User>()
                        .WithMany()
                        .HasForeignKey(u => u.UserId);
                        
             
            /*modelBuilder.Entity<User>().HasData(new User
            {
                UserId = 1,
                FirstName = "",
                LastName = "",
                Email = "",
                Password = "",
                Role = Role.User

            });*/
        }
    }
}
