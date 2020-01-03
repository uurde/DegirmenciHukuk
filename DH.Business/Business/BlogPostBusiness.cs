using DH.Business.Abstracts;
using DH.DataAccess.Abstracts;
using DH.Entities.ComplexTypes;
using DH.Entities.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DH.Business.Business
{
    public class BlogPostBusiness : IBlogPostBusiness
    {
        private IBlogPostDal _blogPostDal;

        public BlogPostBusiness(IBlogPostDal blogPostDal)
        {
            _blogPostDal = blogPostDal;
        }

        public BlogPost Get(int blogPostId)
        {
            var blogPost = _blogPostDal.Get(x => x.BlogPostId == blogPostId);
            return blogPost;
        }

        public List<BlogPost> GetAll()
        {
            var blogPost = _blogPostDal.GetList().Where(x => x.IsDeleted == false).OrderBy(x => x.CreDate).ToList();
            return blogPost;
        }

        public BlogModel GetArticle(int blogPostId)
        {
            var blogPost = _blogPostDal.GetBlogPost(blogPostId);
            return blogPost;
        }

        public List<BlogModel> GetArticles()
        {
            var blogPostDetails = _blogPostDal.GetBlogPostDetails().Where(x => x.IsDeleted == false).OrderBy(x => x.CreDate).ToList();
            return blogPostDetails;
        }

        public List<BlogModel> GetPublishedArticles()
        {
            var blogPostDetails = _blogPostDal.GetBlogPostDetails().Where(x => x.IsDeleted == false && x.BlogStatus == 1).OrderBy(x => x.CreDate).ToList();
            return blogPostDetails;
        }

        public void Insert(BlogPost blogPost)
        {
            _blogPostDal.Insert(blogPost);
        }

        public void MarkAsDeleted(int blogPostId)
        {
            var blogPost = _blogPostDal.Get(x => x.BlogPostId == blogPostId);
            blogPost.IsDeleted = true;
            _blogPostDal.Update(blogPost);
        }

        public void Update(BlogPost blogPost)
        {
            _blogPostDal.Update(blogPost);
        }
    }
}
