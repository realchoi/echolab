using EchoLab.Domain.Abstractions;

namespace EchoLab.Domains.CommentAggregate
{
    /// <summary>
    /// 评论实体类，该实体类为聚合根
    /// </summary>
    public class Comment : Entity<long>, IAggregateRoot
    {
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; private set; }

        /// <summary>
        /// 作者 ID
        /// </summary>
        public long AuthorId { get; private set; }

        /// <summary>
        /// 作者名称
        /// </summary>
        public string AuthorName { get; private set; }

        /// <summary>
        /// 话题 ID
        /// </summary>
        public long TopicId { get; private set; }

        /// <summary>
        /// 话题标题
        /// </summary>
        public string TopicTitle { get; private set; }
    }
}