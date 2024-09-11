﻿using Microsoft.EntityFrameworkCore;
using PernixMVC.Models;

namespace PernixMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories  { get; set; }
    }
}
