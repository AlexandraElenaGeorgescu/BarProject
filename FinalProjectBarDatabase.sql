----create database Bar
--CREATE TABLE customers (
--  Customer_id INTEGER PRIMARY KEY,
--  Name TEXT NOT NULL,
--  Phone_number TEXT NOT NULL,
--  Email_address TEXT NOT NULL
--);

--CREATE TABLE tables (
--  Table_id INTEGER PRIMARY KEY,
--  Number INTEGER NOT NULL,
--  Capacity INTEGER NOT NULL,
--  Customer_id INTEGER,
--  FOREIGN KEY (customer_id) REFERENCES customers (customer_id)
--);

--CREATE TABLE customers_sit_at (
--  Customer_id INTEGER NOT NULL,
--  Table_id INTEGER NOT NULL,
--  FOREIGN KEY (customer_id) REFERENCES customers (customer_id),
--  FOREIGN KEY (table_id) REFERENCES tables (table_id),
--  PRIMARY KEY (customer_id, table_id)
--);

--CREATE TABLE employees (
--  Employee_id INTEGER PRIMARY KEY,
--  Name TEXT NOT NULL,
--  Position TEXT NOT NULL,
--  Phone_number TEXT NOT NULL,
--  Email_address TEXT NOT NULL
--);

--CREATE TABLE menu_items (
--  Menu_item_id INTEGER PRIMARY KEY,
--  Name TEXT NOT NULL,
--  Price REAL NOT NULL
--);

--CREATE TABLE drinks (
--  Drink_id INTEGER PRIMARY KEY,
--  Name TEXT NOT NULL,
--  Price REAL NOT NULL
--);

--CREATE TABLE ingredients (
--  Ingredient_id INTEGER PRIMARY KEY,
--  Ingredient_name TEXT NOT NULL,
--  Quantity REAL NOT NULL
--);

--CREATE TABLE recipes (
--  Recipe_id INTEGER PRIMARY KEY,
--  Menu_item_id INTEGER NOT NULL,
--  Ingredient_id INTEGER NOT NULL,
--  Quantity REAL NOT NULL,
--  FOREIGN KEY (menu_item_id) REFERENCES menu_items (menu_item_id),
--  FOREIGN KEY (ingredient_id) REFERENCES ingredients (ingredient_id)
--);



--CREATE TABLE bills (
--  Bill_id INTEGER PRIMARY KEY,
--  Customer_id INTEGER NOT NULL,
--  Employee_id INTEGER NOT NULL,
--  Total_amount REAL NOT NULL,
--  FOREIGN KEY (customer_id) REFERENCES customers (customer_id),
--  FOREIGN KEY (employee_id) REFERENCES employees (employee_id)
--);

--CREATE TABLE spendings (
--  Spending_id INTEGER PRIMARY KEY,
--  Employee_id INTEGER NOT NULL,
--  Ingredient_id INTEGER NOT NULL,
--  Quantity REAL NOT NULL,
--  Date DATE NOT NULL,
--  FOREIGN KEY (employee_id) REFERENCES employees (employee_id),
--  FOREIGN KEY (ingredient_id) REFERENCES ingredients (ingredient_id)
--);

--CREATE TABLE orders (
--  Order_id INTEGER PRIMARY KEY,
--  Bill_id INTEGER NOT NULL,
--  Item_id INTEGER NOT NULL,
--  Item_type VARCHAR NOT NULL,
--  Quantity INTEGER NOT NULL,
--  FOREIGN KEY (bill_id) REFERENCES bills (bill_id),
--  CHECK (item_type IN ('menu_item', 'drink'))
--);
--CREATE TABLE employees_bills (
--  Employee_id INTEGER NOT NULL,
--  Bill_id INTEGER NOT NULL,
--  FOREIGN KEY (employee_id) REFERENCES employees (employee_id),
--  FOREIGN KEY (bill_id) REFERENCES bills (bill_id),
--  PRIMARY KEY (employee_id, bill_id)
--);
--INSERT INTO customers (Customer_id, Name, Phone_number, Email_address) VALUES (1, 'John Smith', '555-555-5555', 'johnsmith@email.com');
--INSERT INTO customers (Customer_id, Name, Phone_number, Email_address) VALUES (2, 'Jane Doe', '555-555-5556', 'janedoe@email.com');
--INSERT INTO customers (Customer_id, Name, Phone_number, Email_address) VALUES (3, 'Bob Johnson', '555-555-5557', 'bobjohnson@email.com');
--INSERT INTO customers (Customer_id, Name, Phone_number, Email_address) VALUES (4, 'Samantha Williams', '555-555-5558', 'samanthawilliams@email.com');
--INSERT INTO customers (Customer_id, Name, Phone_number, Email_address) VALUES (5, 'Michael Brown', '555-555-5559', 'michaelbrown@email.com');
--INSERT INTO customers (Customer_id, Name, Phone_number, Email_address) VALUES (6, 'Emily Davis', '555-555-5560', 'emilydavis@email.com');

