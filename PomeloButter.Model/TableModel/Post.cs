using System;

namespace PomeloButter.Model.TableModel
{
    /// <summary>
    /// 文章
    /// </summary>
    public class Post:CommonObject
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime LastModified { get; set; }
    }
}