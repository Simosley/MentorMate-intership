CREATE TABLE Users (
     id int PRIMARY KEY,
     first_name nvarchar(30) ,
     last_name nvarchar(30) ,
	 email nvarchar(100) ,
	 role_id int  ,
	 is_deleted bit ,
	 create_date DATETIME ,
	 update_date DATETIME ,
	 created_by nvarchar(100) ,
	 updated_by nvarchar(100) ,
);

CREATE TABLE Roles (
	id int PRIMARY KEY,
	name nvarchar(30) ,
);
ALTER TABLE Users
ADD FOREIGN KEY(role_id)
REFERENCES Roles(id)
ON DELETE SET NULL;


CREATE TABLE Tables (
     id int PRIMARY KEY,
	 capacity int ,
	 is_deleted bit ,
	 create_date DATETIME ,
	 update_date DATETIME ,
	 created_by nvarchar(100) ,
	 updated_by nvarchar(100) ,
);

CREATE TABLE Categories(
	id int PRIMARY KEY,
	name nvarchar(300)
);
CREATE TABLE SubCategories(
	id int PRIMARY KEY,
	name nvarchar(300)
);


CREATE TABLE Product_codes (
	product_code int PRIMARY KEY,
	product_name nvarchar(30),
);
CREATE TABLE ProductCodes_ProductCategories_ProductSubCategories(
	product_code int FOREIGN KEY REFERENCES Product_codes(product_code),
	product_category int FOREIGN KEY REFERENCES Categories(id),
	product_subcategory int FOREIGN KEY REFERENCES SubCategories(id)
);

CREATE TABLE Products (
     product_id int PRIMARY KEY,
     product_code int FOREIGN KEY REFERENCES Product_codes(product_code) ,
	 [description] nvarchar(60) ,
	 image_path nvarchar(200) ,
	 price float,
	 is_deleted bit ,
	 create_date DATETIME ,
	 update_date DATETIME ,
	 created_by nvarchar(100) ,
	 updated_by nvarchar(100) ,
);

CREATE TABLE OrderStatuses (
	id int PRIMARY KEY,
	name nvarchar(20)
);

CREATE TABLE Orders (
     order_id int PRIMARY KEY,
     waiter_id  int FOREIGN KEY REFERENCES Users(id) ,
     table_id int FOREIGN KEY REFERENCES Tables(id),
	 product_id int FOREIGN KEY REFERENCES Products(product_id),
	 quantity int ,
	 status_id int FOREIGN KEY REFERENCES OrderStatuses(id) , 
	 is_deleted bit ,
	 create_date DATETIME ,
	 update_date DATETIME ,
	 created_by nvarchar(100) ,
	 updated_by nvarchar(100) ,
);


