using System.Collections.Generic;
using System.Linq;
using DoctorConsult.Core.Entity.Model.Base;

namespace DoctorConsult.Core.Service.Interfaces.Base
{
    public interface IBaseService<T> where T : BaseModel
    {
        IQueryable<T> All();
        T Find(long id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
