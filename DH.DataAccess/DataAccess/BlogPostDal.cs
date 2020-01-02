using DH.Core.DataAccess;
using DH.DataAccess.Abstracts;
using DH.Entities.ComplexTypes;
using DH.Entities.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DH.DataAccess.DataAccess
{
    public class BlogPostDal : EntityRepository<BlogPost, Context>, IBlogPostDal
    {
        public BlogModel GetBlogPost(int blogPostId)
        {
            using (Context context = new Context())
            {
                var blogPost = from p in context.BlogPost
                               join c in context.BlogCategory
                               on p.BlogCategoryId equals c.BlogCategoryId
                               where p.BlogPostId == blogPostId
                               select new BlogModel
                               {
                                   BlogPostId = p.BlogPostId,
                                   BlogTitle = p.BlogTitle,
                                   BlogContent = p.BlogContent,
                                   BlogDescription = p.BlogDescription,
                                   BlogTag = p.BlogTag,
                                   BlogCategoryId = p.BlogCategoryId,
                                   CreDate = p.CreDate,
                                   CreUser = p.CreUser,
                                   ModDate = p.ModDate,
                                   ModUser = p.ModUser,
                                   IsDeleted = p.IsDeleted,
                                   BlogCategoryName = c.BlogCategoryName
                               };

                return blogPost.FirstOrDefault();
            }
        }

        public List<BlogModel> GetBlogPostDetails()
        {
            using (Context context = new Context())
            {
                var blogPost = from p in context.BlogPost
                               join c in context.BlogCategory
                               on p.BlogCategoryId equals c.BlogCategoryId
                               select new BlogModel
                               {
                                   BlogPostId = p.BlogPostId,
                                   BlogTitle = p.BlogTitle,
                                   BlogContent = p.BlogContent,
                                   BlogDescription = p.BlogDescription,
                                   BlogTag = p.BlogTag,
                                   BlogCategoryId = p.BlogCategoryId,
                                   CreDate = p.CreDate,
                                   CreUser = p.CreUser,
                                   ModDate = p.ModDate,
                                   ModUser = p.ModUser,
                                   IsDeleted = p.IsDeleted,
                                   BlogCategoryName = c.BlogCategoryName
                               };

                return blogPost.ToList();
            }
        }
    }
}
