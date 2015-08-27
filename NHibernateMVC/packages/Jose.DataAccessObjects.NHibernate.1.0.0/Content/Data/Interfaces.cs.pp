using System;
using System.Linq;
using System.Linq.Expressions;

namespace $rootnamespace$.Data
{
    public partial interface IDaoReadOnly<T>
    {
        T GetById(object id);
        T GetProxy(object id);
        void Refresh(T entity);
        IQueryable<T> RetriveAll();
        IQueryable<T> Retrieve(params Expression<Func<T,object>>[] expandProperties);
        IQueryable<T> Retrieve(Expression<Func<T, bool>> predicate);
        IQueryable<T> Retrieve(Expression<Func<T, bool>> predicate, params Expression<Func<T,object>>[] expandProperties);
        int Count(Expression<Func<T, bool>> predicate);
    }

    public partial interface IDao<T> : IDaoReadOnly<T>
    {
        T MakePersistent(T entity);
        void Update(T entity);
        void MakeTransient(T entity);
    }	
}