CREATE PROCEDURE [dbo].[LoginReadActive]
AS
BEGIN
    SELECT
        LoginId,
        Username,
        Password,
        CreatedBy,
        CreatedDate,
        UpdatedBy,
        UpdatedDate
    FROM
        Login
    WHERE
        DeletedBy IS NULL
END