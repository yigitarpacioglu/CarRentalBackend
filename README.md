
### İkinci El Araç Satış Platformu

## Son Güncellemeler
!! 

## Core
IEntity, IDto, IEntityRepository, EfEntityRepositoryBase yapıları bu katman içerisinde oluşturuldu.
IDto: Özel sorgular ile çekilebilecek nesneler için oluşturulan arayüz.
IEntityRepository: T generic yapısı ile kolayca implemente edilebilen, Gerçek DataAccess katmanındaki arayüzler için temel database işlemlerini tutmaktadır.,
EfEntityRepositoryBase: Entity Framework yapısı için yine generic bir yapıda context ve yapısını oluşturacak olan nesnesi(entity) yardımıyla temel database işlemleri için somut bir arayüz implementasyonunu sağlayacak iskeleti tutmaktadır.
ICrudServices: Gerçek Business katmanında farklı nesnelere ait servisler için benzer veri tabanı işlemlerinin uygulanabilirliğini kolaylaştırmak amacıyla generic yapıda oluşturulmuştur.

## Entities 
Car adında bir sınıf ile araç özelliklerini tutan nesne oluşturuldu.
Özellik olarak : Id, BrandId, ColorId, ModelYear, DailyPrice, Description alanları eklendi.
Brand ve Color nesneleri eklendi. Bu nesneler Id ve Name özelliklerini taşımaktadırlar.

## DataAccess 
Veritabanından ekleme, silme, listeleme gibi işlemleri içermektedir.
Database için gerekli sorgular projeye eklenmiştir.
Car, Brand ve Color nesneleri için Entity Framework altyapısını yazılmıştır.

## Business 
Data Access katmanı aracılığıyla 
- GetAllService()          : Liste içerisindeki bütün araçları döndürmek,
- GetById(int id)          : Dışarıdan verilen bir ID ile ilişkili nesneyi döndürmektedir.
- AddService(T entity)     : Dışarıdan verilen bir nesnenin sisteme eklenmesi,
- UpdateService(T entity)  : Dışarıdan verilen bir nesnenin sistemdeki eşleşen ilanın güncellenmesi, 
- DeleteService(T entity)  : Yine dışarıdan verilen bir nesne ile eşleşen ilanın silinmesi fonksiyonları gerçekleştirilmiştir.

## ConsoleUI
Consolda bütün CRUD test işlemleri gerçekleştirilmektedir.
Ayrıca GetCarDetails() ile farklı tablolarda bulunan CarName, BrandName, ColorName, DailyPrice bilgileri tabloların join edilmesi işlemi ile bir araya getirildi.
