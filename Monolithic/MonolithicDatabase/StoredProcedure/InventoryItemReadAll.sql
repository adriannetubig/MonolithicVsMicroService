CREATE PROCEDURE [dbo].[InventoryItemReadAll]
AS
BEGIN
    SELECT
        InventoryItemId,
        InventoryName,
        CreatedBy,
        CreatedDate,
        UpdatedBy,
        UpdatedDate
    FROM
        InventoryItem
END