
# İkinci El Araç Satış Platformu

## Entities 
Car adında bir sınıf ile araç özelliklerini tutan nesne oluşturuldu.
Özellik olarak : Id, BrandId, ColorId, ModelYear, DailyPrice, Description alanları eklendi.

## DataAccess 
Database yerine, Visual Studio içerisinde bulunan List yapıları veritabanı olarak kullanılmıştır.
Veritabanından ekleme, silme, listeleme gibi işlemleri içermektedir.

## Business 
Data Access katmanı aracılığıyla 
- GetAllCars()                : Liste içerisindeki bütün araçları döndürmek,
- GetById(int id)             : Dışarıdan verilen bir ID numarası ile sistemde mevcut ise bu aracı döndürmek,
- GetSameBrands(int brandId)  : Dışarıdan verilen bir marka kodu ile aynı markaya ait araç ilanlarını döndürmek,
- AddCarToSystem(Car car)     : Dışarıdan verilen bir ilanı sisteme eklenmesi,
- UpdateCarInSystem(Car car)  : Dışarıdan verilen bir ilan ile sistemde sistemde eşleşen ilanın güncellenmesi, 
- DeleteCarFromSystem(Car car): Yine dışarıdan verilen bir ilan ile eşleşen ilanın silinmesi fonksiyonları gerçekleştirilmiştir.

## ConsoleUI
Consolda test işlemleri gerçekleştirildi.
