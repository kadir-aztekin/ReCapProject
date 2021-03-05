using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    public interface IEntityRepository<T>  where T:class ,IEntity,new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null); // return filter == null
                                                                 // ? context.Set<entity>().ToList()
                                                                 // : context.Set<entity>().Where(filter).ToList();


        T Get(Expression<Func<T, bool>> filter = null); //return.context.Set<Entity>().SingleOrDefaulft(filter);

        void Add(T entity); // var addedEntity = context.Entry(entity);
                            // addedEntity.State =EntityState.Add;
                            // context.SaveChanges();

        
        void Delete(T entity);// var deleteEntity = context.Entry(entity);
                              // deletedEntity.State =EntityState.Deleted;
                              // context.SaveChanges();
        void Update(T entity);// var updateEntity = context.Entry(entity);
                              // updateEntity.State =EntityState.Modified;
                              // context.SaveChanges();
    }
}
