CREATE TABLE [dbo].[FeatureTypes] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [WorkspaceId] INT           NOT NULL,
    [Name]        NVARCHAR (32) NOT NULL,
    CONSTRAINT [PK_FeatureTypes] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_FeatureTypes_Workspaces] FOREIGN KEY ([WorkspaceId]) REFERENCES [dbo].[Workspaces] ([Id]) ON DELETE CASCADE
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Workspace_FeatureType]
    ON [dbo].[FeatureTypes]([WorkspaceId] ASC, [Name] ASC);

