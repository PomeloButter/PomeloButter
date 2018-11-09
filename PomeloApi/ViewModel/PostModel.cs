using System;
using PomeloButter.Model.TableModel;

namespace PomeloApi.ViewModel
{
    /// <summary>
    /// 
    /// </summary>
    public class PostModel:CommonObject
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
        public DateTime UpdateTime { get; set; }
    }
}