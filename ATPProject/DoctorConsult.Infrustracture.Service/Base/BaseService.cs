using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DoctorConsult.Core.Entity.Model.Base;
using DoctorConsult.Core.Service.Interfaces.Base;
using DoctorConsult.Data.DoctorConsultContext;

namespace DoctorConsult.Infrustracture.Service.Base
{
    public class BaseService<T> :  IBaseService<T> where T : BaseModel
    {
        private readonly DoctorDbContext _dbContext;
        private DbSet<T> _innerDbSet;
        public BaseService()
        {
            _dbContext = new DoctorDbContext();
            _innerDbSet = _dbContext.Set<T>();
        }


        public IQueryable<T> All()
        {
            return _innerDbSet.Where(x => !x.IsDelete);
        }

        public T Find(long id)
        {
            return All().FirstOrDefault(x => x.Id == id);
        }

        public void Insert(T model)
        {
            model.CreatedDate = DateTime.UtcNow;
            model.UpdatedDate= DateTime.UtcNow;
            _dbContext.Entry(model).State = EntityState.Added;
            _innerDbSet.Add(model);
            Save();
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.Configuration.ValidateOnSaveEnabled = false;
            Save();
            _dbContext.Configuration.ValidateOnSaveEnabled = true;
        }

        public void Delete(int id)
        {
            var entity = Find(id);
            _innerDbSet.Remove(entity);
            Save();
        }

        private void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
