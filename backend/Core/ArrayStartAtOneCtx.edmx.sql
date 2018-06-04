
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/30/2018 15:45:26
-- Generated from EDMX file: C:\Users\ndriu\Desktop\PSK\backend\Core\ArrayStartAtOneCtx.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MasyvaiPrasidedaVienetuDb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ItemOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Items] DROP CONSTRAINT [FK_ItemOrder];
GO
IF OBJECT_ID(N'[dbo].[FK_CategoryItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Categories] DROP CONSTRAINT [FK_CategoryItem];
GO
IF OBJECT_ID(N'[dbo].[FK_ImageItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Images] DROP CONSTRAINT [FK_ImageItem];
GO
IF OBJECT_ID(N'[dbo].[FK_ItemImage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Images] DROP CONSTRAINT [FK_ItemImage];
GO
IF OBJECT_ID(N'[dbo].[FK_ItemCategory_Item]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ItemCategory] DROP CONSTRAINT [FK_ItemCategory_Item];
GO
IF OBJECT_ID(N'[dbo].[FK_ItemCategory_Category]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ItemCategory] DROP CONSTRAINT [FK_ItemCategory_Category];
GO
IF OBJECT_ID(N'[dbo].[FK_UserUserSession]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserSessions] DROP CONSTRAINT [FK_UserUserSession];
GO
IF OBJECT_ID(N'[dbo].[FK_ItemProperties]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Items] DROP CONSTRAINT [FK_ItemProperties];
GO
IF OBJECT_ID(N'[dbo].[FK_OrderUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_OrderUser];
GO
IF OBJECT_ID(N'[dbo].[FK_OrderItem_Order]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderItem] DROP CONSTRAINT [FK_OrderItem_Order];
GO
IF OBJECT_ID(N'[dbo].[FK_OrderItem_Item]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderItem] DROP CONSTRAINT [FK_OrderItem_Item];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[Items]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Items];
GO
IF OBJECT_ID(N'[dbo].[Orders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Orders];
GO
IF OBJECT_ID(N'[dbo].[Categories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Categories];
GO
IF OBJECT_ID(N'[dbo].[Images]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Images];
GO
IF OBJECT_ID(N'[dbo].[UserSessions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserSessions];
GO
IF OBJECT_ID(N'[dbo].[Properties]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Properties];
GO
IF OBJECT_ID(N'[dbo].[ItemCategory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ItemCategory];
GO
IF OBJECT_ID(N'[dbo].[OrderItem]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderItem];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [SecondName] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [PasswordHash] nvarchar(max)  NOT NULL,
    [City] nvarchar(max)  NOT NULL,
    [Zip] nvarchar(max)  NOT NULL,
    [Street] nvarchar(max)  NOT NULL,
    [HouseNumber] nvarchar(max)  NOT NULL,
    [PhoneNumber] nvarchar(max)  NOT NULL,
    [IsBanned] bit  NOT NULL,
    [UserRole] int  NOT NULL
);
GO

-- Creating table 'Items'
CREATE TABLE [dbo].[Items] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [SkuCode] nvarchar(max)  NOT NULL,
    [Discount] float  NOT NULL,
    [Price] float  NOT NULL,
    [IsDisabled] bit  NOT NULL,
    [ItemOrder_Item_Id] int  NULL,
    [Property_Id] int  NOT NULL
);
GO

-- Creating table 'Orders'
CREATE TABLE [dbo].[Orders] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [OrderStatus] nvarchar(max)  NOT NULL,
    [TotalPrice] float  NOT NULL,
    [DeliveryAddress] nvarchar(max)  NOT NULL,
    [ItemsQty] nvarchar(max)  NOT NULL,
    [User_Id] int  NOT NULL
);
GO

-- Creating table 'Categories'
CREATE TABLE [dbo].[Categories] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [CategoryItem_Category_Id] int  NULL
);
GO

-- Creating table 'Images'
CREATE TABLE [dbo].[Images] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ImageUrl] nvarchar(max)  NOT NULL,
    [ImageItem_Image_Id] int  NULL,
    [ItemImage_Image_Id] int  NOT NULL
);
GO

-- Creating table 'UserSessions'
CREATE TABLE [dbo].[UserSessions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SessionHash] nvarchar(max)  NOT NULL,
    [ExpireDate] datetime  NOT NULL,
    [Role] int  NOT NULL,
    [User_Id] int  NOT NULL
);
GO

-- Creating table 'Properties'
CREATE TABLE [dbo].[Properties] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Ilgis] nvarchar(max)  NULL,
    [Plotis] nvarchar(max)  NULL,
    [Ratai] nvarchar(max)  NULL,
    [Guoliai] nvarchar(max)  NULL,
    [MaksimalusSvoris] nvarchar(max)  NULL,
    [Spalva] nvarchar(max)  NULL,
    [Asys] nvarchar(max)  NULL,
    [Paskirtis] nvarchar(max)  NULL,
    [Gamintojas] nvarchar(max)  NULL,
    [Dydis] nvarchar(max)  NULL,
    [Storis] nvarchar(max)  NULL,
    [Kietumas] nvarchar(max)  NULL,
    [Skirta] nvarchar(max)  NULL
);
GO

-- Creating table 'ItemCategory'
CREATE TABLE [dbo].[ItemCategory] (
    [ItemCategory_Category_Id] int  NOT NULL,
    [Categories_Id] int  NOT NULL
);
GO

-- Creating table 'OrderItem'
CREATE TABLE [dbo].[OrderItem] (
    [OrderItem_Item_Id] int  NOT NULL,
    [Items_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Items'
ALTER TABLE [dbo].[Items]
ADD CONSTRAINT [PK_Items]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [PK_Orders]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Categories'
ALTER TABLE [dbo].[Categories]
ADD CONSTRAINT [PK_Categories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Images'
ALTER TABLE [dbo].[Images]
ADD CONSTRAINT [PK_Images]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserSessions'
ALTER TABLE [dbo].[UserSessions]
ADD CONSTRAINT [PK_UserSessions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Properties'
ALTER TABLE [dbo].[Properties]
ADD CONSTRAINT [PK_Properties]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [ItemCategory_Category_Id], [Categories_Id] in table 'ItemCategory'
ALTER TABLE [dbo].[ItemCategory]
ADD CONSTRAINT [PK_ItemCategory]
    PRIMARY KEY CLUSTERED ([ItemCategory_Category_Id], [Categories_Id] ASC);
GO

-- Creating primary key on [OrderItem_Item_Id], [Items_Id] in table 'OrderItem'
ALTER TABLE [dbo].[OrderItem]
ADD CONSTRAINT [PK_OrderItem]
    PRIMARY KEY CLUSTERED ([OrderItem_Item_Id], [Items_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ItemOrder_Item_Id] in table 'Items'
ALTER TABLE [dbo].[Items]
ADD CONSTRAINT [FK_ItemOrder]
    FOREIGN KEY ([ItemOrder_Item_Id])
    REFERENCES [dbo].[Orders]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ItemOrder'
CREATE INDEX [IX_FK_ItemOrder]
ON [dbo].[Items]
    ([ItemOrder_Item_Id]);
GO

-- Creating foreign key on [CategoryItem_Category_Id] in table 'Categories'
ALTER TABLE [dbo].[Categories]
ADD CONSTRAINT [FK_CategoryItem]
    FOREIGN KEY ([CategoryItem_Category_Id])
    REFERENCES [dbo].[Items]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CategoryItem'
CREATE INDEX [IX_FK_CategoryItem]
ON [dbo].[Categories]
    ([CategoryItem_Category_Id]);
GO

-- Creating foreign key on [ImageItem_Image_Id] in table 'Images'
ALTER TABLE [dbo].[Images]
ADD CONSTRAINT [FK_ImageItem]
    FOREIGN KEY ([ImageItem_Image_Id])
    REFERENCES [dbo].[Items]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ImageItem'
CREATE INDEX [IX_FK_ImageItem]
ON [dbo].[Images]
    ([ImageItem_Image_Id]);
GO

-- Creating foreign key on [ItemImage_Image_Id] in table 'Images'
ALTER TABLE [dbo].[Images]
ADD CONSTRAINT [FK_ItemImage]
    FOREIGN KEY ([ItemImage_Image_Id])
    REFERENCES [dbo].[Items]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ItemImage'
CREATE INDEX [IX_FK_ItemImage]
ON [dbo].[Images]
    ([ItemImage_Image_Id]);
GO

-- Creating foreign key on [ItemCategory_Category_Id] in table 'ItemCategory'
ALTER TABLE [dbo].[ItemCategory]
ADD CONSTRAINT [FK_ItemCategory_Item]
    FOREIGN KEY ([ItemCategory_Category_Id])
    REFERENCES [dbo].[Items]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Categories_Id] in table 'ItemCategory'
ALTER TABLE [dbo].[ItemCategory]
ADD CONSTRAINT [FK_ItemCategory_Category]
    FOREIGN KEY ([Categories_Id])
    REFERENCES [dbo].[Categories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ItemCategory_Category'
CREATE INDEX [IX_FK_ItemCategory_Category]
ON [dbo].[ItemCategory]
    ([Categories_Id]);
GO

-- Creating foreign key on [User_Id] in table 'UserSessions'
ALTER TABLE [dbo].[UserSessions]
ADD CONSTRAINT [FK_UserUserSession]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserUserSession'
CREATE INDEX [IX_FK_UserUserSession]
ON [dbo].[UserSessions]
    ([User_Id]);
GO

-- Creating foreign key on [Property_Id] in table 'Items'
ALTER TABLE [dbo].[Items]
ADD CONSTRAINT [FK_ItemProperties]
    FOREIGN KEY ([Property_Id])
    REFERENCES [dbo].[Properties]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ItemProperties'
CREATE INDEX [IX_FK_ItemProperties]
ON [dbo].[Items]
    ([Property_Id]);
GO

-- Creating foreign key on [User_Id] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_OrderUser]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderUser'
CREATE INDEX [IX_FK_OrderUser]
ON [dbo].[Orders]
    ([User_Id]);
GO

-- Creating foreign key on [OrderItem_Item_Id] in table 'OrderItem'
ALTER TABLE [dbo].[OrderItem]
ADD CONSTRAINT [FK_OrderItem_Order]
    FOREIGN KEY ([OrderItem_Item_Id])
    REFERENCES [dbo].[Orders]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Items_Id] in table 'OrderItem'
ALTER TABLE [dbo].[OrderItem]
ADD CONSTRAINT [FK_OrderItem_Item]
    FOREIGN KEY ([Items_Id])
    REFERENCES [dbo].[Items]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderItem_Item'
CREATE INDEX [IX_FK_OrderItem_Item]
ON [dbo].[OrderItem]
    ([Items_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------