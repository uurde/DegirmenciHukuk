using DH.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace DH.Entities.Entities
{
    public class BlogComment : BaseEntity, IEntity
    {
        [Key]
        public int BlogCommentId { get; set; }
        public string BlogCommentContent { get; set; }
        public string ComentorFullName { get; set; }
        public string CommentoreEmail { get; set; }
        public int BlogPostId { get; set; }
    }
}
