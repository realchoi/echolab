using EchoLab.Infrastructures.Core.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EchoLab.Api.Dtos
{
    /// <summary>
    /// 话题数据传输类
    /// </summary>
    public class TopicDto : BaseDto<string>
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; private set; }

        /// <summary>
        /// 作者 Id
        /// </summary>
        public long AuthorId { get; private set; }

        /// <summary>
        /// 作者名称
        /// </summary>
        public string AuthorName { get; private set; }

        /// <summary>
        /// 分类 Id
        /// </summary>
        public long CategoryId { get; private set; }

        /// <summary>
        /// 分类名称
        /// </summary>
        public string CategoryName { get; private set; }

        /// <summary>
        /// 节点 Id
        /// </summary>
        public long NodeId { get; private set; }

        /// <summary>
        /// 节点名称
        /// </summary>
        public string NodeName { get; private set; }

        /// <summary>
        /// 阅读次数
        /// </summary>
        public int ReadTimes { get; private set; }

        /// <summary>
        /// 评论总数量
        /// </summary>
        public int CommentNumber { get; set; }

        /// <summary>
        /// 话题作者
        /// </summary>
        public UserProfileDto Author { get; set; }

        /// <summary>
        /// 话题作者
        /// </summary>
        public NodeDto Node { get; set; }
    }
}