using DH.Entities.Entities;
using System.Collections.Generic;

namespace DH.Business.Abstracts
{
    public interface IUserBusiness
    {
        User Get(int userId);

        List<User> GetAll();

        void Insert(User user);

        void Update(User user);

        void MarkAsDeleted(int userId);
    }
}
