using DH.Entities.Entities;
using System.Collections.Generic;

namespace DH.Business.Abstracts
{
    public interface IBlogCommentBusiness
    {
        BlogComment Get(int blogCommentId);
        List<BlogComment> GetAll();
        void Insert(BlogComment blogComment);
        void Update(BlogComment blogComment);
        void MarkAsDeleted(int blogCommentId);
    }
}