--INSERT INTO tables (Table_id, Number, Capacity, Customer_id) VALUES (1, 1, 2, 1);
--INSERT INTO tables (Table_id, Number, Capacity, Customer_id) VALUES (2, 2, 4, 2);
--INSERT INTO tables (Table_id, Number, Capacity, Customer_id) VALUES (3, 3, 6, 3);
--INSERT INTO tables (Table_id, Number, Capacity, Customer_id) VALUES (4, 4, 8, 4);
--INSERT INTO tables (Table_id, Number, Capacity, Customer_id) VALUES (5, 5, 10, 5);
--INSERT INTO tables (Table_id, Number, Capacity, Customer_id) VALUES (6, 6, 12, 6);

--INSERT INTO customers_sit_at (Customer_id, Table_id) VALUES (1, 1);
--INSERT INTO customers_sit_at (Customer_id, Table_id) VALUES (2, 2);
--INSERT INTO customers_sit_at (Customer_id, Table_id) VALUES (3, 3);
--INSERT INTO customers_sit_at (Customer_id, Table_id) VALUES (4, 4);
--INSERT INTO customers_sit_at (Customer_id, Table_id) VALUES (5, 5);
--INSERT INTO customers_sit_at (Customer_id, Table_id) VALUES (6, 6);

--INSERT INTO employees (Employee_id, Name, Position, Phone_number, Email_address) VALUES (1, 'John Doe', 'Manager', '555-555-5561','johndoe@bar.com');

--INSERT INTO employees (Employee_id, Name, Position, Phone_number, Email_address) VALUES (2, 'Jane Davis', 'Server', '555-555-5562', 'janedavis@bar.com');
--INSERT INTO employees (Employee_id, Name, Position, Phone_number, Email_address) VALUES (3, 'Mike Smith', 'Bartender', '555-555-5563', 'mikesmith@bar.com');
--INSERT INTO employees (Employee_id, Name, Position, Phone_number, Email_address) VALUES (4, 'Emily Taylor', 'Server', '555-555-5564', 'emilytaylor@bar.com');
--INSERT INTO employees (Employee_id, Name, Position, Phone_number, Email_address) VALUES (5, 'David Wilson', 'Bartender', '555-555-5565', 'davidwilson@bar.com');
--INSERT INTO employees (Employee_id, Name, Position, Phone_number, Email_address) VALUES (6, 'Sarah Johnson', 'Manager', '555-555-5566', 'sarahjohnson@bar.com');

--INSERT INTO menu_items (Menu_item_id, Name, Price) VALUES (1, 'Pina Colada', 10.99);
--INSERT INTO menu_items (Menu_item_id, Name, Price) VALUES (2, 'Cuba Libre', 8.99);
--INSERT INTO menu_items (Menu_item_id, Name, Price) VALUES (3, 'Camicaze Shot', 5.99);
--INSERT INTO menu_items (Menu_item_id, Name, Price) VALUES (4, 'Long Island Iced Tea', 12.99);
--INSERT INTO menu_items (Menu_item_id, Name, Price) VALUES (5, 'Margarita', 9.99);
--INSERT INTO menu_items (Menu_item_id, Name, Price) VALUES (6, 'Whiskey Sour', 11.99);

