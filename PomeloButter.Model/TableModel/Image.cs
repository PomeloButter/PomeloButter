﻿namespace PomeloButter.Model.TableModel
{
    /// <summary>
    /// 
    /// </summary>
    public class Image:CommonObject
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 用户
        /// </summary>
        public User User { get; set; }
    }
}