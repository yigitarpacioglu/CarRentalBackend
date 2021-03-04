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
ColorName nvarchar(10)
)

CREATE TABLE Brands(
BrandId int primary key identity(1,1),
BrandName nvarchar(10)
)

CREATE TABLE Users(
Id int primary key identity(1,1),
FirstName varchar(50), 
Email varchar(50),
PasswordSalt varbinary(500),
PasswordHash varbinary(500),
Status bit
)
CREATE TABLE Customers(
Id int primary key identity(1,1),
UserId int,
CompanyName varchar(50),
foreign key(UserId) References Users(Id),
)

CREATE TABLE Rentals(
Id int primary key identity(1,1),
CarId int,
CustomerId int,
RentDate datetime,
ReturnDate datetime,
foreign key(CarId) References Cars(CarId),
foreign key(CustomerId) References Customers(Id)
)


CREATE TABLE CarImages(
Id int primary key identity(1,1),
CarId int,
ImagePath nvarchar(37),
Date datetime,
foreign key(CarId) References Cars(CarId),
)

alter table CarImages
alter column Date datetime2;
truncate table Users





insert into Colors (ColorName) values ('Yellow');
insert into Colors (ColorName) values ('Fuscia');
insert into Colors (ColorName) values ('Blue');
insert into Colors (ColorName) values ('Goldenrod');
insert into Colors (ColorName) values ('Purple');
insert into Colors (ColorName) values ('Puce');


insert into Brands (BrandName) values ('Chevrolet');
insert into Brands (BrandName) values ('Toyota');
insert into Brands (BrandName) values ('Nissan');
insert into Brands (BrandName) values ('Ford');
insert into Brands (BrandName) values ('Subaru');
insert into Brands (BrandName) values ('Volkswagen');
insert into Brands (BrandName) values ('Land Rover');
insert into Brands (BrandName) values ('BMW');

insert into Cars (BrandId, ColorId, ModelYear, DailyPrice, Descriptions) values (3, 3, 2021, 330, 'Juke');
insert into Cars (BrandId, ColorId, ModelYear, DailyPrice, Descriptions) values (5, 2, 2019, 370, 'Outback');
insert into Cars (BrandId, ColorId, ModelYear, DailyPrice, Descriptions) values (8, 6, 2018, 290, '1.16d');
insert into Cars (BrandId, ColorId, ModelYear, DailyPrice, Descriptions) values (5, 4, 2018, 270, 'Impreza');
insert into Cars (BrandId, ColorId, ModelYear, DailyPrice, Descriptions) values (2, 4, 2018, 250, 'Corolla');
insert into Cars (BrandId, ColorId, ModelYear, DailyPrice, Descriptions) values (1, 5, 2019, 290, 'Captiva');
insert into Cars (BrandId, ColorId, ModelYear, DailyPrice, Descriptions) values (4, 5, 2021, 330, 'Focus');
insert into Cars (BrandId, ColorId, ModelYear, DailyPrice, Descriptions) values (4, 4, 2020, 360, 'Kuga');
insert into Cars (BrandId, ColorId, ModelYear, DailyPrice, Descriptions) values (4, 6, 2019, 260, 'Fiesta');
insert into Cars (BrandId, ColorId, ModelYear, DailyPrice, Descriptions) values (8, 6, 2021, 420, '5.20i');
insert into Cars (BrandId, ColorId, ModelYear, DailyPrice, Descriptions) values (5, 6, 2021, 290, 'Legacy');
insert into Cars (BrandId, ColorId, ModelYear, DailyPrice, Descriptions) values (8, 5, 2016, 310, 'X3.30d');
insert into Cars (BrandId, ColorId, ModelYear, DailyPrice, Descriptions) values (6, 5, 2021, 280, 'Polo');
insert into Cars (BrandId, ColorId, ModelYear, DailyPrice, Descriptions) values (2, 1, 2019, 280, 'Auris');
insert into Cars (BrandId, ColorId, ModelYear, DailyPrice, Descriptions) values (7, 6, 2020, 380, 'Range Rover');
insert into Cars (BrandId, ColorId, ModelYear, DailyPrice, Descriptions) values (7, 4, 2020, 430, 'Discovery');
insert into Cars (BrandId, ColorId, ModelYear, DailyPrice, Descriptions) values (3, 6, 2018, 340, 'Qashqai');
insert into Cars (BrandId, ColorId, ModelYear, DailyPrice, Descriptions) values (2, 4, 2019, 340, 'Hilux');
insert into Cars (BrandId, ColorId, ModelYear, DailyPrice, Descriptions) values (4, 4, 2021, 320, 'Fiesta');
insert into Cars (BrandId, ColorId, ModelYear, DailyPrice, Descriptions) values (1, 5, 2019, 340, 'Captiva');
insert into Cars (BrandId, ColorId, ModelYear, DailyPrice, Descriptions) values (3, 4, 2018, 280, 'Juke');
insert into Cars (BrandId, ColorId, ModelYear, DailyPrice, Descriptions) values (2, 2, 2021, 350, 'Corolla');
insert into Cars (BrandId, ColorId, ModelYear, DailyPrice, Descriptions) values (1, 5, 2019, 290, 'Trax');
insert into Cars (BrandId, ColorId, ModelYear, DailyPrice, Descriptions) values (2, 4, 2020, 370, 'Hilux');
insert into Cars (BrandId, ColorId, ModelYear, DailyPrice, Descriptions) values (6, 2, 2021, 330, 'Jetta');
insert into Cars (BrandId, ColorId, ModelYear, DailyPrice, Descriptions) values (3, 3, 2019, 310, 'Qashqai');
insert into Cars (BrandId, ColorId, ModelYear, DailyPrice, Descriptions) values (8, 4, 2018, 390, '5.25d');
insert into Cars (BrandId, ColorId, ModelYear, DailyPrice, Descriptions) values (5, 4, 2020, 350, 'Forester');
insert into Cars (BrandId, ColorId, ModelYear, DailyPrice, Descriptions) values (6, 5, 2020, 300, 'Polo');
insert into Cars (BrandId, ColorId, ModelYear, DailyPrice, Descriptions) values (3, 2, 2021, 380, 'X-Trail');


