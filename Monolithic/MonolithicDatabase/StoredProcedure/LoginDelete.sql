CREATE PROCEDURE [dbo].[LoginDelete]
    @LoginId INT,
    @DeletedBy INT
AS
BEGIN
    UPDATE Login
    SET
        DeletedBy = @DeletedBy,
        DeletedDate = GETDATE()
    WHERE
        LoginId = @LoginId
END