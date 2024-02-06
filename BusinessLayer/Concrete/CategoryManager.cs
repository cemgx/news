using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class CategoryManager
    {
        Repository<Category> repoCategory = new Repository<Category>();

        public List<Category> GetAll()
        {
            return repoCategory.List();
        }

        public int CategoryAddBusinessLayer(Category category)
        {
            if (category.CategoryName == "" || category.CategoryDescription == "" || category.CategoryName.Length <= 2 || category.CategoryName.Length >= 30)
            {
                return -1;
            }
            return repoCategory.Insert(category);
        }

        public Category FindCategory(int id)
        {
            return repoCategory.Find(x => x.CategoryID == id);
        }

        public int EditCategory(Category category)
        {
            Category _category = repoCategory.Find(x => x.CategoryID == category.CategoryID);

            if (category.CategoryName == "" || category.CategoryName.Length <= 2 || category.CategoryName.Length >= 30)
            {
                return -1;
            }
            _category.CategoryName = category.CategoryName;
            _category.CategoryDescription = category.CategoryDescription;
            return repoCategory.Update(_category);
        }

        public int CategoryStatusFalseBusinessLayer(int id)
        {
            Category _category = repoCategory.Find(x => x.CategoryID == id);
            _category.CategoryStatus = false;
            return repoCategory.Update(_category);
        }

        public int CategoryStatusTrueBusinessLayer(int id)
        {
            Category _category = repoCategory.Find(x => x.CategoryID == id);
            _category.CategoryStatus = true;
            return repoCategory.Update(_category);
        }
    }
}
