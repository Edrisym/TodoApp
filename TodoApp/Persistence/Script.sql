
CREATE TABLE [TodoLists] (
    [Id] uniqueidentifier NOT NULL,
    [Title] nvarchar(10) NOT NULL DEFAULT N'Untitled List',
    [CreatedOn] datetime2 NOT NULL DEFAULT (GETDATE()),
    [CreatedBy] datetime2 NOT NULL,
    [UpdatedOn] datetime2 NOT NULL DEFAULT (GETDATE()),
    [UpdatedBy] datetime2 NOT NULL,
    CONSTRAINT [PK_TodoLists] PRIMARY KEY ([Id])
    );
GO

CREATE TABLE [TaskItems] (
    [Id] uniqueidentifier NOT NULL,
    [Description] nvarchar(300) NULL,
    [DueDate] datetime2 NULL,
    [Priority] int NOT NULL,
    [IsCompleted] bit NOT NULL,
    [TodoListId] uniqueidentifier NOT NULL,
    [Title] nvarchar(100) NOT NULL DEFAULT N'Untitled Task',
    [CreatedOn] datetime2 NOT NULL DEFAULT (GETDATE()),
    [CreatedBy] datetime2 NOT NULL,
    [UpdatedOn] datetime2 NOT NULL DEFAULT (GETDATE()),
    [UpdatedBy] datetime2 NOT NULL,
    CONSTRAINT [PK_TaskItems] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TaskItems_TodoLists_TodoListId] FOREIGN KEY ([TodoListId]) REFERENCES [TodoLists] ([Id]) ON DELETE CASCADE
    );
GO

CREATE INDEX [IX_TaskItems_TodoListId] ON [TaskItems] ([TodoListId]);
GO
