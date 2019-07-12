CREATE PROCEDURE [dbo].[LoginReadByUsername]
    @Username VARCHAR(250)
AS
BEGIN
    SELECT
        Password
    FROM
        Login
    WHERE
        Username = @Username
END