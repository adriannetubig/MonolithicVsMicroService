CREATE PROCEDURE [dbo].[InventoryItemCreate]
    @InventoryName VARCHAR(250),
    @CreatedBy INT
AS
BEGIN
    INSERT INTO InventoryItem
        (InventoryName,
        CreatedBy)
    VALUES
        (@InventoryName,
        @CreatedBy)
END