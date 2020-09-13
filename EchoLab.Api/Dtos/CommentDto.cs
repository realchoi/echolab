using EchoLab.Infrastructures.Core.CommonModels;

namespace EchoLab.Api.Dtos
{
    /// <summary>
    /// 评论数据传输类
    /// </summary>
    public class CommentDto: BaseDto<string>
    {
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; private set; }
        
        /// <summary>
        /// 作者 ID
        /// </summary>
        public string AuthorId { get; private set; }
        
        /// <summary>
        /// 作者名称
        /// </summary>
        public string AuthorName { get; private set; }
        
        /// <summary>
        /// 话题 ID
        /// </summary>
        public string TopicId { get; private set; }
        
        /// <summary>
        /// 话题标题
        /// </summary>
        public string TopicTitle { get; private set; }
    }
}