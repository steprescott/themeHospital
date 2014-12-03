using System;
using System.Collections.Generic;
using System.Linq;

namespace TH.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        T GetById<T>(object id) where T : class;

        T Insert<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        IQueryable<T> GetAll<T>() where T : class;

        bool HasBeenModified<T>(T entity) where T : class;

        void Update<T>(T entity) where T : class;

        void SaveChanges();
    }
}
