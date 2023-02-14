CREATE FUNCTION [dbo].[UsersQueryByUsername]
(
    @Username VARCHAR(50)
)
RETURNS @Results TABLE
(
    Id INT,
    Username VARCHAR(50),
    GivenName VARCHAR(50),
    Surname VARCHAR(50)
)
AS
BEGIN
    INSERT @Results
    SELECT U.Id,
           U.Username,
           U.GivenName,
           U.Surname
    FROM [dbo].[Users] U
    RETURN
END
