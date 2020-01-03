using DH.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace DH.Entities.Entities
{
    public class BlogPost : BaseEntity, IEntity
    {
        [Key]
        public int BlogPostId { get; set; }
        public string BlogTitle { get; set; }
        public string BlogContent { get; set; }
        public string BlogDescription { get; set; }
        public int BlogCategoryId { get; set; }
        public string BlogTag { get; set; }
        public int BlogStatus { get; set; }
    }
}
