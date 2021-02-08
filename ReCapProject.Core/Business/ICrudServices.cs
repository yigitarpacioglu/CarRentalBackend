using System;
using System.Collections.Generic;
using System.Text;
using ReCapProject.Core.DataAccess;
using ReCapProject.Core.Entities;

namespace ReCapProject.Core.Business
{
    public interface ICrudServices<T>
    where T:class,IEntity,new()
    {
        List<T> GetAllService();
        T GetById(int id);
        void AddService(T entity);
        void UpdateService(T entity);
        void DeleteService(T entity);
    }
}
