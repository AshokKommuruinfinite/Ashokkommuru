create table Customers(
 CustID INT PRIMARY KEY,
 CustName VARCHAR(100),
 Email VARCHAR(200),
 City VARCHAR(100))

INSERT INTO Customers (CustID, CustName, Email, City) VALUES
(1, 'Amit Sharma', 'amit.sharma@gmail.com', 'Mumbai'),
(2, 'Ravi Kumar', 'ravi.kumar@yahoo.com', 'Delhi'),
(3, 'Priya Singh', 'priya.singh@gmail.com', 'Pune'),
(4, 'John Mathew', 'john.mathew@hotmail.com', 'Bangalore'),
(5, 'Sara Thomas', 'sara.thomas@gmail.com', 'Kochi'),
(6, 'Nidhi Jain', 'nidhi.jain@gmail.com', NULL);

create table Products(
 ProductID INT PRIMARY KEY,
 ProductName VARCHAR(100),
 Price DECIMAL(10,2),
 Stock INT CHECK(Stock >= 0));

INSERT INTO Products (ProductID, ProductName, Price, Stock) VALUES
(101, 'Laptop Pro 14', 75000, 15),
(102, 'Laptop Air 13', 55000, 8),
(103, 'Wireless Mouse', 800, 50),
(104, 'Mechanical Keyboard', 3000, 20),
(105, 'USB-C Charger', 1200, 5),
(106, '27-inch Monitor', 18000, 10),
(107, 'Pen Drive 64GB', 600, 80);


create table Orders(
 OrderID INT PRIMARY KEY,
 CustID INT FOREIGN KEY REFERENCES Customers(CustID),
 OrderDate DATE,
 Status VARCHAR(20))


INSERT INTO Orders (OrderID, CustID, OrderDate, Status) VALUES
(5001, 1, '2025-01-05', 'Pending'),
(5002, 2, '2025-01-10', 'Completed'),
(5003, 1, '2025-01-20', 'Completed'),
(5004, 3, '2025-02-01', 'Pending'),
(5005, 4, '2025-02-15', 'Completed'),
(5006, 5, '2025-02-18', 'Pending');
 

 create table OrderDetails(
 DetailID INT PRIMARY KEY,
 OrderID INT FOREIGN KEY REFERENCES Orders(OrderID),
 ProductID INT FOREIGN KEY REFERENCES Products(ProductID),
 Qty INT CHECK(Qty > 0))

 INSERT INTO OrderDetails (DetailID, OrderID, ProductID, Qty) VALUES
(9001, 5001, 101, 1),
(9002, 5001, 103, 2),
 
(9003, 5002, 104, 1),
(9004, 5002, 103, 1),
 
(9005, 5003, 102, 1),
(9006, 5003, 105, 1),
(9007, 5003, 103, 3),
 
(9008, 5004, 106, 1),
 
(9009, 5005, 107, 4),
(9010, 5005, 104, 1),
 
(9011, 5006, 101, 1),
(9012, 5006, 107, 2);

create table Payments(
 PaymentID INT PRIMARY KEY,
 OrderID INT FOREIGN KEY REFERENCES Orders(OrderID),
 Amount DECIMAL(10,2),
 PaymentDate DATE
)

INSERT INTO Payments (PaymentID, OrderID, Amount, PaymentDate) VALUES
(7001, 5002, 3300, '2025-01-11'),
(7002, 5003, 62000, '2025-01-22'),
(7003, 5005, 4500, '2025-02-16');

--Q1.List customers who placed an order in the last 30 days
select c.custname from customers c
join orders o on c.custid = o.custid where o.orderdate >= dateadd(day, -30, getdate());

--Q2. Display top 3 products that generated the highest total sales amount
select top 3 p.productname, sum(od.qty * p.price) as totalamount from products p
join orderdetails od on p.productid = od.productid group by p.productname order by totalamount desc;

--Q3. For each city, show number of customers and total order count.
select c.city,count(distinct c.custid) as customercount,count(o.orderid) as ordercount from customers c
left join orders o on c.custid = o.custid group by c.city;

--Q4. Retrieve orders that contain more than 2 different products.
select od.orderid, count(distinct od.productid) as productcount from orderdetails od
group by od.orderid having count(distinct od.productid) > 2;

--Q5. Show orders where total payable amount is greater than 10,000.
select o.orderid, sum(od.qty * p.price) as ordertotal from orders o
join orderdetails od on o.orderid = od.orderid
join products p on od.productid = p.productid
group by o.orderid having sum(od.qty * p.price) > 10000;

--Q6. List customers who ordered the same product more than once.
select c.custname, p.productname from customers c
join orders o on c.custid = o.custid
join orderdetails od on o.orderid = od.orderid
join products p on od.productid = p.productid
group by c.custname, p.productname having count(*) > 1;

--Q7. Display employee-wise order processing details
select o.employeeid,count(o.orderid) as totalorders,
sum(case when o.status = 'completed' then 1 else 0 end) as completedorders,
sum(case when o.status = 'pending' then 1 else 0 end) as pendingorders
from orders o group by o.employeeid;

------VIEWS-----------------------------VIEWS---------------------------------VIEWS--------------------
--1. Create a view vw_LowStockProducts
--Show only products with stock < 5.
--View should be WITH SCHEMABINDING and Encrypted

create view dbo.vw_lowstockproducts with schemabinding, encryption as
select p.productid,p.productname,p.stock from dbo.products as p where p.stock < 5;
select * from dbo.vw_lowstockproducts;

