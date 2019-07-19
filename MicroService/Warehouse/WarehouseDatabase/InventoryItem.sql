CREATE TABLE [dbo].[InventoryItem]
(
    [InventoryItemId] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [InventoryName] VARCHAR(250),
    [CreatedDate] DATETIME NOT NULL DEFAULT GETDATE(),
    [CreatedBy] INT NULL,
    [UpdatedDate] DATETIME NULL,
    [UpdatedBy] INT NULL
)
