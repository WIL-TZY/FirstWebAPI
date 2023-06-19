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
    }
}