CREATE TABLE [dbo].[Styles] (
    [Id]            INT IDENTITY (1, 1) NOT NULL,
    [FeatureTypeId] INT NOT NULL,
	[PropertyIndex] INT	NOT NULL,
    [Name]          NVARCHAR (32) NOT NULL,
    [StyleType] INT NOT NULL, 
    CONSTRAINT [PK_Styles] PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_Styles_FeatureType] FOREIGN KEY ([FeatureTypeId]) REFERENCES [FeatureTypes]([Id])
);

