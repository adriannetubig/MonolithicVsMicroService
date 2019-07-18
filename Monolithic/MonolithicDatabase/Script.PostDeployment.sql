/*
Post-Deployment Script Template       
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.  
 Use SQLCMD syntax to include a file in the post-deployment script.   
 Example:      :r .\myfile.sql        
 Use SQLCMD syntax to reference a variable in the post-deployment script.  
 Example:      :setvar TableName MyTable       
               SELECT * FROM [$(TableName)]     
--------------------------------------------------------------------------------------
*/

IF (NOT EXISTS(SELECT 1 FROM [dbo].[Login]))  
BEGIN  
    INSERT INTO [dbo].[Login]
        (Username,
        Password)
    VALUES
        ('username',
        '$2b$10$BMH23FkUuDMDtMsLBEbb7u7AJ/eYnV5MbJ.or6hYSnRtfDAuAzTpS')
END  