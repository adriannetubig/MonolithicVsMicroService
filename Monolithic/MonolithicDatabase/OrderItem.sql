CREATE TABLE [dbo].[OrderItem]
(
    [OrderItemId] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [OrderName] VARCHAR(250),
    [CreatedDate] DATETIME NOT NULL DEFAULT GETDATE(),
    [CreatedBy] INT NULL,
    [UpdatedDate] DATETIME NULL,
    [UpdatedBy] INT NULL
)
