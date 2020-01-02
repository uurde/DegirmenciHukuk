using DH.Core.DataAccess;
using DH.Entities.ComplexTypes;
using DH.Entities.Entities;
using System.Collections.Generic;

namespace DH.DataAccess.Abstracts
{
    public interface IBlogPostDal : IEntityRepository<BlogPost>
    {
        List<BlogModel> GetBlogPostDetails();
        BlogModel GetBlogPost(int blogPostId);
    }
}
