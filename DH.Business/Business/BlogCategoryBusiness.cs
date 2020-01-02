using DH.Business.Abstracts;
using DH.DataAccess.Abstracts;
using DH.Entities.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DH.Business.Business
{
    public class BlogCategoryBusiness : IBlogCategoryBusiness
    {
        private IBlogCategoryDal _blogCategoryDal;

        public BlogCategoryBusiness(IBlogCategoryDal blogCategoryDal)
        {
            _blogCategoryDal = blogCategoryDal;
        }

        public BlogCategory Get(int blogCategoryId)
        {
            var blogCategory = _blogCategoryDal.Get(x => x.BlogCategoryId == blogCategoryId);
            return blogCategory;
        }

        public List<BlogCategory> GetAll()
        {
            var blogCategories = _blogCategoryDal.GetList().Where(x => x.IsDeleted == false).ToList();
            return blogCategories;
        }

        public void Insert(BlogCategory blogCategory)
        {
            _blogCategoryDal.Insert(blogCategory);
        }

        public void MarkAsDeleted(int blogCategoryId)
        {
            var blogCategory = _blogCategoryDal.Get(x => x.BlogCategoryId == blogCategoryId);
            blogCategory.IsDeleted = true;
            _blogCategoryDal.Update(blogCategory);
        }

        public void Update(BlogCategory blogCategory)
        {
            _blogCategoryDal.Update(blogCategory);
        }
    }
}
