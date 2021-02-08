using System;
using System.Collections.Generic;
using System.Text;
using ReCapProject.Business.Abstract;
using ReCapProject.DataAccess.Abstract;
using ReCapProject.DataAccess.Concrete.EntityFramework;
using ReCapProject.Entities.Concrete;

namespace ReCapProject.Business.Concrete
{
    public class BrandManager:IBrandService
    {
        private IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public List<Brand> GetAllService()
        {
            return _brandDal.GetAll();
        }

        public Brand GetById(int id)
        {
            return _brandDal.Get(p => p.BrandId == id);
        }

        public void AddService(Brand entity)
        {
            _brandDal.Add(entity);
            Console.WriteLine("\n Marka kaydı başarıyla oluşturuldu");
        }

        public void UpdateService(Brand entity)
        {
            _brandDal.Update(entity);
            Console.WriteLine("\n Marka kaydı başarıyla güncellendi");
        }

        public void DeleteService(Brand entity)
        {
            _brandDal.Delete(entity);
            Console.WriteLine("\n Marka kaydı başarıyla silindi");
        }
    }
}
