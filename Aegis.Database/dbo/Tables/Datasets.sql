CREATE TABLE [dbo].[Datasets] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [WorkspaceId]	INT			   NOT NULL, 
    [FeatureTypeId] INT            NOT NULL,
    [Name]          NVARCHAR (128) NOT NULL,
    [DateCreated]   DATETIME       NOT NULL,
    [Srs]           INT            NOT NULL,
    CONSTRAINT [PK_Datasets] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_DataSets_Workspaces] FOREIGN KEY ([WorkspaceId]) REFERENCES [dbo].[Workspaces]([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Datasets_FeatureTypes] FOREIGN KEY ([FeatureTypeId]) REFERENCES [dbo].[FeatureTypes] ([Id])
);

GO
CREATE NONCLUSTERED INDEX [IX_FeatureTypeId]
    ON [dbo].[Datasets]([FeatureTypeId] ASC);

