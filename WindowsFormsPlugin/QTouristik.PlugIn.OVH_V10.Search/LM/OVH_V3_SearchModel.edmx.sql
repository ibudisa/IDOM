
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/14/2017 20:19:08
-- Generated from EDMX file: F:\GIT_Net\Version_V1.6\QFramework_V1.6\PlugIn\QTouristik.PlugIn.OVH_V10.Search\LM\OVH_V3_SearchModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [V3_QTouristik.Search];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[KeyDatabaseSets]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KeyDatabaseSets];
GO
IF OBJECT_ID(N'[dbo].[SD_PartnerSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SD_PartnerSet];
GO
IF OBJECT_ID(N'[dbo].[SEH_FeWoPreiseSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SEH_FeWoPreiseSet];
GO
IF OBJECT_ID(N'[dbo].[SEH_ObjektInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SEH_ObjektInfo];
GO
IF OBJECT_ID(N'[dbo].[SEH_PlaceInfoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SEH_PlaceInfoSet];
GO
IF OBJECT_ID(N'[dbo].[SEH_PortalSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SEH_PortalSet];
GO
IF OBJECT_ID(N'[dbo].[SEH_RegionInfoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SEH_RegionInfoSet];
GO
IF OBJECT_ID(N'[dbo].[SEH_UnitInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SEH_UnitInfo];
GO
IF OBJECT_ID(N'[dbo].[dbGeoLocations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[dbGeoLocations];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'KeyDatabaseSets'
CREATE TABLE [dbo].[KeyDatabaseSets] (
    [AppKeyCode] nvarchar(12)  NOT NULL,
    [KeyCounter] int  NOT NULL
);
GO

-- Creating table 'SD_PartnerSet'
CREATE TABLE [dbo].[SD_PartnerSet] (
    [Id] smallint  NOT NULL,
    [Code] nvarchar(6)  NOT NULL,
    [Name] nvarchar(30)  NOT NULL,
    [LogoImage] nvarchar(30)  NOT NULL
);
GO

-- Creating table 'SEH_FeWoPreiseSet'
CREATE TABLE [dbo].[SEH_FeWoPreiseSet] (
    [Angebot_Id] int  NOT NULL,
    [counter] int  NOT NULL,
    [Anreise] datetime  NOT NULL,
    [Reisedauer] smallint  NOT NULL,
    [MinPersonen] smallint  NOT NULL,
    [MaxPersonen] smallint  NOT NULL,
    [ListenPreis] decimal(7,2)  NOT NULL,
    [EndPreis] decimal(7,2)  NOT NULL,
    [DealCode] nvarchar(2)  NULL
);
GO

-- Creating table 'SEH_ObjektInfo'
CREATE TABLE [dbo].[SEH_ObjektInfo] (
    [soObjektId] int  NOT NULL,
    [soOrtId] int  NOT NULL,
    [soRegion] int  NOT NULL,
    [soKurzBeschreibung] nvarchar(80)  NULL,
    [soLangBeschreibung] nvarchar(1000)  NULL,
    [soImageLocation] nchar(200)  NOT NULL,
    [soRouteObjektId] nvarchar(30)  NOT NULL,
    [soRouteObjektTyp] nvarchar(40)  NOT NULL,
    [Pool] nvarchar(1)  NOT NULL
);
GO

-- Creating table 'SEH_PlaceInfoSet'
CREATE TABLE [dbo].[SEH_PlaceInfoSet] (
    [Id] int  NOT NULL,
    [PlaceName] nvarchar(30)  NOT NULL,
    [RegionId] nvarchar(max)  NOT NULL,
    [IsInsel] nvarchar(1)  NOT NULL
);
GO

-- Creating table 'SEH_PortalSet'
CREATE TABLE [dbo].[SEH_PortalSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PortalCode] nvarchar(8)  NOT NULL,
    [TourOperator] int  NOT NULL
);
GO

-- Creating table 'SEH_RegionInfoSet'
CREATE TABLE [dbo].[SEH_RegionInfoSet] (
    [Id] int  NOT NULL,
    [RegionName] nvarchar(25)  NOT NULL
);
GO

-- Creating table 'SEH_UnitInfo'
CREATE TABLE [dbo].[SEH_UnitInfo] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [suUnitId] int  NOT NULL,
    [suObjektId] int  NOT NULL,
    [suKurzBeschreibung] nvarchar(80)  NULL,
    [suLangBeschreibung] nvarchar(1000)  NULL,
    [suImageLocation] nchar(200)  NOT NULL,
    [suRouteObjektId] nvarchar(30)  NOT NULL,
    [suRouteObjektTyp] nvarchar(40)  NOT NULL,
    [suAngebotVon] datetime  NOT NULL,
    [suAngebotBis] datetime  NOT NULL,
    [suFreeUnitCount] int  NOT NULL,
    [suMaxBelegung] int  NOT NULL,
    [suMaxErwachsener] int  NOT NULL,
    [suTourOperator] int  NOT NULL,
    [suHund] int  NOT NULL,
    [suBettwaesche] nvarchar(1)  NOT NULL,
    [suGeschirrspueler] nvarchar(1)  NOT NULL,
    [suMHGroße] int  NOT NULL,
    [suSchlafzimmer] int  NOT NULL,
    [suIsActive] nvarchar(1)  NOT NULL,
    [suLeistungstraegerId] int  NOT NULL,
    [suSiteCode] nvarchar(12)  NOT NULL,
    [suOfferCode] nvarchar(12)  NOT NULL,
    [suAnbieterHinweis] nvarchar(600)  NULL,
    [SuSort] int  NULL,
    [TourOperatorCode] nvarchar(10)  NULL
);
GO

-- Creating table 'dbGeoLocations'
CREATE TABLE [dbo].[dbGeoLocations] (
    [geoTyp] smallint  NOT NULL,
    [geoID] int  NOT NULL,
    [geoName] nchar(50)  NOT NULL,
    [geoParent] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [AppKeyCode] in table 'KeyDatabaseSets'
ALTER TABLE [dbo].[KeyDatabaseSets]
ADD CONSTRAINT [PK_KeyDatabaseSets]
    PRIMARY KEY CLUSTERED ([AppKeyCode] ASC);
GO

-- Creating primary key on [Id] in table 'SD_PartnerSet'
ALTER TABLE [dbo].[SD_PartnerSet]
ADD CONSTRAINT [PK_SD_PartnerSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Angebot_Id], [counter] in table 'SEH_FeWoPreiseSet'
ALTER TABLE [dbo].[SEH_FeWoPreiseSet]
ADD CONSTRAINT [PK_SEH_FeWoPreiseSet]
    PRIMARY KEY CLUSTERED ([Angebot_Id], [counter] ASC);
GO

-- Creating primary key on [soObjektId] in table 'SEH_ObjektInfo'
ALTER TABLE [dbo].[SEH_ObjektInfo]
ADD CONSTRAINT [PK_SEH_ObjektInfo]
    PRIMARY KEY CLUSTERED ([soObjektId] ASC);
GO

-- Creating primary key on [Id] in table 'SEH_PlaceInfoSet'
ALTER TABLE [dbo].[SEH_PlaceInfoSet]
ADD CONSTRAINT [PK_SEH_PlaceInfoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SEH_PortalSet'
ALTER TABLE [dbo].[SEH_PortalSet]
ADD CONSTRAINT [PK_SEH_PortalSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SEH_RegionInfoSet'
ALTER TABLE [dbo].[SEH_RegionInfoSet]
ADD CONSTRAINT [PK_SEH_RegionInfoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SEH_UnitInfo'
ALTER TABLE [dbo].[SEH_UnitInfo]
ADD CONSTRAINT [PK_SEH_UnitInfo]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [geoTyp], [geoID], [geoName] in table 'dbGeoLocations'
ALTER TABLE [dbo].[dbGeoLocations]
ADD CONSTRAINT [PK_dbGeoLocations]
    PRIMARY KEY CLUSTERED ([geoTyp], [geoID], [geoName] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------