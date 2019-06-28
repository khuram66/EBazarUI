
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/28/2019 13:43:17
-- Generated from EDMX file: F:\uniwork\EBazarUI\EBazarUI\Models\EBazarDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ECommerce];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Customers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Customers];
GO
IF OBJECT_ID(N'[dbo].[OrderDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderDetails];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Customers'
CREATE TABLE [dbo].[Customers] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [UserName] varchar(50)  NULL,
    [Password] varchar(50)  NULL,
    [Gender] varchar(50)  NULL,
    [DateofBirth] datetime  NULL,
    [Country] varchar(50)  NULL,
    [City] varchar(50)  NULL,
    [PostalCode] varchar(50)  NULL,
    [Email] varchar(50)  NULL,
    [Phone] varchar(50)  NULL,
    [Mobile] varchar(50)  NULL,
    [Address] varchar(50)  NULL,
    [Picture] varchar(250)  NULL,
    [LastLogin] datetime  NULL,
    [Created] datetime  NULL,
    [FirstName] nvarchar(50)  NULL,
    [LastName] nvarchar(50)  NULL
);
GO

-- Creating table 'Orders'
CREATE TABLE [dbo].[Orders] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Discount] int  NULL,
    [Taxes] int  NULL,
    [TotalAmount] int  NULL,
    [isCompleted] bit  NULL,
    [OrderDate] datetime  NULL,
    [DIspatched] bit  NULL,
    [DispatchedDate] datetime  NULL,
    [Shipped] bit  NULL,
    [ShippingDate] datetime  NULL,
    [Deliver] bit  NULL,
    [DeliveryDate] datetime  NULL,
    [Notes] varchar(500)  NULL,
    [CancelOrder] bit  NULL,
    [ProductID] int  NULL,
    [CustomerID] int  NULL
);
GO

-- Creating table 'OrderDetails'
CREATE TABLE [dbo].[OrderDetails] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [OrderID] int  NULL,
    [UnitPrice] decimal(18,0)  NULL,
    [Quantity] int  NULL,
    [Discount] decimal(18,0)  NULL,
    [TotalAmount] decimal(18,0)  NULL,
    [OrderDate] datetime  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'Categories'
CREATE TABLE [dbo].[Categories] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Category_Name] nvarchar(50)  NOT NULL,
    [Category_Image_Path] nvarchar(max)  NULL,
    [Is_Active] nvarchar(1)  NULL
);
GO

-- Creating table 'ProductImages'
CREATE TABLE [dbo].[ProductImages] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Product_image] nvarchar(max)  NULL,
    [Product_ID] int  NULL
);
GO

-- Creating table 'Products'
CREATE TABLE [dbo].[Products] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Product_Name] nvarchar(100)  NULL,
    [Producct_Short_Description] nvarchar(200)  NULL,
    [Product_Long_Description] nvarchar(500)  NULL,
    [Is_Active] nvarchar(1)  NULL,
    [Is_Featured] nvarchar(1)  NULL,
    [Is_OnSale] nvarchar(1)  NULL,
    [Product_Price] int  NULL,
    [Product_Sale_Price] int  NULL,
    [Product_Quantity] int  NULL,
    [Product_Feature_Image] nvarchar(max)  NULL,
    [Product_Size] nvarchar(100)  NULL,
    [Vendor_ID] int  NULL,
    [Category_ID] int  NULL,
    [Created_By] nvarchar(50)  NULL,
    [Modified_By] nvarchar(50)  NULL,
    [Created_On] datetime  NULL,
    [Modified_On] datetime  NULL
);
GO

-- Creating table 'Vendors'
CREATE TABLE [dbo].[Vendors] (
    [ID] int  NOT NULL,
    [First_Name] varchar(50)  NULL,
    [Last_Name] varchar(50)  NULL,
    [UserName] varchar(50)  NULL,
    [Password] varchar(50)  NULL,
    [Age] int  NULL,
    [Gender] varchar(50)  NULL,
    [DateofBirth] datetime  NULL,
    [ShopName] varchar(200)  NULL,
    [Country] varchar(50)  NULL,
    [City] varchar(50)  NULL,
    [PostalCode] varchar(50)  NULL,
    [Email] varchar(50)  NULL,
    [Phone] varchar(50)  NULL,
    [Mobile] varchar(50)  NULL,
    [Address] varchar(50)  NULL,
    [Picture] varchar(250)  NULL,
    [LastLogin] datetime  NULL,
    [Created] datetime  NULL
);
GO

