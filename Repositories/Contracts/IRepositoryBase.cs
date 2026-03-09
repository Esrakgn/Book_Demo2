using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Repositories.Contracts
{
    public interface IRepositoryBase<T>
    { //crud işlemlerini yaparken tekrar tekrar yazmamak için generic bir yapı oluşturduk
        IQueryable<T> FindAll(bool trackChanges);
        IQueryable<T> FindByCondition(Expression<Func<T,bool>> expression, bool trackChanges);
           void Create(T entity);
           void Update(T entity);
           void Delete(T entity);



    }
}
