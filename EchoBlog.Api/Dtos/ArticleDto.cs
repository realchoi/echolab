using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EchoBlog.Api.Dtos
{
    /// <summary>
    /// 文章传输对象
    /// </summary>
    public class ArticleDto
    {
        public int Id { get; set; }

        public string AuthorId { get; set; }

        public string AuthorName { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int ReadTimes { get; set; }

        public string CreateTime { get; set; }

        public string LastTime { get; set; }
    }
}
