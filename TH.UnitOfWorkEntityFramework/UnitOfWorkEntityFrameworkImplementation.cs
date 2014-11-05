using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TH.Interfaces;

namespace TH.UnitOfWorkEntityFramework
{
    public class UnitOfWorkEntityFrameworkImplementation : IUnitOfWork
    {
        private readonly ThemeHospitalDatabaseContainer _mscDatabaseContainer;

        public UnitOfWorkEntityFrameworkImplementation()
        {
            _mscDatabaseContainer = new ThemeHospitalDatabaseContainer();
            //_mscDatabaseContainer.Database.Log = s => Debug.Write(s);
        }

        public T GetById<T>(object id) where T : class
        {
            return _mscDatabaseContainer.Set<T>().Find(id);
        }

        public T Add<T>(T entity) where T : class
        {
            return _mscDatabaseContainer.Set<T>().Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _mscDatabaseContainer.Set<T>().Attach(entity);
            _mscDatabaseContainer.Entry(entity).State = EntityState.Modified;
        }

        public void Remove<T>(T entity) where T : class
        {
            _mscDatabaseContainer.Set<T>().Remove(entity);
        }

        public IQueryable<T> GetAll<T>() where T : class
        {
            return _mscDatabaseContainer.Set<T>();
        }

        public bool HasBeenModified<T>(T entity) where T : class
        {
            return _mscDatabaseContainer.Entry(entity).State == EntityState.Modified;
        }

        public void SaveChanges()
        {
            _mscDatabaseContainer.SaveChanges();
        }

        public void Dispose()
        {
            _mscDatabaseContainer.Dispose();
        }
    }
}
