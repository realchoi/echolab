using EchoLab.Domains.NodeAggregate;
using EchoLab.Infrastructures.Core;
using EchoLab.Infrastructures.Core.Snowflake;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EchoLab.Infrastructures.EntityConfigurations
{
    /// <summary>
    /// Node 实体类与数据库映射配置
    /// </summary>
    public class NodeEntityTypeConfiguration : BaseEntityTypeConfiguration<Node>
    {
        public NodeEntityTypeConfiguration(SnowflakeId snowflakeId) : base(snowflakeId)
        {
        }

        public override void Configure(EntityTypeBuilder<Node> builder)
        {
            builder.ToTable("node");
            base.Configure(builder);
        }
    }
}