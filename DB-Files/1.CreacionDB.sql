--SCRIPT DATABASE 
USE [dbo_Customers]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 8/19/2015 9:53:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Address](
	[AddressID] [int] NOT NULL,
	[Address1] [varchar](60) NULL,
	[Address2] [varchar](60) NULL,
	[City] [varchar](30) NULL,
	[Province] [nvarchar](50) NULL,
	[Country] [nvarchar](50) NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[AddressID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CustomerAddress]    Script Date: 8/19/2015 9:53:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerAddress](
	[CustomerID] [int] NOT NULL,
	[AddressID] [int] NOT NULL,
 CONSTRAINT [PK_CustomerAddress] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC,
	[AddressID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Customers]    Script Date: 8/19/2015 9:53:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerID] [int] NOT NULL,
	[FistName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[PersonType] [nchar](2) NULL,
	[StoreName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[CustomerAddress]  WITH CHECK ADD  CONSTRAINT [FK_CustomerAddress_Address] FOREIGN KEY([AddressID])
REFERENCES [dbo].[Address] ([AddressID])
GO
ALTER TABLE [dbo].[CustomerAddress] CHECK CONSTRAINT [FK_CustomerAddress_Address]
GO
ALTER TABLE [dbo].[CustomerAddress]  WITH CHECK ADD  CONSTRAINT [FK_CustomerAddress_Customers] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customers] ([CustomerID])
GO
ALTER TABLE [dbo].[CustomerAddress] CHECK CONSTRAINT [FK_CustomerAddress_Customers]
GO

--INSERT INFO FROM ADVENTUREWORKS TO PERSONAL DB - TABLA CUSTOMERS
INSERT INTO [dbo_Customers].[dbo].[Customers] ([CustomerID],[FistName],[LastName],[PersonType],[StoreName])
SELECT 
cust.CustomerID, 
per.FirstName, 
per.LastName, 
per.PersonType,
ST.Name
FROM  
[AdventureWorks2012].[Sales].[Customer] cust LEFT JOIN [AdventureWorks2012].[Person].[Person] per ON cust.PersonID = per.BusinessEntityID
LEFT JOIN [AdventureWorks2012].[Sales].[Store] ST ON cust.StoreID = ST.BusinessEntityID

--INSERT INFO FROM ADVENTUREWORKS TO PERSONAL DB - TABLA ADDRESS
INSERT INTO [dbo_Customers].[dbo].[Address] ([AddressID],[Address1],[Address2],[City],[Province],[Country]) 
SELECT 
addr.AddressID,
addr.AddressLine1, 
addr.AddressLine2, 
addr.City, 
sp.Name,
con.Name 
FROM  
[AdventureWorks2012].[Person].[Address] addr LEFT JOIN [AdventureWorks2012].[Person].[StateProvince] sp ON addr.StateProvinceID = sp.StateProvinceID
LEFT JOIN [AdventureWorks2012].[Person].[CountryRegion] con ON sp.CountryRegionCode = con.CountryRegionCode 

----INSERT INFO FROM ADVENTUREWORKS TO PERSONAL DB - TABLA CUSTOMERADDRESS
INSERT INTO [dbo_Customers].[dbo].[CustomerAddress] ([CustomerID],[AddressID])
SELECT 
cust.CustomerID,
busAdd.AddressID
FROM  [AdventureWorks2012].[Person].[BusinessEntityAddress] busAdd
LEFT JOIN [AdventureWorks2012].[Sales].[Customer] cust ON busAdd.BusinessEntityID = cust.PersonID WHERE cust.CustomerID IS NOT NULL