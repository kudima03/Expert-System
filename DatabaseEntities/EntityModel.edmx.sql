
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/29/2022 21:43:51
-- Generated from EDMX file: C:\Users\Дмитрий\source\repos\Курсовой проект\DatabaseEntities\EntityModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [18];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[VehicleSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VehicleSet];
GO
IF OBJECT_ID(N'[dbo].[AdminSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AdminSet];
GO
IF OBJECT_ID(N'[dbo].[ClientSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClientSet];
GO
IF OBJECT_ID(N'[dbo].[ExpertSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ExpertSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'VehicleSet'
CREATE TABLE [dbo].[VehicleSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Dealer] nvarchar(max)  NOT NULL,
    [Model] nvarchar(max)  NOT NULL,
    [Colour] nvarchar(max)  NOT NULL,
    [RegistrationNumber] nvarchar(max)  NOT NULL,
    [TotalRate] float  NOT NULL,
    [BinaryPhoto] varbinary(max)  NOT NULL
);
GO

-- Creating table 'AdminSet'
CREATE TABLE [dbo].[AdminSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [UserStatus] int  NOT NULL,
    [BinaryPhoto] varbinary(max)  NOT NULL,
    [LastOnline] datetime  NOT NULL
);
GO

-- Creating table 'ClientSet'
CREATE TABLE [dbo].[ClientSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [UserStatus] int  NOT NULL,
    [BinaryPhoto] varbinary(max)  NOT NULL,
    [LastOnline] datetime  NOT NULL
);
GO

-- Creating table 'ExpertSet'
CREATE TABLE [dbo].[ExpertSet] (
    [RateWeight] float  NOT NULL,
    [Id] int IDENTITY(1,1) NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Login] nvarchar(max)  NOT NULL,
    [UserStatus] int  NOT NULL,
    [BinaryPhoto] varbinary(max)  NOT NULL,
    [LastOnline] datetime  NOT NULL
);
GO

-- Creating table 'RateSet'
CREATE TABLE [dbo].[RateSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Value] float  NOT NULL,
    [TimeOfCommit] datetime  NOT NULL,
    [VehicleId] int  NOT NULL,
    [ExpertId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'VehicleSet'
ALTER TABLE [dbo].[VehicleSet]
ADD CONSTRAINT [PK_VehicleSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AdminSet'
ALTER TABLE [dbo].[AdminSet]
ADD CONSTRAINT [PK_AdminSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ClientSet'
ALTER TABLE [dbo].[ClientSet]
ADD CONSTRAINT [PK_ClientSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ExpertSet'
ALTER TABLE [dbo].[ExpertSet]
ADD CONSTRAINT [PK_ExpertSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RateSet'
ALTER TABLE [dbo].[RateSet]
ADD CONSTRAINT [PK_RateSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [VehicleId] in table 'RateSet'
ALTER TABLE [dbo].[RateSet]
ADD CONSTRAINT [FK_VehicleRate]
    FOREIGN KEY ([VehicleId])
    REFERENCES [dbo].[VehicleSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE CASCADE;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VehicleRate'
CREATE INDEX [IX_FK_VehicleRate]
ON [dbo].[RateSet]
    ([VehicleId]);
GO

-- Creating foreign key on [ExpertId] in table 'RateSet'
ALTER TABLE [dbo].[RateSet]
ADD CONSTRAINT [FK_ExpertRate]
    FOREIGN KEY ([ExpertId])
    REFERENCES [dbo].[ExpertSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE CASCADE;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ExpertRate'
CREATE INDEX [IX_FK_ExpertRate]
ON [dbo].[RateSet]
    ([ExpertId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------