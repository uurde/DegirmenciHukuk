using DH.Entities.ComplexTypes;
using DH.Entities.Entities;
using System.Collections.Generic;

namespace DH.Business.Abstracts
{
    public interface IBlogPostBusiness
    {
        BlogPost Get(int blogPostId);
        List<BlogPost> GetAll();
        void Insert(BlogPost blogPost);
        void Update(BlogPost blogPost);
        void MarkAsDeleted(int blogPostId);
        List<BlogModel> GetArticles();
        List<BlogModel> GetPublishedArticles();
        BlogModel GetArticle(int blogPostId);
    }
}
