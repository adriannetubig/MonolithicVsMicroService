CREATE PROCEDURE [dbo].[OrderItemUpdate]
    @OrderItemId INT,
    @OrderName VARCHAR(250),
    @UpdatedBy INT
AS
BEGIN
    UPDATE OrderItem
    SET
        OrderName = @OrderName,
        UpdatedBy = @UpdatedBy,
        UpdatedDate = GETDATE()
    WHERE
        OrderItemId = @OrderItemId
END