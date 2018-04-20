using System.Collections.Generic;
using DoctorConsult.Core.Entity.Model.Base;

namespace DoctorConsult.Core.Service.Interfaces.Base
{
    public interface IBaseService<T> where T : BaseModel
    {
        IEnumerable<T> All();
        T Find(long id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
