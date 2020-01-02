using DH.Business.Abstracts;
using DH.DataAccess.Abstracts;
using DH.Entities.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DH.Business.Business
{
    public class BlogCommentBusiness : IBlogCommentBusiness
    {
        private IBlogCommentDal _blogComment;

        public BlogCommentBusiness(IBlogCommentDal blogComment)
        {
            _blogComment = blogComment;
        }
        public BlogComment Get(int blogCommentId)
        {
            var blogComment = _blogComment.Get(x => x.BlogCommentId == blogCommentId);
            return blogComment;
        }

        public List<BlogComment> GetAll()
        {
            var blogComments = _blogComment.GetList().Where(x => x.IsDeleted == false).OrderBy(x => x.CreDate).ToList();
            return blogComments;
        }

        public void Insert(BlogComment blogComment)
        {
            _blogComment.Insert(blogComment);
        }

        public void MarkAsDeleted(int blogCommentId)
        {
            var blogComment = _blogComment.Get(x => x.BlogCommentId == blogCommentId);
            blogComment.IsDeleted = true;
            _blogComment.Update(blogComment);
        }

        public void Update(BlogComment blogComment)
        {
            _blogComment.Update(blogComment);
        }
    }
}
