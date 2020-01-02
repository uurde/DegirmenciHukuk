using DH.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace DH.Entities.Entities
{
    public class BlogTag : BaseEntity, IEntity
    {
        [Key]
        public int BlogTagId { get; set; }
        public string BlogTagName { get; set; }
    }
}
