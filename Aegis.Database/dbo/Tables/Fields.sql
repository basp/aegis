CREATE TABLE [dbo].[Fields] (
    [FeatureTypeId] INT            NOT NULL,
    [Index]         INT            NOT NULL,
    [FieldType]      INT            NOT NULL,
    [Name]          NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Fields] PRIMARY KEY CLUSTERED ([FeatureTypeId] ASC, [Index] ASC),
    CONSTRAINT [FK_Fields_FeatureTypes] FOREIGN KEY ([FeatureTypeId]) REFERENCES [dbo].[FeatureTypes] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_FeatureTypeId]
    ON [dbo].[Fields]([FeatureTypeId] ASC);

