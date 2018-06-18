
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/18/2018 09:16:24
-- Generated from EDMX file: c:\users\mikezv\Source\Repos\ADOExam\ADOExam\Model\ModelF.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ADOExam];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[CategoriesSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CategoriesSet];
GO
IF OBJECT_ID(N'[dbo].[VacanciesSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VacanciesSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'VacanciesSet'
CREATE TABLE [dbo].[VacanciesSet] (
    [VacancyID] int IDENTITY(1,1) NOT NULL,
    [VacancyName] nvarchar(max)  NULL,
    [VacancyURL] nvarchar(max)  NULL,
    [VacancyDescription] nvarchar(max)  NULL,
    [VacancyAuthorEMail] nvarchar(max)  NULL,
    [VacancyPublishingDate] datetime  NOT NULL,
    [CategoryID] int  NOT NULL
);
GO

-- Creating table 'CategoriesSet'
CREATE TABLE [dbo].[CategoriesSet] (
    [CategoryID] int IDENTITY(1,1) NOT NULL,
    [CategoryName] nvarchar(max)  NOT NULL,
    [CategoryURL] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [VacancyID] in table 'VacanciesSet'
ALTER TABLE [dbo].[VacanciesSet]
ADD CONSTRAINT [PK_VacanciesSet]
    PRIMARY KEY CLUSTERED ([VacancyID] ASC);
GO

-- Creating primary key on [CategoryID] in table 'CategoriesSet'
ALTER TABLE [dbo].[CategoriesSet]
ADD CONSTRAINT [PK_CategoriesSet]
    PRIMARY KEY CLUSTERED ([CategoryID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------