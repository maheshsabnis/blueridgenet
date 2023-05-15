using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_EFCoreAppStructure.Services
{
    /// <summary>
    /// TENtity : will be an entity type which will be either Department, EMpoyee, etc (aka any entuty class)
    /// TPk, the Primary Key type e.g. eithe int or string
    /// THe 'in' means always an input parametere to the method
    /// 
    /// The "where TEntity : class" means its an constraint applied on TEntity the 
    /// it will always be a class
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TPk"></typeparam>
    public interface IServices<TEntity, in TPk> where TEntity : class
    {
        List<TEntity> Get();
        TEntity Get(TPk pk);
        TEntity Create(TEntity entity);
        TEntity Update(TPk id, TEntity entity);
        bool Delete(TPk pk);    
    }
}
