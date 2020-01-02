using DH.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace DH.Entities.Entities
{
    public class BlogCategory : BaseEntity, IEntity
    {
        [Key]
        public int BlogCategoryId { get; set; }
        public string BlogCategoryName { get; set; }
        public string Description { get; set; }
    }
}
