using EchoBlog.Domains.ArticleAggregate;
using EchoBlog.Infrastructures.Core;
using EchoBlog.Infrastructures.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EchoBlog.Infrastructures
{
    public class DomainContext : EFContext
    {
        public DomainContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleEntityTypeConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
