using EchoLab.Domains.CommentAggregate;
using EchoLab.Infrastructures.Core;
using EchoLab.Infrastructures.Core.Snowflake;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EchoLab.Infrastructures.EntityConfigurations
{
    /// <summary>
    /// Comment 实体类与数据库映射配置
    /// </summary>
    public class CommentEntityTypeConfiguration : BaseEntityTypeConfiguration<Comment>
    {
        public CommentEntityTypeConfiguration(SnowflakeId snowflakeId) : base(snowflakeId)
        {
        }

        public override void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("comment");
            base.Configure(builder);
        }
    }
}