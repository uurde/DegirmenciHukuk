using DH.Business.Abstracts;
using DH.DataAccess.Abstracts;
using DH.Entities.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DH.Business.Business
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IUserDal _userDal;

        public UserBusiness(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void MarkAsDeleted(int userId)
        {
            var user = _userDal.Get(x => x.UserId == userId);
            user.IsDeleted = true;
            _userDal.Update(user);
        }

        public User Get(int userId)
        {
            var user = _userDal.Get(x => x.UserId == userId);
            return user;
        }

        public List<User> GetAll()
        {
            var user = _userDal.GetList().Where(x => x.IsDeleted == false).ToList();
            return user;
        }

        public void Insert(User user)
        {
            _userDal.Insert(user);
        }

        public void Update(User user)
        {
            _userDal.Update(user);
        }
    }
}
