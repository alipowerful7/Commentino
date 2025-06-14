﻿using Commention.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Commention.Infrastructure.Persistence.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.NoAction;
            }
        }


        public DbSet<User> Users { get; set; }
        public DbSet<PendUserRegister> PendUserRegisters { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