----Functions------------------------Functions---------------------------------------Functions--------------------------
--1. Create a table-valued function: fn_GetCustomerOrderHistory(@CustID)

create function fn_getcustomerorderhistory (@custid int) returns table as
return
(
    select o.orderid, o.orderdate, sum(od.qty * p.price) as totalamount
    from orders o
    join orderdetails od on o.orderid = od.orderid
    join products p on od.productid = p.productid
    where o.custid = @custid
    group by o.orderid, o.orderdate
);
select * from fn_getcustomerorderhistory(1);


--2. Create a function fn_GetCustomerLevel(@CustID)
--Logic:
--• Total purchase > 1,00,000 → "Platinum"
--• 50,000–1,00,000 → "Gold"
--• Else → "Silver"
create function fn_getcustomerlevel (@custid int)returns varchar(20) as
begin
declare @total decimal(18,2);
select @total = sum(od.qty * p.price) from orders o
join orderdetails od on o.orderid = od.orderid
join products p on od.productid = p.productid where o.custid = @custid;
if @total > 100000 return 'platinum';
if @total >= 50000 return 'gold';
return 'silver';
end;

select custid, custname, dbo.fn_getcustomerlevel(custid) as level
from customers;

---Procedures----------------------------Procedures----------------------Procedures------------------------
--1. Create a stored procedure to update product price
--Rules:
--• Old price must be logged in a PriceHistory table
--• New price must be > 0
--• If invalid, throw custom error.
create table pricehistory (
    historyid int identity(1,1) primary key,
    productid int,
    oldprice decimal(10,2),
    changedon datetime default getdate()
);

create procedure sp_updateprice
    @productid int,
    @newprice decimal(10,2)
as
begin
if @newprice <= 0
    raiserror('new price must be greater than zero', 16, 1);
else if not exists (select 1 from products where productid = @productid)
    raiserror('invalid product id', 16, 1);
else
    update products set price = @newprice where productid = @productid;
end;

sp_updateprice @productid = 101, @newprice = 80000;

--2. Create a procedure sp_SearchOrders
--Search orders by:
--• Customer Name
--• City
--• Product Name
--• Date range
--Any parameter can be NULL → Dynamic WHERE

create  procedure dbo.sp_searchorders
    @customername nvarchar(100) = null,
    @city         nvarchar(100) = null,
    @productname  nvarchar(100) = null,
    @startdate    date = null,
    @enddate      date = null
as
begin
select o.orderid,o.orderdate,c.custname,c.city,p.productname,od.qty,p.price,od.qty * p.price as lineamount from orders o
inner join customers c     on c.custid   = o.custid
inner join orderdetails od on od.orderid = o.orderid
inner join products p      on p.productid = od.productid
where(@customername is null or c.custname like '%' + @customername + '%')
and (@city        is null or c.city      like '%' + @city        + '%')
and (@productname is null or p.productname like '%' + @productname + '%')
and (@startdate   is null or o.orderdate >= @startdate)
and (@enddate     is null or o.orderdate <= @enddate)
order by o.orderdate desc, o.orderid, p.productname;
end;
go

dbo.sp_searchorders @customername = 'Ravi kumar';
dbo.sp_searchorders @city = 'delhi';
dbo.sp_searchorders @productname = 'Laptop Pro 14';



--Triggers----------------------------Triggers--------------------------Triggers--------------
--1. Create a trigger on Products
--Prevent deletion of a product if it is part of any OrderDetails.

create trigger dbo.trg_products
on dbo.products
instead of delete
as
begin
if exists (select 1 from deleted as d inner join dbo.orderdetails as od on od.productid = d.productid)
begin
throw 50010, 'cannot delete product(s): referenced in orderdetails.', 1;
return;
end

delete p from dbo.products as p inner join deleted as d on d.productid = p.productid;
end;

--2. Create an AFTER UPDATE trigger on Payments
--Log old and new payment values into a PaymentAudit table.

create table dbo.paymentaudit
(
    paymentid       int not null,
    oldamount       decimal(10,2) null,
    newamount       decimal(10,2) null,
    oldpaymentdate  date null,
    newpaymentdate  date null
);

create  trigger dbo.trg_payments_audit on dbo.payments after update
as
begin
insert into dbo.paymentaudit(paymentid,oldamount, newamount,oldpaymentdate, newpaymentdate)
select d.paymentid,d.amount, i.amount,d.paymentdate, i.paymentdate from deleted as d
inner join inserted as i on i.paymentid = d.paymentid;
end;
go


update dbo.payments
set amount = amount + 100, paymentdate = dateadd(day, 1, paymentdate)
where paymentid = 7002;

select * from dbo.paymentaudit;

--3. Create an INSTEAD OF DELETE trigger on Customers
--Logic:
--• If customer has orders → mark status as “Inactive” instead of deleting
--• If no orders → allow deletion
create or alter trigger trg_customers
on customers
instead of delete
as
begin update customers set status = 'inactive' where custid in (select d.custid from deleted d where exists (select 1 from orders o where o.custid = d.custid));
delete from customers where custid in (select d.custid from deleted d where not exists (select 1 from orders o where o.custid = d.custid));
end;
go

delete from customers where custid = 1;

insert into customers(custid, custname, email, city) values(9999,'temp','temp@mail.com','hyderabad');
select * from orders where custid = 9999;
delete from customers where custid = 9999;

