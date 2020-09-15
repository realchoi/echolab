using EchoLab.Infrastructures.Core.CommonModels;

namespace EchoLab.Api.Dtos
{
    /// <summary>
    /// 节点数据传输类
    /// </summary>
    public class NodeDto: BaseDto<string>
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
        
        /// <summary>
        /// 分类 Id
        /// </summary>
        public string CategoryId { get; private set; }

        /// <summary>
        /// 分类名称
        /// </summary>
        public string CategoryName { get; private set; }
    }
}