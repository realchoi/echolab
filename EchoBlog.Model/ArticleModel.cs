using System;
using System.Collections.Generic;
using System.Text;

namespace EchoBlog.Model
{
    /// <summary>
    /// 文章 Model
    /// </summary>
    public class ArticleModel
    {
        /// <summary>
        /// 文章 Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 作者 Id
        /// </summary>
        public string AuthorId { get; set; }

        /// <summary>
        /// 作者名称
        /// </summary>
        public string AuthorName { get; set; }

        /// <summary>
        /// 分类
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// 阅读量
        /// </summary>
        public int ReadTimes { get; set; }

        /// <summary>
        /// 评论数量
        /// </summary>
        public int CommentCount { get; set; }

        /// <summary>
        /// 是否作废
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 创建时间，默认当前时间
        /// </summary>
        public string CreateTime { get; set; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        /// <summary>
        /// 修改时间，默认当前时间
        /// </summary>
        public string UpdateTime { get; set; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
    }
}
