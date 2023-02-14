CREATE PROCEDURE [dbo].[UserInsert]
    @Username VARCHAR(50),
    @GivenName VARCHAR(50),
    @Surname VARCHAR(50)
AS

    -- Insert the user.
    INSERT INTO [dbo].[Users] (
        Username,
        GivenName,
        Surname
    ) VALUES (
        @Username,
        @GivenName,
        @Surname
    );

    -- Capture the identity of the newly created record.
    DECLARE @Id INT = SCOPE_IDENTITY();

    -- Select the newly created record.
    SELECT Username,
           GivenName,
           Surname
    FROM [dbo].[Users] U
    WHERE Id = @Id;

-- Return the identity of the newly created record.
RETURN CASE
    WHEN @Id > 0
    THEN @Id
    ELSE -1
END
