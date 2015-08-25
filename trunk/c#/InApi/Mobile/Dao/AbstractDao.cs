using System;
using System.Collections.Generic;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Linq.Expressions;
using Mobile.Dao.Holders;
using Mobile.Models;

namespace Mobile.Dao
{
    /// <summary>
    /// 各DAOに継承されるAbstractDto
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class AbstractDao<TEntity> where TEntity : EntityObject
    {
        /// <summary>
        /// データをDBにインサートする
        /// </summary>
        /// <param name="entity">エンティティ</param>
        public void Save(TEntity entity)
        {
            ObjectContextHolder.ObjectContext().AddObject(typeof(TEntity).Name, entity);
            ObjectContextHolder.ObjectContext().SaveChanges();
        }

        /// <summary>
        /// （複数）データをDBにインサートする
        /// </summary>
        /// <param name="entities">複数のエンティティ</param>
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

        /// <summary>
        /// データをDBに更新する
        /// </summary>
        /// <param name="entity"></param>
        public void Update(TEntity entity)
        {
            ObjectContextHolder.ObjectContext().ApplyCurrentValues(typeof(TEntity).Name, entity);
            ObjectContextHolder.ObjectContext().SaveChanges();
        }

        /// <summary>
        /// （複数）データをDBに更新する
        /// </summary>
        /// <param name="entities"></param>
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

        /// <summary>
        /// データをDBから削除する
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(TEntity entity)
        {
            ObjectContextHolder.ObjectContext().DeleteObject(entity);
            ObjectContextHolder.ObjectContext().SaveChanges();
        }

        /// <summary>
        /// （複数）データをDBから削除する
        /// </summary>
        /// <param name="entities"></param>
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

        /// <summary>
        /// ページ指定レコードを返す
        /// </summary>
        /// <param name="query"></param>
        /// <param name="paging"></param>
        /// <returns></returns>
        protected IQueryable<dynamic> SelectForPaging(IQueryable<dynamic> query, PagingCriteria paging)
        {
            paging.TotalRecordCount = query.Count();
            paging.ResetPageNumberByMaxPage(paging.MaxPageNumber);
            return query.Skip(paging.CalculateOffset()).Take(paging.SizePerPage);
        }

        /// <summary>
        /// ページ指定レコードを返す
        /// </summary>
        /// <param name="query"></param>
        /// <param name="paging"></param>
        /// <returns></returns>
        protected IQueryable<TEntity> SelectForPaging(IQueryable<TEntity> query, PagingCriteria paging)
        {
            paging.TotalRecordCount = query.Count();
            paging.ResetPageNumberByMaxPage(paging.MaxPageNumber);
            return query.Skip(paging.CalculateOffset()).Take(paging.SizePerPage);
        }

        /// <summary>
        /// データをDBに更新する
        /// </summary>
        /// <param name="update">更新用Expression</param>
        /// <param name="where">更新Where条件Expression</param>
        /// <returns>更新件数</returns>
        public int Update(Action<TEntity> update, Expression<Func<TEntity, bool>> where)
        {
            var query = ObjectContextHolder.ObjectContext().CreateObjectSet<TEntity>().Where<TEntity>(where);
            var count = 0;
            var isSave = false;
            foreach (var entity in query)
            {
                update(entity);
                isSave = true;
                count++;
            }
            if (isSave)
            {
                ObjectContextHolder.ObjectContext().SaveChanges();
            }
            return count;
        }

        /// <summary>
        /// データをDBに削除する
        /// </summary>
        /// <param name="where">削除Where条件Expression</param>
        /// <returns>削除件数</returns>
        public int Delete(Expression<Func<TEntity, bool>> where)
        {
            var query = ObjectContextHolder.ObjectContext().CreateObjectSet<TEntity>().Where<TEntity>(where);
            var count = 0;

            var isSave = false;
            foreach (var entity in query)
            {
                ObjectContextHolder.ObjectContext().DeleteObject(entity);
                count++;
                isSave = true;
            }
            if (isSave)
            {
                ObjectContextHolder.ObjectContext().SaveChanges();
            }
            return count;
        }

        /// <summary>
        /// 検索
        /// </summary>
        /// <param name="predicate">Expression</param>
        /// <returns>結果</returns>
        public IEnumerable<TEntity> FindAny(Expression<Func<TEntity, bool>> predicate)
        {
            var query = ObjectContextHolder.ObjectContext().CreateObjectSet<TEntity>().Where(predicate);
            return query.AsEnumerable();
        }

    }
}
