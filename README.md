
### İkinci El Araç Satış Platformu

## Son Güncellemeler

!! Core katmanı oluşturuldu.
!! IEntity, IDto, IEntityRepository, EfEntityRepositoryBase yapıları bu katman içerisine taşındı veya içerisinde oluşturuldu.
!! IDto: Özel sorgular ile çekilebilecek nesneler.
!! IEntityRepository ve IEntity Core katmanına taşındı. 
!! Core.EntityFramework içerisindeki EfEntityRepository; CRUD işlemlerinin temel iskeletini taşımaktadır. 
!! Car, Brand, Color sınıflarınız için tüm CRUD operasyonlarını hazır hale getirildi.
!! Console'da tüm CRUD operasyonları Car, Brand, Model nesneleriniz için test edildi. (GetAll, GetById, Insert, Update, Delete)

!! Ayrıca GetCarDetails() ile farklı tablolarda bulunan CarName, BrandName, ColorName, DailyPrice bilgileri tabloların join edilmesi işlemi ile bir araya getirildi.

## Entities 
Car adında bir sınıf ile araç özelliklerini tutan nesne oluşturuldu.
Özellik olarak : Id, BrandId, ColorId, ModelYear, DailyPrice, Description alanları eklendi.
Brand ve Color nesneleri eklendi. Bu nesneler Id ve Name özelliklerini taşımaktadırlar.

## DataAccess 
Veritabanından ekleme, silme, listeleme gibi işlemleri içermektedir.
Database için gerekli sorgular projeye eklendi.
IEntityRepository generic yapısı eklendi ve Dal araçları bu repository'den çekilmeye başlandı.
Car, Brand ve Color nesneleri için Entity Framework altyapısını yazıldı.

## Business 
Data Access katmanı aracılığıyla 
- GetAllService()          : Liste içerisindeki bütün araçları döndürmek,
- GetById(int id)          : Dışarıdan verilen bir ID ile ilişkili nesneyi döndürmektedir.
- AddService(Car car)      : Dışarıdan verilen bir ilanı sisteme eklenmesi,
- UpdateService(Car car)   : Dışarıdan verilen bir ilan ile sistemde sistemde eşleşen ilanın güncellenmesi, 
- DeleteService(Car car)   : Yine dışarıdan verilen bir ilan ile eşleşen ilanın silinmesi fonksiyonları gerçekleştirilmiştir.

## ConsoleUI
Consolda test işlemleri gerçekleştirildi.
