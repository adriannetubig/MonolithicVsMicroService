CREATE PROCEDURE [dbo].[LoginUpdate]
    @LoginId INT,
    @Password VARCHAR(250),
    @UpdatedBy INT
AS
BEGIN
    UPDATE Login
    SET
        Password = @Password,
        UpdatedBy = @UpdatedBy,
        UpdatedDate = GETDATE()
    WHERE
        LoginId = @LoginId
END