using DH.Entities.Entities;
using System.Collections.Generic;

namespace DH.Business.Abstracts
{
    public interface IBlogCategoryBusiness
    {
        BlogCategory Get(int blogCategoryId);
        List<BlogCategory> GetAll();
        void Insert(BlogCategory blogCategory);
        void Update(BlogCategory blogCategory);
        void MarkAsDeleted(int blogCategoryId);
    }
}
