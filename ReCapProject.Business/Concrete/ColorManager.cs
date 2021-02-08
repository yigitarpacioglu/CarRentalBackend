using System;
using System.Collections.Generic;
using System.Text;
using ReCapProject.Business.Abstract;
using ReCapProject.DataAccess.Abstract;
using ReCapProject.Entities.Concrete;

namespace ReCapProject.Business.Concrete
{
    public class ColorManager:IColorService
    {
        private IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public List<Color> GetAllService()
        {
            return _colorDal.GetAll();
        }

        public Color GetById(int id)
        {
            return _colorDal.Get(c => c.ColorId == id);
        }

        public void AddService(Color entity)
        {
            _colorDal.Add(entity);
            Console.WriteLine("\n Renk kaydı başarıyla oluşturuldu");
        }

        public void UpdateService(Color entity)
        {
            _colorDal.Update(entity);
            Console.WriteLine("\n Renk kaydı başarıyla güncellendi");
        }

        public void DeleteService(Color entity)
        {
            _colorDal.Delete(entity);
            Console.WriteLine("\n Renk kaydı başarıyla silindi");
        }
    }
}