insert into Users (FirstName, LastName, Email, Password) values ('Wake', 'Vamplus', 'wvamplus0@indiegogo.com', 'wDRDYK');
insert into Users (FirstName, LastName, Email, Password) values ('Stoddard', 'Fyrth', 'sfyrth1@psu.edu', 'hOHQy2q6Pk');
insert into Users (FirstName, LastName, Email, Password) values ('Wittie', 'Lounds', 'wlounds2@google.ca', 'T2nhybrB');
insert into Users (FirstName, LastName, Email, Password) values ('Olly', 'Gouinlock', 'ogouinlock3@uol.com.br', '1RWjeu2');
insert into Users (FirstName, LastName, Email, Password) values ('Calley', 'Dobell', 'cdobell4@oaic.gov.au', 'DVkwTDJjrX');
insert into Users (FirstName, LastName, Email, Password) values ('Hunt', 'Anthiftle', 'hanthiftle5@amazon.co.jp', 'wXjZGFq');
insert into Users (FirstName, LastName, Email, Password) values ('Anson', 'Hattam', 'ahattam6@washington.edu', 'wln1nBT');
insert into Users (FirstName, LastName, Email, Password) values ('Marlie', 'Shimon', 'mshimon7@com.com', 'kqGptIq7i');
insert into Users (FirstName, LastName, Email, Password) values ('Kalie', 'Robley', 'krobley8@shareasale.com', 'SBnHapV');
insert into Users (FirstName, LastName, Email, Password) values ('Shermy', 'Jacobsohn', 'sjacobsohn9@yellowpages.com', '11imkliJUNS');
insert into Users (FirstName, LastName, Email, Password) values ('Boone', 'Grebner', 'bgrebnera@shop-pro.jp', 'xVzfz9OQ');
insert into Users (FirstName, LastName, Email, Password) values ('Iorgo', 'Sever', 'iseverb@wikimedia.org', 'YWfdsA');
insert into Users (FirstName, LastName, Email, Password) values ('Shelley', 'Bayston', 'sbaystonc@umich.edu', 'UHiUp3GWc');
insert into Users (FirstName, LastName, Email, Password) values ('Valentin', 'Justis', 'vjustisd@privacy.gov.au', 'vESWHrVqm');
insert into Users (FirstName, LastName, Email, Password) values ('Dannye', 'Endrizzi', 'dendrizzie@shutterfly.com', 'yLYR6eW1p');
insert into Users (FirstName, LastName, Email, Password) values ('Katuscha', 'Ondracek', 'kondracekf@usatoday.com', 'QzPkBeena9a');
insert into Users (FirstName, LastName, Email, Password) values ('Cthrine', 'Cordon', 'ccordong@ebay.com', 'RrpJOzCRb3FC');
insert into Users (FirstName, LastName, Email, Password) values ('Carine', 'Lochhead', 'clochheadh@dropbox.com', 'TFdEt6');
insert into Users (FirstName, LastName, Email, Password) values ('Wolfy', 'Haire', 'whairei@mozilla.com', 'LytS1cVD0KxR');
insert into Users (FirstName, LastName, Email, Password) values ('Penn', 'Heyworth', 'pheyworthj@usgs.gov', 'ZsldAtIHMsi');
insert into Users (FirstName, LastName, Email, Password) values ('Theresita', 'Howgill', 'thowgillk@theguardian.com', 'rmFyQG63NQO4');
insert into Users (FirstName, LastName, Email, Password) values ('Edgar', 'Janicki', 'ejanickil@mit.edu', '0VBZXSt4clZc');
insert into Users (FirstName, LastName, Email, Password) values ('Karim', 'McGrann', 'kmcgrannm@yellowpages.com', 'ZplNTUXd');
insert into Users (FirstName, LastName, Email, Password) values ('Eleonore', 'Shephard', 'eshephardn@microsoft.com', 'EPjqcfqby77v');
insert into Users (FirstName, LastName, Email, Password) values ('Merrill', 'Zarfati', 'mzarfatio@histats.com', 'z3sv89tei2');
insert into Users (FirstName, LastName, Email, Password) values ('Anny', 'Leadston', 'aleadstonp@dyndns.org', 'mEhfBe4v');
insert into Users (FirstName, LastName, Email, Password) values ('Kial', 'Bonnell', 'kbonnellq@facebook.com', 'xXmMkxXCTVt');
insert into Users (FirstName, LastName, Email, Password) values ('Consalve', 'Swadon', 'cswadonr@barnesandnoble.com', 'fHqJ3nq7');
insert into Users (FirstName, LastName, Email, Password) values ('Cordy', 'Harbron', 'charbrons@howstuffworks.com', 'NqSxItAjWtH');
insert into Users (FirstName, LastName, Email, Password) values ('Dale', 'Gissing', 'dgissingt@jiathis.com', '6LjP3BIN');
insert into Users (FirstName, LastName, Email, Password) values ('Matty', 'Longfellow', 'mlongfellowu@mozilla.com', 'neFtEOh');
insert into Users (FirstName, LastName, Email, Password) values ('Muriel', 'Petrashov', 'mpetrashovv@zimbio.com', 'qBKPx88Q8');
insert into Users (FirstName, LastName, Email, Password) values ('Neel', 'Colum', 'ncolumw@soundcloud.com', 'MMArOO2');
insert into Users (FirstName, LastName, Email, Password) values ('Therine', 'Mellodey', 'tmellodeyx@mit.edu', 'geRlE1sDsiwC');
insert into Users (FirstName, LastName, Email, Password) values ('Janie', 'Cummine', 'jcumminey@telegraph.co.uk', '1zOiYbuk3B3y');
insert into Users (FirstName, LastName, Email, Password) values ('Vern', 'Peddowe', 'vpeddowez@twitpic.com', '4ee60rROTH');
insert into Users (FirstName, LastName, Email, Password) values ('Alphonso', 'Birckmann', 'abirckmann10@hostgator.com', 'rOZAOewpdX');
insert into Users (FirstName, LastName, Email, Password) values ('Margalit', 'Toffetto', 'mtoffetto11@illinois.edu', 'HR0kFHU1AHQX');
insert into Users (FirstName, LastName, Email, Password) values ('Amaleta', 'Ferre', 'aferre12@nhs.uk', 'ZmAFxrBvhA');
insert into Users (FirstName, LastName, Email, Password) values ('Ruthe', 'Tribbeck', 'rtribbeck13@reddit.com', '2RVQ5jDHoCj');
insert into Users (FirstName, LastName, Email, Password) values ('Analise', 'Dignam', 'adignam14@yahoo.com', 'vuSf0Y0Bh');
insert into Users (FirstName, LastName, Email, Password) values ('Merrill', 'Roughsedge', 'mroughsedge15@wsj.com', 'UzNW1a62t6');
insert into Users (FirstName, LastName, Email, Password) values ('Tyrus', 'Cecil', 'tcecil16@seesaa.net', 'B0OTqR2PE');
insert into Users (FirstName, LastName, Email, Password) values ('Kit', 'Wait', 'kwait17@google.es', 'zCfu9j');
insert into Users (FirstName, LastName, Email, Password) values ('Rozelle', 'Sausman', 'rsausman18@parallels.com', 'pGK8sPQd');
insert into Users (FirstName, LastName, Email, Password) values ('Elsbeth', 'Leggon', 'eleggon19@fema.gov', 'KjUouo');
insert into Users (FirstName, LastName, Email, Password) values ('Gwendolin', 'Rosewarne', 'grosewarne1a@networkadvertising.org', '08oCZJ');
insert into Users (FirstName, LastName, Email, Password) values ('Kelsey', 'Brownsworth', 'kbrownsworth1b@cyberchimps.com', 'nDDEba0');
insert into Users (FirstName, LastName, Email, Password) values ('Keeley', 'Dyball', 'kdyball1c@auda.org.au', 'tufGrefglJH');
insert into Users (FirstName, LastName, Email, Password) values ('Elaina', 'Doreward', 'edoreward1d@prweb.com', 'N88Ahv');

