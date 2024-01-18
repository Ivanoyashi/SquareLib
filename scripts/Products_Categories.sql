-- В базе данных MS SQL Server есть продукты и категории. 
-- Одному продукту может соответствовать много категорий, 
-- в одной категории может быть много продуктов. 
-- Напишите SQL запрос для выбора всех пар «Имя продукта – Имя категории». 
-- Если у продукта нет категорий, то его имя все равно должно выводиться.

CREATE TABLE Categories (
	Id BIGINT PRIMARY KEY identity (1, 1),
	"Name" NVARCHAR(256) NOT NULL
);

CREATE TABLE Products (
	Id BIGINT PRIMARY KEY identity (1, 1),
	"Name" NVARCHAR(256) NOT NULL
);

CREATE TABLE ProductCategories (
	Id BIGINT PRIMARY KEY identity (1, 1),
	CategoryId BIGINT FOREIGN KEY REFERENCES Categories(Id),
	ProductId BIGINT FOREIGN KEY REFERENCES Products(Id),
);

INSERT INTO Categories
VALUES
    ('Gaming'),
    ('Laptops'),
    ('Smartphones');

INSERT INTO Products
VALUES
    ('MSI Modern 15'),
    ('Table'),
    ('Samsung Galaxy S23'),
    ('Samsung Galaxy A50');

insert into ProductCategories
	([ProductId],[CategoryId])
VALUES
  (1,1),
  (1,2),
  (3,3),
  (4,3);

SELECT P."Name" AS "Название продукта", C."Name" AS "Категория"
FROM Products P
LEFT JOIN ProductCategories PC
	ON P.Id = PC.ProductId
LEFT JOIN Categories C
	ON PC.CategoryId = C.Id;
