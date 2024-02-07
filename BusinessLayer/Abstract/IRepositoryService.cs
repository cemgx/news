using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IRepositoryService<T>
    {
        List<T> GetList();

        void Add(T p);

        void Delete(T p);

        void Update(T p);

        T GetByID(int id);
    }
}
