CREATE TABLE [dbo].[Datasets] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [FeatureTypeId] INT            NOT NULL,
    [Name]          NVARCHAR (128) NOT NULL,
    [DateCreated]   DATETIME       NOT NULL,
    [Srs]           INT            NOT NULL,
    CONSTRAINT [PK_Datasets] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Datasets_FeatureTypes] FOREIGN KEY ([FeatureTypeId]) REFERENCES [dbo].[FeatureTypes] ([Id]) ON DELETE CASCADE
);

GO
CREATE NONCLUSTERED INDEX [IX_FeatureTypeId]
    ON [dbo].[Datasets]([FeatureTypeId] ASC);

