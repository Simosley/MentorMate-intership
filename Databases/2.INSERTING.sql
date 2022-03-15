INSERT INTO Roles VALUES(1,'Administrator');
INSERT INTO Roles VALUES(2,'Bartender');
INSERT INTO Roles VALUES(3,'Waiter');

INSERT INTO Users VALUES(1,'Ivan','Ivanov','ivan_ivanov@gmail.com',1,0,'2022-1-1 13:00:00',null,null,null);
INSERT INTO Users VALUES(2,'Petar','Petrov','petar_petrov@gmail.com',2,0,'2022-1-2 14:00:00',null,'Ivan Ivanov',null);
INSERT INTO Users VALUES(3,'Georgi','Georgiev','georgi_georgiev@gmail.com',3,0,'2022-1-3 15:00:00',null,'Ivan Ivanov',null);

INSERT INTO Tables VALUES(1,4,0,'2022-1-3 15:00:00',null,'Ivan Ivanov',null);
INSERT INTO Tables VALUES(2,5,0,'2022-1-3 15:00:00',null,'Ivan Ivanov',null);
INSERT INTO Tables VALUES(3,6,0,'2022-1-3 15:00:00',null,'Ivan Ivanov',null);
INSERT INTO Tables VALUES(4,7,0,'2022-1-3 15:00:00',null,'Ivan Ivanov',null);
INSERT INTO Tables VALUES(5,8,0,'2022-1-3 15:00:00',null,'Ivan Ivanov',null);

INSERT INTO Categories VALUES(1,'food');
INSERT INTO Categories VALUES(2,'beverage');

INSERT INTO SubCategories VALUES(1,'meat');
INSERT INTO SubCategories VALUES(2,'vegetable');
INSERT INTO SubCategories VALUES(3,'alcohol');
INSERT INTO SubCategories VALUES(4,'softdrinks');

INSERT INTO Product_codes VALUES(100,'veal');
INSERT INTO ProductCodes_ProductCategories_ProductSubCategories VALUES(100,1,1);
INSERT INTO Product_codes VALUES(101,'pork');
INSERT INTO ProductCodes_ProductCategories_ProductSubCategories VALUES(101,1,1);
INSERT INTO Product_codes VALUES(102,'chicken');
INSERT INTO ProductCodes_ProductCategories_ProductSubCategories VALUES(102,1,1);

INSERT INTO Product_codes VALUES(200,'carrots');
INSERT INTO ProductCodes_ProductCategories_ProductSubCategories VALUES(200,1,2);
INSERT INTO Product_codes VALUES(201,'cucumbers');
INSERT INTO ProductCodes_ProductCategories_ProductSubCategories VALUES(201,1,2);
INSERT INTO Product_codes VALUES(202,'spinach');
INSERT INTO ProductCodes_ProductCategories_ProductSubCategories VALUES(202,1,2);

INSERT INTO Product_codes VALUES(300,'whiskey');
INSERT INTO ProductCodes_ProductCategories_ProductSubCategories VALUES(300,2,3);
INSERT INTO Product_codes VALUES(301,'lemonade');
INSERT INTO ProductCodes_ProductCategories_ProductSubCategories VALUES(301,2,4);


INSERT INTO Products VALUES(1,100,'a very nice veal','img/path/veal',5,0,'2022-1-4 14:00:00',null,'Ivan Ivanov',null);
INSERT INTO Products VALUES(2,200,'sliced cucumber','img/path/cucumber',2,0,'2022-1-4 15:00:00',null,'Ivan Ivanov',null);
INSERT INTO Products VALUES(3,300,'15 years old whiskey','img/path/whiskey',15,0,'2022-1-4 16:00:00',null,'Ivan Ivanov',null);
INSERT INTO Products VALUES(4,301,'homemade lemonade','img/path/lemonade',3,0,'2022-1-4 17:00:00',null,'Ivan Ivanov',null);

INSERT INTO OrderStatuses VALUES(1,'in progress');
INSERT INTO OrderStatuses VALUES(2,'completed');

INSERT INTO Orders VALUES(1,3,1,1,1,2,0,'2022-1-7 14:00:00',null,'Georgi Georgiev',null);
INSERT INTO Orders VALUES(2,3,2,2,3,2,0,'2022-1-7 14:20:00',null,'Georgi Georgiev',null);
INSERT INTO Orders VALUES(3,3,3,3,2,2,0,'2022-1-7 14:35:00',null,'Georgi Georgiev',null);
INSERT INTO Orders VALUES(4,3,4,4,4,1,0,'2022-1-7 14:50:00',null,'Georgi Georgiev',null);