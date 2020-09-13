using EchoLab.Infrastructures.Core.Snowflake;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using System.Collections.Generic;
using System.Text;

namespace EchoLab.Infrastructures.Core.ValueGenerators
{
    /// <summary>
    /// 自动生成 long 类型 Id
    /// </summary>
    public class IdGenerator : ValueGenerator<long>
    {
        public IdGenerator(SnowflakeId snowflakeId) => this._snowflakeId = snowflakeId;

        private readonly SnowflakeId _snowflakeId;

        public override bool GeneratesTemporaryValues => false;

        public override long Next(EntityEntry entry)
        {
            return _snowflakeId.NextId();
        }
    }
}