insert into Customers (UserId, CompanyName) values (6, 'Eamia');
insert into Customers (UserId, CompanyName) values (3, 'InnoZ');
insert into Customers (UserId, CompanyName) values (1, 'Realbuzz');
insert into Customers (UserId, CompanyName) values (5, 'Zava');
insert into Customers (UserId, CompanyName) values (7, 'Realbridge');
insert into Customers (UserId, CompanyName) values (8, 'Realmix');
insert into Customers (UserId, CompanyName) values (49, 'Dazzlesphere');
insert into Customers (UserId, CompanyName) values (46, 'Skidoo');
insert into Customers (UserId, CompanyName) values (50, 'Edgewire');
insert into Customers (UserId, CompanyName) values (13, 'Dynazzy');
insert into Customers (UserId, CompanyName) values (19, 'Centimia');
insert into Customers (UserId, CompanyName) values (12, 'Skalith');
insert into Customers (UserId, CompanyName) values (17, 'Wordify');
insert into Customers (UserId, CompanyName) values (26, 'Demimbu');
insert into Customers (UserId, CompanyName) values (5, 'Flashspan');
insert into Customers (UserId, CompanyName) values (29, 'Skiptube');
insert into Customers (UserId, CompanyName) values (9, 'Yabox');
insert into Customers (UserId, CompanyName) values (37, 'Tagfeed');
insert into Customers (UserId, CompanyName) values (32, 'Devpulse');
insert into Customers (UserId, CompanyName) values (23, 'Topiczoom');


