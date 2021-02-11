using System;
using System.Collections.Generic;
using System.Text;
using ReCapProject.Core.DataAccess;
using ReCapProject.Core.Entities;
using ReCapProject.Core.Utilities.Results;

namespace ReCapProject.Core.Business
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
