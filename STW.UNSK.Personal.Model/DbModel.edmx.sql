
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/09/2019 10:08:16
-- Generated from EDMX file: c:\users\epaneshnikovsa\Documents\Visual Studio 2015\Projects\STW.UNSK.Personal\STW.UNSK.Personal.Model\DbModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [UNSK_Personal];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Personal'
CREATE TABLE [dbo].[Personal] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Patronymic] nvarchar(max)  NOT NULL,
    [Surname] nvarchar(max)  NOT NULL,
    [Post_Id] int  NOT NULL
);
GO

-- Creating table 'State'
CREATE TABLE [dbo].[State] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Personal_Worker'
CREATE TABLE [dbo].[Personal_Worker] (
    [Rank] int  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'State_DeputyPost'
CREATE TABLE [dbo].[State_DeputyPost] (
    [DeputyName] nvarchar(max)  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Personal'
ALTER TABLE [dbo].[Personal]
ADD CONSTRAINT [PK_Personal]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'State'
ALTER TABLE [dbo].[State]
ADD CONSTRAINT [PK_State]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Personal_Worker'
ALTER TABLE [dbo].[Personal_Worker]
ADD CONSTRAINT [PK_Personal_Worker]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'State_DeputyPost'
ALTER TABLE [dbo].[State_DeputyPost]
ADD CONSTRAINT [PK_State_DeputyPost]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Post_Id] in table 'Personal'
ALTER TABLE [dbo].[Personal]
ADD CONSTRAINT [FK_PersonPost]
    FOREIGN KEY ([Post_Id])
    REFERENCES [dbo].[State]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonPost'
CREATE INDEX [IX_FK_PersonPost]
ON [dbo].[Personal]
    ([Post_Id]);
GO

-- Creating foreign key on [Id] in table 'Personal_Worker'
ALTER TABLE [dbo].[Personal_Worker]
ADD CONSTRAINT [FK_Worker_inherits_Person]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Personal]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'State_DeputyPost'
ALTER TABLE [dbo].[State_DeputyPost]
ADD CONSTRAINT [FK_DeputyPost_inherits_Post]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[State]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------