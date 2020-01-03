using DH.Business.Abstracts;
using DH.Core.Encryption;
using DH.DataAccess.Abstracts;
using DH.Entities.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DH.Business.Business
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IUserDal _userDal;
        private readonly IEncryption _encryption;

        public UserBusiness(IUserDal userDal, IEncryption encryption)
        {
            _userDal = userDal;
            _encryption = encryption;
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
            user.UserPassword = _encryption.Decrypt(user.UserPassword);
            return user;
        }

        public List<User> GetAll()
        {
            var user = _userDal.GetList().Where(x => x.IsDeleted == false).ToList();
            return user;
        }

        public void Insert(User user)
        {
            user.UserPassword = _encryption.Encrypt(user.UserPassword);
            _userDal.Insert(user);
        }

        public void Update(User user)
        {
            user.UserPassword = _encryption.Encrypt(user.UserPassword);
            _userDal.Update(user);
        }

        public bool Login(string username, string password)
        {
            string encryptedPassword = _encryption.Encrypt(password);
            User loginUser = _userDal.Get(x => x.Username == username && x.UserPassword == encryptedPassword);

            if (loginUser != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public User GetByName(string username)
        {
            var user = _userDal.Get(x => x.Username == username);
            return user;
        }
    }
}
