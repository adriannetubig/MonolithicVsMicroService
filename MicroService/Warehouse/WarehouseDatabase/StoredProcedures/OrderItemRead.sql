CREATE PROCEDURE [dbo].[OrderItemRead]
    @OrderItemId INT
AS
BEGIN
    SELECT
        OrderItemId,
        OrderName
    FROM
        OrderItem
    WHERE
        OrderItemId = @OrderItemId
END