using DH.Business.Abstracts;
using DH.DataAccess.Abstracts;
using DH.Entities.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DH.Business.Business
{
    public class BlogTagBusiness : IBlogTagBusiness
    {
        private IBlogTagDal _blogTag;

        public BlogTagBusiness(IBlogTagDal blogTag)
        {
            _blogTag = blogTag;
        }

        public BlogTag Get(int blogTagId)
        {
            var blogTag = _blogTag.Get(x => x.BlogTagId == blogTagId);
            return blogTag;
        }

        public List<BlogTag> GetAll()
        {
            var blogTags = _blogTag.GetList().Where(x => x.IsDeleted == false).OrderBy(x => x.CreDate).ToList();
            return blogTags;
        }

        public void Insert(BlogTag blogTag)
        {
            _blogTag.Insert(blogTag);
        }

        public void MarkAsDeleted(int blogTagId)
        {
            var blogTag = _blogTag.Get(x => x.BlogTagId == blogTagId);
            blogTag.IsDeleted = true;
            _blogTag.Update(blogTag);
        }

        public void Update(BlogTag blogTag)
        {
            _blogTag.Update(blogTag);
        }
    }
}
