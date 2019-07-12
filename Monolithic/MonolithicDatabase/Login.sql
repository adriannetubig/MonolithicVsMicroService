CREATE TABLE [dbo].[Login]
(
    [LoginId] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [Username] VARCHAR(250) NOT NULL UNIQUE,
    [Password] VARCHAR(250) NOT NULL,
    [CreatedDate] DATETIME NOT NULL DEFAULT GETDATE(),
    [CreatedBy] INT NULL,
    [UpdatedDate] DATETIME NULL,
    [UpdatedBy] INT NULL,
    [DeletedDate] DATETIME NULL,
    [DeletedBy] INT NULL,
)