--INSERT INTO drinks (Drink_id, Name, Price) VALUES (1, 'Rum', 4.99);
--INSERT INTO drinks (Drink_id, Name, Price) VALUES (2, 'Tequila', 5.99);
--INSERT INTO drinks (Drink_id, Name, Price) VALUES (3, 'Gin', 6.99);
--INSERT INTO drinks (Drink_id, Name, Price) VALUES (4, 'Vodka', 7.99);
--INSERT INTO drinks (Drink_id, Name, Price) VALUES (5, 'Whiskey', 8.99);

--INSERT INTO ingredients (Ingredient_id, Ingredient_name, Quantity) VALUES (1, 'Whiskey', 10);
--INSERT INTO ingredients (Ingredient_id, Ingredient_name, Quantity) VALUES (2, 'Ice', 100);
--INSERT INTO ingredients (Ingredient_id, Ingredient_name, Quantity) VALUES (3, 'Lemon Juice', 50);
--INSERT INTO ingredients (Ingredient_id, Ingredient_name, Quantity) VALUES (4, 'Coca-cola', 200);
--INSERT INTO ingredients (Ingredient_id, Ingredient_name, Quantity) VALUES (5, 'Rum', 30);

--INSERT INTO recipes (Recipe_id, Menu_item_id, Ingredient_id, Quantity) VALUES (1, 1, 1, 2);
--INSERT INTO recipes (Recipe_id, Menu_item_id, Ingredient_id, Quantity) VALUES (2, 1, 2, 3);
--INSERT INTO recipes (Recipe_id, Menu_item_id, Ingredient_id, Quantity) VALUES (3, 2, 5, 2);
--INSERT INTO recipes (Recipe_id, Menu_item_id, Ingredient_id, Quantity) VALUES (4, 2, 4, 1);
--INSERT INTO recipes (Recipe_id, Menu_item_id, Ingredient_id, Quantity) VALUES (5, 2, 3, 0.5);

--INSERT INTO orders (Order_id, Bill_id, Item_id, Item_type, Quantity) VALUES (1, 1, 1, 'd', 2);
--INSERT INTO orders (Order_id, Bill_id, Item_id, Item_type, Quantity) VALUES (2, 1, 2, 'd', 1);
--INSERT INTO orders (Order_id, Bill_id, Item_id, Item_type, Quantity) VALUES (3, 2, 3, 'd', 3);
--INSERT INTO orders (Order_id, Bill_id, Item_id, Item_type, Quantity) VALUES (4, 2, 4, 'd', 2);
--INSERT INTO orders (Order_id, Bill_id, Item_id, Item_type, Quantity) VALUES (5, 3, 5, 'd', 1);

--INSERT INTO spendings (Spending_id, Employee_id, Ingredient_id, Quantity, Date) VALUES (1, 1, 1, 2, '2022-01-01');
--INSERT INTO employees_bills (Employee_id, Bill_id) VALUES (1, 1), (1, 2), (2, 3);
--INSERT INTO customers_sit_at (Customer_id, Table_id) VALUES (1, 1), (2, 2), (3, 3);
--SELECT * FROM recipes;
--SELECT * FROM drinks;
--SELECT * FROM ingredients;
--SELECT * FROM employees_bills;
--SELECT * FROM spendings;
--SELECT * FROM bills;
--SELECT * FROM orders;
--SELECT * FROM menu_items;
--SELECT * FROM employees;
--SELECT * FROM customers_sit_at;
--SELECT * FROM tables;
--SELECT * FROM customers;
--INSERT INTO bills (Bill_id, Customer_id, Employee_id, Total_amount) VALUES (1, 1, 1, 50.99);
--INSERT INTO bills (Bill_id, Customer_id, Employee_id, Total_amount) VALUES (2, 2, 2, 35.99);
--INSERT INTO bills (Bill_id, Customer_id, Employee_id, Total_amount) VALUES (3, 3, 3, 40.99);
--INSERT INTO bills (Bill_id, Customer_id, Employee_id, Total_amount) VALUES (4, 4, 4, 45.99);
--INSERT INTO bills (Bill_id, Customer_id, Employee_id, Total_amount) VALUES (5, 5, 5, 55.99);

--ALTER TABLE orders
--ALTER COLUMN Item_type VARCHAR(1) NOT NULL;

