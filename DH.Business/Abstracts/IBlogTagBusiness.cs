using DH.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DH.Business.Abstracts
{
    public interface IBlogTagBusiness
    {
        BlogTag Get(int blogTagId);
        List<BlogTag> GetAll();
        void Insert(BlogTag blogTag);
        void Update(BlogTag blogTag);
        void MarkAsDeleted(int blogTagId);
    }
}
