use StoreSample;
GO
/****** Object:  StoredProcedure [dbo].[sp_GetSalesDatePrediction]    Script Date: 5/02/2025 10:35:12 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Mateo Renteria Lujan
-- Create date: 12-08-2024
-- Version:		1.0.5
-- Description:	Procedimiento almacenado para obtener las ordenes de los clientes y predecir cuando va a realizar una nueva orden
-- =============================================
ALTER PROCEDURE [dbo].[sp_GetSalesDatePrediction] AS BEGIN	
	WITH Diffs AS (
		SELECT 
			custid,
			orderdate,
			LAG(orderdate) OVER (PARTITION BY custid ORDER BY orderdate) AS BeforeDate
		FROM 
			[Sales].Orders
	)
	SELECT 
		d.custid,
		[CustomerName] = CONCAT(MAX(c.companyname), ' - ', MAX(c.contactname)),
		[LastOrderDate] = MAX(d.orderdate),
		[NextPredictedOrder] = DATEADD(DAY, AVG(DATEDIFF(DAY, BeforeDate, orderdate)), MAX(d.orderdate))
	FROM 
		Diffs d
			INNER JOIN [Sales].Customers c ON d.custid = c.custid
	WHERE 
		BeforeDate IS NOT NULL
	GROUP BY 
		d.custid;
END


/****** Object:  StoredProcedure [dbo].[sp_AddOrderWithDetails]    Script Date: 5/02/2025 11:20:45 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Mateo Renteria Lujan
-- Create date: 12-08-2024
-- Version:		1.0.1
-- Description:	Procedimiento almacenado para crear una orden con sus respectivos detalles
-- =============================================
--CREATE PROCEDURE [dbo].[sp_AddOrderWithDetails](
declare
	@Empid INT = 1,
	@Shipperid INT = 1,
	@Shipname NVARCHAR(80) = '1',
	@Shipaddress NVARCHAR(120) = '1',
	@Shipcity NVARCHAR(30) = '1', 
	@Orderdate DATETIME = getdate,
	@Requireddate DATETIME = getdate,
	@Shippeddate DATETIME = getdate,
	@Freight MONEY = 1,
	@Shipcountry NVARCHAR(30) = '1',
	@DetailsJson NVARCHAR(MAX) = N'[{"Orderid":1,"Productid":101,"Unitprice":25.5,"Qty":2,"Discount":0.1},{"Orderid":2,"Productid":102,"Unitprice":15.75,"Qty":3,"Discount":0.05},{"Orderid":3,"Productid":103,"Unitprice":30,"Qty":1,"Discount":0.15},{"Orderid":4,"Productid":104,"Unitprice":22.25,"Qty":4,"Discount":0.2},{"Orderid":5,"Productid":105,"Unitprice":18,"Qty":5,"Discount":0.1},{"Orderid":6,"Productid":106,"Unitprice":12.5,"Qty":2,"Discount":0.25},{"Orderid":7,"Productid":107,"Unitprice":27,"Qty":3,"Discount":0.05},{"Orderid":8,"Productid":108,"Unitprice":35,"Qty":1,"Discount":0.15},{"Orderid":9,"Productid":109,"Unitprice":20,"Qty":4,"Discount":0.2},{"Orderid":10,"Productid":110,"Unitprice":14.25,"Qty":5,"Discount":0.1}]';
--) AS BEGIN	

	DROP TABLE IF EXISTS #TempOrderDetails
	CREATE TABLE #TempOrderDetails (		
		Productid INT NOT NULL,
		Unitprice DECIMAL(10, 2) NOT NULL,
		Qty INT NOT NULL,
		Discount DECIMAL(5, 2) NOT NULL
	);

	INSERT INTO #TempOrderDetails (Productid, Unitprice, Qty, Discount)
	SELECT Productid, Unitprice, Qty, Discount
	FROM OPENJSON(@DetailsJson)
	WITH (
		Productid INT,
		Unitprice DECIMAL(10, 2),
		Qty INT,
		Discount DECIMAL(5, 2)
	) AS _OrderDetailsData; 

	DECLARE @TB_ORDER_ID TABLE ( id INT );
	INSERT INTO [Sales].Orders(empid, shipperid, shipname, shipaddress, shipcity, orderdate, requireddate, shippeddate, freight, shipcountry)
	OUTPUT inserted.orderid INTO @TB_ORDER_ID
	VALUES (@Empid, @Shipperid, @Shipname, @Shipaddress, @Shipcity, @Orderdate, @Requireddate, @Shippeddate, @Freight, @Shipcountry);

	DECLARE @OrderID INT = (SELECT top 1 id FROM @TB_ORDER_ID);

	INSERT INTO Sales.OrderDetails(orderid, productid, unitprice, qty, discount)
	SELECT @OrderID, Productid, Unitprice, Qty, Discount FROM #TempOrderDetails;

	
END


--DECLARE @DetailsJson NVARCHAR(MAX) = N'[{"Orderid":1,"Productid":101,"Unitprice":25.5,"Qty":2,"Discount":0.1},{"Orderid":2,"Productid":102,"Unitprice":15.75,"Qty":3,"Discount":0.05},{"Orderid":3,"Productid":103,"Unitprice":30,"Qty":1,"Discount":0.15},{"Orderid":4,"Productid":104,"Unitprice":22.25,"Qty":4,"Discount":0.2},{"Orderid":5,"Productid":105,"Unitprice":18,"Qty":5,"Discount":0.1},{"Orderid":6,"Productid":106,"Unitprice":12.5,"Qty":2,"Discount":0.25},{"Orderid":7,"Productid":107,"Unitprice":27,"Qty":3,"Discount":0.05},{"Orderid":8,"Productid":108,"Unitprice":35,"Qty":1,"Discount":0.15},{"Orderid":9,"Productid":109,"Unitprice":20,"Qty":4,"Discount":0.2},{"Orderid":10,"Productid":110,"Unitprice":14.25,"Qty":5,"Discount":0.1}]'


[dbo].[sp_GetSalesDatePrediction]


[dbo].[sp_AddOrderWithDetails] @Empid=1,
	@Shipperid=1,
	@Shipname='1',
	@Shipaddress='1',
	@Shipcity='1',
	@Orderdate=getdate,
	@Requireddate=getdate,
	@Shippeddate=getdate,
	@Freight=1,
	@Shipcountry='1',
	@DetailsJson=  N'[{"Orderid":1,"Productid":101,"Unitprice":25.5,"Qty":2,"Discount":0.1},{"Orderid":2,"Productid":102,"Unitprice":15.75,"Qty":3,"Discount":0.05},{"Orderid":3,"Productid":103,"Unitprice":30,"Qty":1,"Discount":0.15},{"Orderid":4,"Productid":104,"Unitprice":22.25,"Qty":4,"Discount":0.2},{"Orderid":5,"Productid":105,"Unitprice":18,"Qty":5,"Discount":0.1},{"Orderid":6,"Productid":106,"Unitprice":12.5,"Qty":2,"Discount":0.25},{"Orderid":7,"Productid":107,"Unitprice":27,"Qty":3,"Discount":0.05},{"Orderid":8,"Productid":108,"Unitprice":35,"Qty":1,"Discount":0.15},{"Orderid":9,"Productid":109,"Unitprice":20,"Qty":4,"Discount":0.2},{"Orderid":10,"Productid":110,"Unitprice":14.25,"Qty":5,"Discount":0.1}]';

