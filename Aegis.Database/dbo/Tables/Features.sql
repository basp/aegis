CREATE TABLE [dbo].[Features] (
    [DatasetId]     INT              NOT NULL,
    [Index]         INT              NOT NULL,
    [WellKnownText] NVARCHAR (MAX)   NOT NULL,
    [Geometry]      [sys].[geometry] NOT NULL,
    CONSTRAINT [PK_Features] PRIMARY KEY CLUSTERED ([DatasetId] ASC, [Index] ASC), 
    CONSTRAINT [FK_Features_Datasets] FOREIGN KEY ([DatasetId]) REFERENCES [Datasets]([Id]) ON DELETE CASCADE
);