-- Creating table 'MainSliders'
CREATE TABLE [dbo].[MainSliders] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [ImageURL] varchar(500)  NULL,
    [AltText] varchar(255)  NULL,
    [OfferTag] varchar(50)  NULL,
    [Title] varchar(50)  NULL,
    [Description] varchar(255)  NULL,
    [BtnText] varchar(50)  NULL,
    [isDeleted] bit  NULL
);
GO

-- Creating table 'PromoRights'
CREATE TABLE [dbo].[PromoRights] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [CategoryID] int  NOT NULL,
    [ImageURL] varchar(500)  NULL,
    [AltText] varchar(500)  NULL,
    [OfferTag] varchar(50)  NULL,
    [Title] varchar(50)  NULL,
    [isDeleted] bit  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [PK_Customers]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [PK_Orders]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'OrderDetails'
ALTER TABLE [dbo].[OrderDetails]
ADD CONSTRAINT [PK_OrderDetails]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [ID] in table 'Categories'
ALTER TABLE [dbo].[Categories]
ADD CONSTRAINT [PK_Categories]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'ProductImages'
ALTER TABLE [dbo].[ProductImages]
ADD CONSTRAINT [PK_ProductImages]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [PK_Products]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Vendors'
ALTER TABLE [dbo].[Vendors]
ADD CONSTRAINT [PK_Vendors]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'MainSliders'
ALTER TABLE [dbo].[MainSliders]
ADD CONSTRAINT [PK_MainSliders]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'PromoRights'
ALTER TABLE [dbo].[PromoRights]
ADD CONSTRAINT [PK_PromoRights]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CustomerID] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_Order_Customers]
    FOREIGN KEY ([CustomerID])
    REFERENCES [dbo].[Customers]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Order_Customers'
CREATE INDEX [IX_FK_Order_Customers]
ON [dbo].[Orders]
    ([CustomerID]);
GO

-- Creating foreign key on [ProductID] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_Order_TBL_Products]
    FOREIGN KEY ([ProductID])
    REFERENCES [dbo].[Products]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Order_TBL_Products'
CREATE INDEX [IX_FK_Order_TBL_Products]
ON [dbo].[Orders]
    ([ProductID]);
GO

-- Creating foreign key on [OrderID] in table 'OrderDetails'
ALTER TABLE [dbo].[OrderDetails]
ADD CONSTRAINT [FK_OrderDetails_Order]
    FOREIGN KEY ([OrderID])
    REFERENCES [dbo].[Orders]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderDetails_Order'
CREATE INDEX [IX_FK_OrderDetails_Order]
ON [dbo].[OrderDetails]
    ([OrderID]);
GO

-- Creating foreign key on [Category_ID] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [FK_TBL_PRODUCTS_TBL_CATEGORIES]
    FOREIGN KEY ([Category_ID])
    REFERENCES [dbo].[Categories]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TBL_PRODUCTS_TBL_CATEGORIES'
CREATE INDEX [IX_FK_TBL_PRODUCTS_TBL_CATEGORIES]
ON [dbo].[Products]
    ([Category_ID]);
GO

-- Creating foreign key on [Product_ID] in table 'ProductImages'
ALTER TABLE [dbo].[ProductImages]
ADD CONSTRAINT [FK_TBL_PRODUCT_IMAGES_TBL_PRODUCTS]
    FOREIGN KEY ([Product_ID])
    REFERENCES [dbo].[Products]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TBL_PRODUCT_IMAGES_TBL_PRODUCTS'
CREATE INDEX [IX_FK_TBL_PRODUCT_IMAGES_TBL_PRODUCTS]
ON [dbo].[ProductImages]
    ([Product_ID]);
GO

-- Creating foreign key on [Vendor_ID] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [FK_TBL_Products_Vendor]
    FOREIGN KEY ([Vendor_ID])
    REFERENCES [dbo].[Vendors]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TBL_Products_Vendor'
CREATE INDEX [IX_FK_TBL_Products_Vendor]
ON [dbo].[Products]
    ([Vendor_ID]);
GO

-- Creating foreign key on [CategoryID] in table 'PromoRights'
ALTER TABLE [dbo].[PromoRights]
ADD CONSTRAINT [FK_PromoRight_Categories]
    FOREIGN KEY ([CategoryID])
    REFERENCES [dbo].[Categories]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PromoRight_Categories'
CREATE INDEX [IX_FK_PromoRight_Categories]
ON [dbo].[PromoRights]
    ([CategoryID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------