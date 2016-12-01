
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/01/2016 15:32:04
-- Generated from EDMX file: C:\Users\User\Documents\Visual Studio 2015\Projects\Cashier\Cashier\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
CREATE DATABASE [CashierDB];
GO
USE [CashierDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ProductType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TblProducts] DROP CONSTRAINT [FK_ProductType];
GO
IF OBJECT_ID(N'[dbo].[FK_TblProductTblTransactionItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TblTransactionItems] DROP CONSTRAINT [FK_TblProductTblTransactionItem];
GO
IF OBJECT_ID(N'[dbo].[FK_TblTransactionTblTransactionItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TblTransactionItems] DROP CONSTRAINT [FK_TblTransactionTblTransactionItem];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[TblProducts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TblProducts];
GO
IF OBJECT_ID(N'[dbo].[TblProductTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TblProductTypes];
GO
IF OBJECT_ID(N'[dbo].[TblTransactionItems]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TblTransactionItems];
GO
IF OBJECT_ID(N'[dbo].[TblTransactions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TblTransactions];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'TblProducts'
CREATE TABLE [dbo].[TblProducts] (
    [ProductId] int IDENTITY(1,1) NOT NULL,
    [Price] decimal(19,4)  NULL,
    [Description] nvarchar(max)  NULL,
    [ProductType] int  NOT NULL,
    [Image] varbinary(max)  NULL
);
GO

-- Creating table 'TblProductTypes'
CREATE TABLE [dbo].[TblProductTypes] (
    [ProductType] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(max)  NULL
);
GO

-- Creating table 'TblTransactionItems'
CREATE TABLE [dbo].[TblTransactionItems] (
    [TransactionItemId] int IDENTITY(1,1) NOT NULL,
    [TransactionId] int  NOT NULL,
    [ProductId] int  NOT NULL
);
GO

-- Creating table 'TblTransactions'
CREATE TABLE [dbo].[TblTransactions] (
    [TransactionID] int IDENTITY(1,1) NOT NULL,
    [TransactionDate] datetime  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ProductId] in table 'TblProducts'
ALTER TABLE [dbo].[TblProducts]
ADD CONSTRAINT [PK_TblProducts]
    PRIMARY KEY CLUSTERED ([ProductId] ASC);
GO

-- Creating primary key on [ProductType] in table 'TblProductTypes'
ALTER TABLE [dbo].[TblProductTypes]
ADD CONSTRAINT [PK_TblProductTypes]
    PRIMARY KEY CLUSTERED ([ProductType] ASC);
GO

-- Creating primary key on [TransactionItemId] in table 'TblTransactionItems'
ALTER TABLE [dbo].[TblTransactionItems]
ADD CONSTRAINT [PK_TblTransactionItems]
    PRIMARY KEY CLUSTERED ([TransactionItemId] ASC);
GO

-- Creating primary key on [TransactionID] in table 'TblTransactions'
ALTER TABLE [dbo].[TblTransactions]
ADD CONSTRAINT [PK_TblTransactions]
    PRIMARY KEY CLUSTERED ([TransactionID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ProductType] in table 'TblProducts'
ALTER TABLE [dbo].[TblProducts]
ADD CONSTRAINT [FK_ProductType]
    FOREIGN KEY ([ProductType])
    REFERENCES [dbo].[TblProductTypes]
        ([ProductType])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductType'
CREATE INDEX [IX_FK_ProductType]
ON [dbo].[TblProducts]
    ([ProductType]);
GO

-- Creating foreign key on [ProductId] in table 'TblTransactionItems'
ALTER TABLE [dbo].[TblTransactionItems]
ADD CONSTRAINT [FK_TblProductTblTransactionItem]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[TblProducts]
        ([ProductId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TblProductTblTransactionItem'
CREATE INDEX [IX_FK_TblProductTblTransactionItem]
ON [dbo].[TblTransactionItems]
    ([ProductId]);
GO

-- Creating foreign key on [TransactionId] in table 'TblTransactionItems'
ALTER TABLE [dbo].[TblTransactionItems]
ADD CONSTRAINT [FK_TblTransactionTblTransactionItem]
    FOREIGN KEY ([TransactionId])
    REFERENCES [dbo].[TblTransactions]
        ([TransactionID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TblTransactionTblTransactionItem'
CREATE INDEX [IX_FK_TblTransactionTblTransactionItem]
ON [dbo].[TblTransactionItems]
    ([TransactionId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------