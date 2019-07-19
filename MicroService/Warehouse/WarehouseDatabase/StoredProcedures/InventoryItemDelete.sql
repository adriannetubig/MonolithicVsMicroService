CREATE PROCEDURE [dbo].[InventoryItemDelete]
    @InventoryItemId INT,
    @DeletedBy INT
AS
BEGIN
    DELETE InventoryItem
    WHERE
        InventoryItemId = @InventoryItemId
END