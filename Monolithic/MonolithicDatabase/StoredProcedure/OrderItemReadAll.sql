CREATE PROCEDURE [dbo].[OrderItemReadAll]
AS
BEGIN
    SELECT
        OrderItemId,
        OrderName,
        CreatedBy,
        CreatedDate,
        UpdatedBy,
        UpdatedDate
    FROM
        OrderItem
END