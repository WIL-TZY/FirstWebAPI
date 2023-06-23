/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
*/

using FirstWebAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace FirstWebAPI.Data
{
    // Importing DbContext from Microsoft.EntityFrameworkCore
    // Then, focus on the next line and click the magnifying glass
    // Select the option: "Generate constructor UserDbContext(options)"
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }

        // Setting up first table in database
        public DbSet<User> Users { get; set; } // Getting User Entity

        protected override void OnModelCreating(ModelBuilder modelBuilder){ 

            // Creating local variable
            var user = modelBuilder.Entity<User>();
            // Calling User Entity to change the table's name
            user.ToTable("tb_usuario"); 
            // Informing that the table has an Id
            user.HasKey(x => x.Id);
            // Changing column name from "Id" to "id"
            user.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            user.Property(x => x.Name).HasColumnName("name").IsRequired();
            user.Property(x => x.BirthDate).HasColumnName("birth_date");
            /* OBS: 
                Remember to re-run the command 'dotnet ef migrations add <nameOfMigration>' 
                whenever a new change to the database is manually applied.
            */
        }
    }
}