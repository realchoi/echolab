using EchoBlog.Domains.ArticleAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EchoBlog.Infrastructures.EntityConfigurations
{
    /// <summary>
    /// Article 实体类与数据库映射配置
    /// </summary>
    public class ArticleEntityTypeConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(p => p.Id);
            builder.ToTable("article");
            builder.Property(p => p.AuthorId).HasMaxLength(20).HasComment("作者 Id");
            builder.Property(p => p.AuthorName).HasMaxLength(20).HasComment("作者名称");
            builder.Property(p => p.Title).HasMaxLength(50).HasComment("标题");
        }
    }
}