insert into Rentals (CarId, CustomerId, RentDate, ReturnDate) values (9, 1, CONVERT(datetime,'07.01.2021',103), CONVERT(datetime,'13.01.2021',103));
insert into Rentals (CarId, CustomerId, RentDate, ReturnDate) values (7, 13, CONVERT(datetime,'02.02.2021',103), CONVERT(datetime,'08.02.2021',103));
insert into Rentals (CarId, CustomerId, RentDate, ReturnDate) values (2, 14, CONVERT(datetime,'19.01.2021',103), CONVERT(datetime,'05.02.2021',103));
insert into Rentals (CarId, CustomerId, RentDate, ReturnDate) values (8, 16, CONVERT(datetime,'04.01.2021',103), CONVERT(datetime,'11.01.2021',103));
insert into Rentals (CarId, CustomerId, RentDate, ReturnDate) values (5, 12, CONVERT(datetime,'27.11.2021',103), CONVERT(datetime,'06.12.2021',103));
insert into Rentals (CarId, CustomerId, RentDate, ReturnDate) values (10, 11, CONVERT(datetime,'13.01.2021',103), CONVERT(datetime,'16.01.2021',103));
insert into Rentals (CarId, CustomerId, RentDate, ReturnDate) values (9, 15, CONVERT(datetime,'14.01.2021',103), CONVERT(datetime,'16.01.2021',103));
insert into Rentals (CarId, CustomerId, RentDate, ReturnDate) values (1, 2, CONVERT(datetime,'11.12.2021',103), CONVERT(datetime,'16.12.2021',103));
insert into Rentals (CarId, CustomerId, RentDate, ReturnDate) values (6, 11, CONVERT(datetime,'10.02.2021',103), null);
insert into Rentals (CarId, CustomerId, RentDate, ReturnDate) values (30, 19, CONVERT(datetime,'14.01.2021',103), CONVERT(datetime,'15.01.2021',103));
insert into Rentals (CarId, CustomerId, RentDate, ReturnDate) values (21, 2, CONVERT(datetime,'16.01.2021',103), CONVERT(datetime,'19.01.2021',103));
insert into Rentals (CarId, CustomerId, RentDate, ReturnDate) values (20, 19, CONVERT(datetime,'27.01.2021',103), CONVERT(datetime,'03.02.2021',103));
insert into Rentals (CarId, CustomerId, RentDate, ReturnDate) values (24, 2, CONVERT(datetime,'01.01.2021',103), CONVERT(datetime,'03.02.2021',103));
insert into Rentals (CarId, CustomerId, RentDate, ReturnDate) values (4, 17, CONVERT(datetime,'03.01.2021',103), CONVERT(datetime,'05.01.2021',103));
insert into Rentals (CarId, CustomerId, RentDate, ReturnDate) values (22, 4, CONVERT(datetime,'08.02.2021',103), CONVERT(datetime,'13.02.2021',103));
insert into Rentals (CarId, CustomerId, RentDate, ReturnDate) values (20, 7, CONVERT(datetime,'02.02.2021',103), null);
insert into Rentals (CarId, CustomerId, RentDate, ReturnDate) values (29, 14, CONVERT(datetime,'10.02.2021',103), CONVERT(datetime,'11.02.2021',103));
insert into Rentals (CarId, CustomerId, RentDate, ReturnDate) values (12, 1, CONVERT(datetime,'12.01.2021',103), CONVERT(datetime,'17.01.2021',103));
insert into Rentals (CarId, CustomerId, RentDate, ReturnDate) values (1, 6, CONVERT(datetime,'21.01.2021',103),CONVERT(datetime,'08.02.2021',103));
insert into Rentals (CarId, CustomerId, RentDate, ReturnDate) values (8, 1, CONVERT(datetime,'15.02.2021',103), null);
insert into Rentals (CarId, CustomerId, RentDate, ReturnDate) values (19, 5, CONVERT(datetime,'17.02.2021',103), null);
insert into Rentals (CarId, CustomerId, RentDate, ReturnDate) values (3, 11, CONVERT(datetime,'14.02.2021',103), null);
insert into Rentals (CarId, CustomerId, RentDate, ReturnDate) values (28, 12, CONVERT(datetime,'08.02.2021',103), null);
insert into Rentals (CarId, CustomerId, RentDate, ReturnDate) values (17, 13, CONVERT(datetime,'04.02.2021',103), null);
insert into Rentals (CarId, CustomerId, RentDate, ReturnDate) values (13, 18, CONVERT(datetime,'19.02.2021',103), null);

drop table Users