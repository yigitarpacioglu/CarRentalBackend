CREATE TABLE Cars(
CarId int primary key identity(1,1),
BrandId int,
ColorId int,
ModelYear int,
DailyPrice decimal,
Descriptions nvarchar(50),
foreign key(ColorId) References Colors(ColorId),
foreign key(BrandId) References Brands(BrandId)
)

CREATE TABLE Colors(
ColorId int primary key identity(1,1),
ColorName nvarchar(25)
)

CREATE TABLE Brands(
BrandId int primary key identity(1,1),
BrandName nvarchar(25)
)

INSERT INTO Cars(BrandId,ColorId,ModelYear,DailyPrice,Descriptions)
values
		('1','2','2014','150.000','Elentra 1.6 CRDi Style'),
		('2','1','2017','180.000','Polo 1.4 TDi Comfortline'),
		('3','1','2015','130.000','Corsa 1.6 CRDi Style'),
		('2','3','2018','200.000','Jetta 1.2 TSI BlueMotion Comfortline'),
		('1','1','2019','180.000','Elentra 1.6 MPI Style'),
		('3','3','2020','380.000','Insignia 1.6 CRDi Style');

INSERT INTO Colors(ColorName)
VALUES
('Beyaz'),('Füme'),('Siyah')

INSERT INTO Brands (BrandName)
VALUES
('Hyundai'),('Volkswagen'),('Opel')