--ALTER TABLE orders
--ADD CONSTRAINT check_item_type CHECK (Item_type IN ('m', 'd'));
--INSERT INTO orders (Order_id, Bill_id, Item_id, Item_type, Quantity) VALUES (1, 1, 1, 'm', 2);
--INSERT INTO orders (Order_id, Bill_id, Item_id, Item_type, Quantity) VALUES (2, 2, 2, 'd', 3);
--INSERT INTO orders (Order_id, Bill_id, Item_id, Item_type, Quantity) VALUES (3, 3, 3, 'm', 1);
--INSERT INTO orders (Order_id, Bill_id, Item_id, Item_type, Quantity) VALUES (4, 4, 4, 'd', 2);
--INSERT INTO orders (Order_id, Bill_id, Item_id, Item_type, Quantity) VALUES (5, 5, 5, 'm', 4);


--ALTER TABLE orders
--DROP CONSTRAINT check_item_type;
--ALTER TABLE orders
--ADD CONSTRAINT check_item_type CHECK (Item_type IN ('m', 'd', 'drink', 'menu_item'));
--ALTER TABLE orders DROP CONSTRAINT CK__orders__Item_typ__412EB0B6;
--ALTER TABLE orders ADD CONSTRAINT check_item_type CHECK (Item_type IN ('m', 'd'));
--INSERT INTO employees_bills (Employee_id, Bill_id) VALUES (1, 1);
--INSERT INTO employees_bills (Employee_id, Bill_id) VALUES (2, 2);
--INSERT INTO employees_bills (Employee_id, Bill_id) VALUES (3, 3);
--INSERT INTO employees_bills (Employee_id, Bill_id) VALUES (4, 4);
--INSERT INTO employees_bills (Employee_id, Bill_id) VALUES (5, 5);

--INSERT INTO spendings (Spending_id, Employee_id, Ingredient_id, Quantity, Date)
--VALUES (2, 2, 2, 20, '2022-11-15');
--INSERT INTO spendings (Spending_id, Employee_id, Ingredient_id, Quantity, Date)
--VALUES (3, 3, 3, 15, '2022-10-31');
--INSERT INTO spendings (Spending_id, Employee_id, Ingredient_id, Quantity, Date)
--VALUES (4, 4, 4, 5, '2022-09-22');
--INSERT INTO spendings (Spending_id, Employee_id, Ingredient_id, Quantity, Date)
--VALUES (5, 5, 5, 25, '2022-08-01');

--SELECT SUM(b.Total_amount)
--FROM bills b
--JOIN orders o ON b.Bill_id = o.Bill_id
--WHERE o.Item_type = 'd'

--SELECT c.Name
--FROM customers c
--JOIN bills b ON c.Customer_id = b.Customer_id
--WHERE b.Total_amount > 20

--ALTER TABLE ingredients ALTER COLUMN Ingredient_name VARCHAR(255) NOT NULL;

--SELECT mi.Name, mi.Price
--FROM menu_items mi
--JOIN recipes r ON mi.Menu_item_id = r.Menu_item_id
--JOIN ingredients i ON r.Ingredient_id = i.Ingredient_id
--WHERE i.Ingredient_name = 'Coconut'

--SELECT e.Name
--FROM employees e
--JOIN spendings s ON e.Employee_id = s.Employee_id
--JOIN ingredients i ON s.Ingredient_id = i.Ingredient_id
--WHERE i.Ingredient_name = 'Rum' AND s.Quantity > 10

--SELECT e.Name
--FROM employees e
--JOIN employees_bills eb ON e.Employee_id = eb.Employee_id
--JOIN bills b ON eb.Bill_id = b.Bill_id
--JOIN customers_sit_at cs ON b.Customer_id = cs.Customer_id
--JOIN customers c ON cs.Customer_id = c.Customer_id
--WHERE CAST(c.Name AS VARCHAR(255)) = 'John Smith'

--ALTER TABLE spendings 
--ADD CONSTRAINT chk_quantity CHECK (Quantity > 0);

--CREATE VIEW customer_spendings
--AS
--SELECT CAST(c.Name AS VARCHAR(255)) AS Customer_name, SUM(b.Total_amount) AS Total_spent
--FROM customers c
--JOIN bills b ON c.Customer_id = b.Customer_id
--GROUP BY CAST(c.Name AS VARCHAR(255));

