CREATE TABLE Cars(
CarId int primary key identity(1,1),
BrandId int,
ColorId int,
CarName nvarchar(20),
ModelYear nvarchar(10),
DailyPrice decimal,
Descriptions nvarchar(50),
foreign key(ColorId) References Colors(ColorId),
foreign key(BrandId) References Brands(BrandId)
)


CREATE TABLE Colors(
ColorId int primary key identity(1,1),
ColorName nvarchar(10)
)

CREATE TABLE Brands(
BrandId int primary key identity(1,1),
BrandName nvarchar(10)
)

INSERT INTO Cars(BrandId,ColorId,CarName,ModelYear,DailyPrice,Descriptions)
values
		('1','1','Symbol','2019','100','Şanzıman:Manuel, Yakıt:Benzin'),
		('2','3','Arona','2020','390','Şanzıman:Otomatik, Yakıt:Dizel'),
		('2','2','Leon','2021','320','Şanzıman:Otomatik, Yakıt:Benzin'),
		('1','3','Clio Sport Tourer','2020','220','Şanzıman:Otomatik, Yakıt:Dizel'),
		('3','4','Passat','2019','370','Şanzıman:Manuel, Yakıt:Dizel'),
		('4','5','i20','2021','260','Şanzıman:Otomatik, Yakıt:Benzin'),
		('2','4','Toledo','2020','340', 'Şanzıman:Manuel, Yakıt:Benzin');

INSERT INTO Colors(ColorName)
VALUES
('Beyaz'),('Mavi'),('Kırmızı'),('Gri'),('Kahverengi')

INSERT INTO Brands (BrandName)
VALUES
('Renault'),('Seat'),('Volkswagen'),('Hyundai')