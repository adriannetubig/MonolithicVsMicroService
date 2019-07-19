CREATE PROCEDURE [dbo].[OrderItemDelete]
    @OrderItemId INT,
    @DeletedBy INT
AS
BEGIN
    DELETE OrderItem
    WHERE
        OrderItemId = @OrderItemId
END