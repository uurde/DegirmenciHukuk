using DH.Core.DataAccess;
using DH.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DH.DataAccess.Abstracts
{
    public interface IUserDal: IEntityRepository<User>
    {
    }
}
