using System.Collections.Generic;
using ReCapProject.Core.Entities;
using ReCapProject.Core.Utilities.Results;

namespace ReCapProject.Core.Utilities.Business
{
    public interface ICrudServices<T>
    where T:class,IEntity,new()
    {
        IDataResult<List<T>> GetAllService();
        IDataResult<T> GetById(int id);
        IResult AddService(T entity);
        IResult UpdateService(T entity);
        IResult DeleteService(T entity);
    }
}
