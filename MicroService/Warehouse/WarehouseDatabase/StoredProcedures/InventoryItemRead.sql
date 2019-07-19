CREATE PROCEDURE [dbo].[InventoryItemRead]
    @InventoryItemId INT
AS
BEGIN
    SELECT
        InventoryItemId,
        InventoryName
    FROM
        InventoryItem
    WHERE
        InventoryItemId = @InventoryItemId
END