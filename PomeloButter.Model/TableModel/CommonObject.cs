using System.ComponentModel.DataAnnotations;

namespace PomeloButter.Model.TableModel
{
    /// <summary>
    /// 
    /// </summary>
    public class CommonObject
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [StringLength(36)]
        public string Id { get; set; }    
        /// <summary>
        /// 删除标记
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}