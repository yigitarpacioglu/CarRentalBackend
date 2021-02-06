
### İkinci El Araç Satış Platformu

## Son Güncellemeler

!! Brand ve Color nesneleri eklendi. Bu nesneler Id ve Name özelliklerini taşımaktadırlar.
!! Database için gerekli sorgular projeye eklendi.
!! IEntityRepository generic yapısı eklendi ve Dal araçları bu repository'den çekilmeye başlandı.
!! Car, Brand ve Color nesneleri için Entity Framework altyapısını yazıldı.
!! GetCarsByBrandId , GetCarsByColorId servislerini yazıldı.
!! Araba ekleme işlemi için Business katmanında AddCarToSystem() içerisinde kısıtlamalar yapıldı.

## Entities 
Car adında bir sınıf ile araç özelliklerini tutan nesne oluşturuldu.
Özellik olarak : Id, BrandId, ColorId, ModelYear, DailyPrice, Description alanları eklendi.

## DataAccess 
Database yerine, Visual Studio içerisinde bulunan List yapıları veritabanı olarak kullanılmıştır.
Veritabanından ekleme, silme, listeleme gibi işlemleri içermektedir.

## Business 
Data Access katmanı aracılığıyla 
- GetAllCars()                   : Liste içerisindeki bütün araçları döndürmek,
- GetCarsByColorId(int colorId)  : Dışarıdan verilen bir renk kodu ile aynı renge ait araç ilanlarını döndürmek,
- GetCarsByBrandId(int brandId)  : Dışarıdan verilen bir marka kodu ile aynı markaya ait araç ilanlarını döndürmek,
- AddCarToSystem(Car car)        : Dışarıdan verilen bir ilanı sisteme eklenmesi,
- UpdateCarInSystem(Car car)     : Dışarıdan verilen bir ilan ile sistemde sistemde eşleşen ilanın güncellenmesi, 
- DeleteCarFromSystem(Car car)   : Yine dışarıdan verilen bir ilan ile eşleşen ilanın silinmesi fonksiyonları gerçekleştirilmiştir.

## ConsoleUI
Consolda test işlemleri gerçekleştirildi.
