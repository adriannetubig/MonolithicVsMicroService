CREATE PROCEDURE [dbo].[LoginReadByUsername]
    @Username VARCHAR(250)
AS
BEGIN
    SELECT
        LoginId,
        Username,
        Password
    FROM
        Login
    WHERE
        Username = @Username
END