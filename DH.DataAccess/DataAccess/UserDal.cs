using DH.Core.DataAccess;
using DH.DataAccess.Abstracts;
using DH.Entities.Entities;

namespace DH.DataAccess.DataAccess
{
    public class UserDal: EntityRepository<User, Context>, IUserDal
    {
    }
}
