CREATE PROCEDURE [dbo].[InventoryItemUpdate]
    @InventoryItemId INT,
    @InventoryName VARCHAR(250),
    @UpdatedBy INT
AS
BEGIN
    UPDATE InventoryItem
    SET
        InventoryName = @InventoryName,
        UpdatedBy = @UpdatedBy,
        UpdatedDate = GETDATE()
    WHERE
        InventoryItemId = @InventoryItemId
END