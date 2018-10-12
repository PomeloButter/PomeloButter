using System.ComponentModel.DataAnnotations;

namespace PomeloButter.Model.TableModel
{
    public class CommonObject
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [StringLength(36)]
        public string Id { get; set; }       
        public bool IsDeleted { get; set; }
    }
}