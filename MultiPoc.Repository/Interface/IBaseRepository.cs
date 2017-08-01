using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiPoc.Repository.Interface
{
    public interface IBaseRepository<T> where T: class
    {
        void add(T entity);
        void Update(T entity);
        void Delete(T entity);
        List<T> List();
    }
}
