
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Aloti.Forms.Prims.Storage
{
    public class SQliteRepository<TEntity, TPKey> where TEntity : class, new()
    {

        protected DBContext Db => DBContext.Get(typeof(TEntity));


        public virtual IList<TEntity> FindAll()
        {
            TableQuery<TEntity> query = Db._SQLiteConnection.Table<TEntity>();
            return Db.ToList<TEntity>(query);
        }

        public virtual TEntity Find(TPKey id)
        {
            return Db.Find<TEntity>(id);
        }


        protected virtual IList<TEntity> FindAllWhere(Expression<Func<TEntity, bool>> predExpr)
        {
            TableQuery<TEntity> query = Db._SQLiteConnection.Table<TEntity>().Where(predExpr);
            return Db.ToList<TEntity>(query);
        }

        protected virtual IList<TEntity> FindAllWhere<U>(Expression<Func<TEntity, bool>> predExpr, Expression<Func<TEntity, U>> orderBy)
        {
            if (predExpr == null)
            {
                TableQuery<TEntity> query = Db._SQLiteConnection.Table<TEntity>().OrderBy(orderBy);
                return Db.ToList<TEntity>(query);
            }
            else
            {
                TableQuery<TEntity> query = Db._SQLiteConnection.Table<TEntity>().Where(predExpr).OrderBy(orderBy);
                return Db.ToList<TEntity>(query);
            }
        }

        internal TableQuery<TEntity> Query()
        {
            return Db._SQLiteConnection.Table<TEntity>();
        }


        public virtual void Save(TEntity entity)
        {
            Db.InsertOrReplace(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            Db.Delete(entity);
        }
    }
}
