using System;
using System.Linq;
using System.Linq.Expressions;
using NHibernate;
using NHibernate.Linq;

namespace $rootnamespace$.Data
{
    public class Dao<T> : IDao<T>
    {
        protected readonly ISessionFactory Factory;

        public Dao(ISessionFactory factory)
        {
            Factory = factory;
        }

        protected ISession Session
        {
            get { return Factory.GetCurrentSession(); }
        }

        #region IDao<T> Members

        public T GetById(object id)
        {
            return Session.Get<T>(id);
        }

        public T GetProxy(object id)
        {
            return Session.Load<T>(id);
        }

        public T MakePersistent(T entity)
        {
            Session.Save(entity);
            return entity;
        }

        public void Update(T entity)
        {
            Session.Update(entity);
        }

        public void Refresh(T entity)
        {

            if (!Session.Contains(entity))
                return;

            object id = Session.GetIdentifier(entity);
            Session.Evict(entity);
            Session.Load(entity, id);
        }

        public IQueryable<T> RetriveAll()
        {
            return Session.Query<T>();
        }

        public IQueryable<T> Retrieve(params Expression<Func<T,object>>[] expandProperties)
        {
            var queryable = GetLinq();
            foreach (var property in expandProperties)
            {
                queryable = queryable.Fetch(property);
            }
            return queryable;
        }

        public IQueryable<T> Retrieve(Expression<Func<T, bool>> predicate)
        {
            return GetLinq().Where(predicate);
        }

        public IQueryable<T> Retrieve(Expression<Func<T, bool>> predicate, params Expression<Func<T,object>>[] expandProperties)
        {
            var queryable = GetLinq();
            foreach (var property in expandProperties)
            {
                queryable = queryable.Fetch(property);
            }
            return queryable.Where(predicate);
        }

        public int Count(Expression<Func<T, bool>> predicate)
        {
            return GetLinq().Where(predicate).Count();
        }

        public void MakeTransient(T entity)
        {
            Session.Delete(entity);
        }

        #endregion

        private IQueryable<T> GetLinq()
        {
            return Session.Query<T>();
        }
    }
}


