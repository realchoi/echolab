using EchoBlog.Infrastructures.Core.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EchoBlog.Api.Dtos
{
    /// <summary>
    /// 话题分类数据传输类
    /// </summary>
    public class CategoryDto : BaseDto<long>
    {
        /// <summary>
        /// 代码
        /// </summary>
        public string Code { get; private set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; private set; }
    }
}
