using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        Repository<Category> repoCategory = new Repository<Category>();

        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public List<Category> GetAll()
        {
            return _categoryDal.List();
        }

        public void CategoryStatusFalseBusinessLayer(int id)
        {
            Category _category = repoCategory.Find(x => x.CategoryID == id);
            _category.CategoryStatus = false;
            repoCategory.Update(_category);
        }

        public void CategoryStatusTrueBusinessLayer(int id)
        {
            Category _category = repoCategory.Find(x => x.CategoryID == id);
            _category.CategoryStatus = true;
            repoCategory.Update(_category);
        }

        public List<Category> GetList()
        {
            return _categoryDal.List();
        }

        public void Add(Category p)
        {
            _categoryDal.Insert(p);
        }

        public void Delete(Category p)
        {
            _categoryDal.Delete(p);
        }

        public void Update(Category p)
        {
            _categoryDal.Update(p);
        }

        public Category GetByID(int id)
        {
            return _categoryDal.GetById(id);
        }
    }
}
