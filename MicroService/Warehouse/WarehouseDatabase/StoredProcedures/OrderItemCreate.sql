CREATE PROCEDURE [dbo].[OrderItemCreate]
    @OrderName VARCHAR(250),
    @CreatedBy INT
AS
BEGIN
    INSERT INTO OrderItem
        (OrderName,
        CreatedBy)
    VALUES
        (@OrderName,
        @CreatedBy)
END