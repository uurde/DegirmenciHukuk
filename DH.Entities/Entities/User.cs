using DH.Core.Entities;

namespace DH.Entities.Entities
{
    public class User: BaseEntity, IEntity
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string UserPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserPhotoPath { get; set; }
        public string Description { get; set; }
    }
}
