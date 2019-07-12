CREATE PROCEDURE [dbo].[LoginRead]
    @LoginId INT
AS
BEGIN
    SELECT
        LoginId,
        Username,
        Password
    FROM
        Login
    WHERE
        LoginId = @LoginId
END