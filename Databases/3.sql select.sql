--Products list - select all active products (paginated)
SELECT * FROM Products
WHERE is_deleted=0 
ORDER BY product_id
OFFSET 0 ROWS
FETCH NEXT 2 ROWS ONLY

SELECT * FROM Products
WHERE is_deleted=0 
ORDER BY product_id
OFFSET 2 ROWS
FETCH NEXT 2 ROWS ONLY
--Products list - select all active products (paginated)

--List of busy/occupied tables
SELECT id FROM Tables
WHERE id NOT IN (SELECT table_id FROM Orders);
--List of busy/occupied tables

--List of free tables
SELECT id FROM Tables
WHERE id  IN (SELECT table_id FROM Orders);
--List of free tables

--List orders in progress
SELECT * FROM Orders
WHERE status_id=1
--List orders in progress
--List completed orders (paginated)
SELECT * FROM Orders
WHERE status_id = 2
ORDER BY product_id
OFFSET 0 ROWS
FETCH NEXT 3 ROWS ONLY
--List completed orders (paginated)
--Search by part of product name - select all matching products
SELECT CASE WHEN CHARINDEX('ce',[description]) > 0 THEN [description]
	ELSE 'not found in here'
	END as search
FROM Products
--Search by part of product name - select all matching products

--Select order details by order number - result should contain total price, waiter, date and time
SELECT Orders.order_id,Users.first_name,Users.last_name,Orders.create_date,
(SELECT Products.price * Orders.quantity ) AS Bill  FROM Orders,Users,Products
WHERE Orders.waiter_id=Users.id AND Products.product_id=Orders.product_id
ORDER BY order_id
--Select order details by order number - result should contain total price, waiter, date and time

--List of order products by order number - result should contain name, code, price
SELECT Product_codes.product_name,Product_codes.product_code,Products.price 
FROM Product_codes,Products,Orders
WHERE (Orders.product_id= Products.product_id) AND (Products.product_code = Product_codes.product_code)
--List of order products by order number - result should contain name, code, price

--List orders per period (start date and time, end date time) - result should contain order total and date
SELECT Orders.create_date,(SELECT Products.price * Orders.quantity ) AS Bill
FROM Orders,Products
WHERE Products.product_id=Orders.product_id AND Orders.create_date >= '2022-01-07 14:00:00.000' AND Orders.create_date <= '2022-01-07 14:35:00.000'
--List orders per period (start date and time, end date time) - result should contain order total and date


--List sold products for a given month - result should show aggregated quantity and aggregated price for all sales during the search period. Every matching product should exist once into the result.
SELECT SUM(Orders.quantity) AS AggregateOrder, (SUM(Products.price * Orders.quantity)) AS AggregatePrice  FROM Orders,Products
WHERE Orders.status_id=2 AND Products.product_id=Orders.product_id AND MONTH(Orders.create_date) = '1'
--List sold products for a given month - result should show aggregated quantity and aggregated price for all sales during the search period. Every matching product should exist once into the result.