﻿using DH.Core.DataAccess;
using DH.DataAccess.Abstracts;
using DH.Entities.Entities;

namespace DH.DataAccess.DataAccess
{
    public class BlogCommentDal : EntityRepository<BlogComment, Context>, IBlogCommentDal
    {
    }
}
