CREATE PROCEDURE [dbo].[LoginCreate]
    @Username VARCHAR(250),
    @Password VARCHAR(250),
    @CreatedBy INT
AS
BEGIN
    INSERT INTO Login
        (Username,
        Password,
        CreatedBy)
    VALUES
        (@Username,
        @Password,
        @CreatedBy)
END