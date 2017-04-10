CREATE TABLE [dbo].[Layers] (
    [Id]            INT           IDENTITY (1, 1) NOT NULL,
    [FeatureTypeId] INT           NOT NULL,
    [Name]          NVARCHAR (32) NOT NULL,
    [StyleId]       INT           NOT NULL,
    CONSTRAINT [PK_Layers] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_Layers_FeatureTypes] FOREIGN KEY ([FeatureTypeId]) REFERENCES [dbo].[FeatureTypes] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Layers_Styles] FOREIGN KEY ([StyleId]) REFERENCES [dbo].[Styles] ([Id]) ON DELETE CASCADE
);

GO
CREATE NONCLUSTERED INDEX [IX_FeatureTypeId]
	ON [dbo].[Layers]([FeatureTypeId] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_StyleId]
    ON [dbo].[Layers]([StyleId] ASC);
