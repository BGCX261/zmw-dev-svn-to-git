using System;
using System.Collections.Generic;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Linq.Expressions;
using zmw.dev.Dao.Holders;
using zmw.dev.Models.Criteria;

namespace zmw.dev.Dao
{
    public class AbstractDao<TEntity> where TEntity : EntityObject
    {
        public IEnumerable<TEntity> FindAny(Expression<Func<TEntity, bool>> predicate)
        {
            var query = ObjectContextHolder.ObjectContext().CreateObjectSet<TEntity>().Where(predicate);
            return query.AsEnumerable();
        }

        public IEnumerable<TEntity> FindAll()
        {
            var query = from entity in ObjectContextHolder.ObjectContext().CreateObjectSet<TEntity>()
                        select entity;

            return query.AsEnumerable();
        }

        public IEnumerable<TEntity> FindAllWithAsc(Expression<Func<TEntity, object>> orderDelegate)
        {
            var query = ObjectContextHolder.ObjectContext().CreateObjectSet<TEntity>().OrderBy(orderDelegate);
            return query.AsEnumerable();
        }

        public IEnumerable<TEntity> FindAllWithAsc(Expression<Func<TEntity, object>> orderDelegate, Expression<Func<TEntity, object>> orderDelegate2)
        {
            var query = ObjectContextHolder.ObjectContext().CreateObjectSet<TEntity>().OrderBy(orderDelegate).ThenBy(orderDelegate2);
            return query.AsEnumerable();
        }

        public IEnumerable<TEntity> FindAllWithAscAndDesc(Expression<Func<TEntity, object>> orderAscDelegate, Expression<Func<TEntity, object>> orderDescDelegate2)
        {
            var query = ObjectContextHolder.ObjectContext().CreateObjectSet<TEntity>().OrderBy(orderAscDelegate).ThenByDescending(orderDescDelegate2);
            return query.AsEnumerable();
        }

        public IEnumerable<TEntity> FindAllWithDesc(Expression<Func<TEntity, object>> orderDelegate)
        {
            var query = ObjectContextHolder.ObjectContext().CreateObjectSet<TEntity>().OrderByDescending(orderDelegate);
            return query.AsEnumerable();
        }

        public IEnumerable<TEntity> FindAllWithDesc(Expression<Func<TEntity, object>> orderDelegate, Expression<Func<TEntity, object>> orderDelegate2)
        {
            var query = ObjectContextHolder.ObjectContext().CreateObjectSet<TEntity>().OrderByDescending(orderDelegate).ThenByDescending(orderDelegate2);
            return query.AsEnumerable();
        }

        public IEnumerable<TEntity> FindAllWithDescAndAsc(Expression<Func<TEntity, object>> orderDescDelegate, Expression<Func<TEntity, object>> orderAscDelegate2)
        {
            var query = ObjectContextHolder.ObjectContext().CreateObjectSet<TEntity>().OrderByDescending(orderDescDelegate).ThenBy(orderAscDelegate2);
            return query.AsEnumerable();
        }

        public void Save(TEntity entity)
        {
            ObjectContextHolder.ObjectContext().AddObject(typeof(TEntity).Name, entity);
            ObjectContextHolder.ObjectContext().SaveChanges();
        }

        public void Save(IEnumerable<TEntity> entities)
        {
            bool isSave = false;
            foreach (var entity in entities)
            {
                ObjectContextHolder.ObjectContext().AddObject(typeof(TEntity).Name, entity);
                isSave = true;
            }
            if (isSave)
            {
                ObjectContextHolder.ObjectContext().SaveChanges();
            }
        }

        public void Update(TEntity entity)
        {
            ObjectContextHolder.ObjectContext().ApplyCurrentValues(typeof(TEntity).Name, entity);
            ObjectContextHolder.ObjectContext().SaveChanges();
        }

        public void Update(IEnumerable<TEntity> entities)
        {
            bool isSave = false;
            foreach (var entity in entities)
            {
                ObjectContextHolder.ObjectContext().ApplyCurrentValues(typeof(TEntity).Name, entity);
                isSave = true;
            }
            if (isSave)
            {
                ObjectContextHolder.ObjectContext().SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            ObjectContextHolder.ObjectContext().DeleteObject(entity);
            ObjectContextHolder.ObjectContext().SaveChanges();
        }

        public void Delete(IEnumerable<TEntity> entities)
        {
            bool isSave = false;
            foreach (var entity in entities)
            {
                ObjectContextHolder.ObjectContext().DeleteObject(entity);
                isSave = true;
            }
            if (isSave)
            {
                ObjectContextHolder.ObjectContext().SaveChanges();
            }
        }

        protected IQueryable<TEntity> SelectForPaging(IQueryable<TEntity> query, PagingCriteria paging)
        {
            paging.TotalRecordCount = query.Count();
            paging.ResetPageNumberByMaxPage((paging.TotalRecordCount - 1) / paging.SizePerPage);
            return query.Skip(paging.CalculateOffset()).Take(paging.SizePerPage);
        }
    }
}