--CREATE VIEW employee_sales AS
--SELECT CAST(e.Name AS VARCHAR(255)) AS Employee_name, SUM(b.Total_amount) AS Total_sales
--FROM employees e
--JOIN employees_bills eb ON e.Employee_id = eb.Employee_id
--JOIN bills b ON eb.Bill_id = b.Bill_id
--GROUP BY CAST(e.Name AS VARCHAR(255));

--ALTER TABLE customers
--ALTER COLUMN Email_address VARCHAR(255) NOT NULL;

--ALTER TABLE customers 
--ADD CONSTRAINT uc_email UNIQUE (Email_address);

--CREATE FUNCTION calculate_bill_total(@bill_id INTEGER)
--RETURNS REAL
--AS
--BEGIN
--  DECLARE @total REAL;
  
--  SELECT @total = SUM(Quantity * Price) 
--  FROM orders 
--  JOIN menu_items ON orders.Item_id = menu_items.Menu_item_id 
--  WHERE orders.Bill_id = @bill_id;
  
--  SELECT @total = @total + SUM(Quantity * Price) 
--  FROM orders 
--  JOIN drinks ON orders.Item_id = drinks.Drink_id 
--  WHERE orders.Bill_id = @bill_id;
  
--  RETURN @total;
--END;

--SELECT dbo.calculate_bill_total(1)

--CREATE TRIGGER update_bill_total
--ON orders
--AFTER INSERT, UPDATE
--AS
--BEGIN
--    UPDATE bills
--    SET Total_amount = Total_amount + (i.Quantity * (SELECT Price FROM menu_items WHERE Menu_item_id = i.Item_id))
--    FROM inserted i
--    INNER JOIN bills b ON i.Bill_id = b.Bill_id
--END

--CREATE TRIGGER update_ingredient_total
--ON spendings
--AFTER INSERT, UPDATE
--AS
--BEGIN
--    UPDATE ingredients
--    SET Quantity = Quantity + (SELECT SUM(Quantity) FROM inserted)
--    WHERE Ingredient_id = (SELECT Ingredient_id FROM inserted)
--END

--SELECT Ingredient_name
--FROM ingredients
--WHERE Quantity <= 0

--SELECT i.Ingredient_name, SUM(s.Quantity) as Total_Spending
--FROM ingredients i
--JOIN spendings s ON i.Ingredient_id = s.Ingredient_id
--GROUP BY i.Ingredient_name

--SELECT TOP 1 mi.Name, SUM(o.Quantity) as Quantity_sold
--FROM (SELECT CONVERT(VARCHAR(255), mi.Name) AS Name, mi.Menu_item_id FROM menu_items mi) mi
--JOIN orders o ON mi.Menu_item_id = o.Item_id
--GROUP BY mi.Name
--ORDER BY Quantity_sold DESC

--SELECT TOP 5 Name, Price FROM menu_items
--ORDER BY Price DESC;

--SELECT Name, Email_address
--FROM customers
--WHERE Customer_id IN (SELECT Customer_id FROM bills WHERE Total_amount > 100);

--CREATE PROCEDURE update_menu_item_prices (@percentage REAL)
--AS
--BEGIN
--  UPDATE menu_items SET Price = Price * (1 + @percentage);
--END

--EXEC update_menu_item_prices @percentage = 0.1;

--CREATE PROCEDURE get_out_of_stock_items
--AS
--BEGIN
--  SELECT Item_id, Quantity FROM Inventory WHERE Quantity <= 0;
--END;

--CREATE PROCEDURE get_monthly_spending (@month INT, @year INT)
--AS
--BEGIN
--  DECLARE @total REAL;

--  SELECT @total = SUM(spendings.Quantity * menu_items.Price)
--  FROM spendings
--  JOIN ingredients ON spendings.Ingredient_id = ingredients.Ingredient_id
--  JOIN recipes ON spendings.Ingredient_id = recipes.Ingredient_id
--  JOIN menu_items ON recipes.Menu_item_id = menu_items.Menu_item_id
--  WHERE MONTH(Date) = @month AND YEAR(Date) = @year;

--  SELECT @total;
--END;








