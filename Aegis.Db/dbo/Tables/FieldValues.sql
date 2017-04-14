CREATE TABLE [dbo].[FieldValues] (
    [DatasetId]     INT            NOT NULL,
    [FeatureIndex]  INT            NOT NULL,
    [FieldIndex] INT            NOT NULL,
    [Double]        FLOAT (53)     NULL,
    [Long]          BIGINT         NULL,
    [String]        NVARCHAR (MAX) NULL,
    [Discriminator] NVARCHAR (128) NOT NULL,
    CONSTRAINT [PK_FieldValues] PRIMARY KEY CLUSTERED ([DatasetId] ASC, [FeatureIndex] ASC, [FieldIndex] ASC),
    CONSTRAINT [FK_FieldValues_Datasets] FOREIGN KEY ([DatasetId]) REFERENCES [dbo].[Datasets] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_DatasetId]
    ON [dbo].[FieldValues]([DatasetId] ASC);

