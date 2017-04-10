CREATE TABLE [dbo].[StyleClasses] (
    [StyleId]       INT            NOT NULL,
    [Index]         INT            NOT NULL,
    [Symbol]        NVARCHAR (MAX) NOT NULL,
    [Legend]        NVARCHAR (MAX) NOT NULL,
    [Category]      NVARCHAR (MAX) NULL,
    [Min]           FLOAT (53)     NULL,
    [Max]           FLOAT (53)     NULL,
    [Discriminator] NVARCHAR (128) NOT NULL,
    CONSTRAINT [PK_StyleClasses] PRIMARY KEY CLUSTERED ([StyleId] ASC, [Index] ASC),
    CONSTRAINT [FK_StyleClasses_Styles] FOREIGN KEY ([StyleId]) REFERENCES [dbo].[Styles] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_StyleId]
    ON [dbo].[StyleClasses]([StyleId] ASC);

