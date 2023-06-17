CREATE PROCEDURE [dbo].[UserUpdate]
  @SenderId UNIQUEIDENTIFIER,
  @UserId UNIQUEIDENTIFIER,
  @GivenName NVARCHAR(100) = NULL,
  @Surname NVARCHAR(100) = NULL
AS
BEGIN
  SET NOCOUNT ON;

  UPDATE [Sample].[Users]
  SET
    [GivenName] = ISNULL(@GivenName, [GivenName]),
    [Surname] = ISNULL(@Surname, [Surname]),
    [UpdateDate] = SYSDATETIMEOFFSET(),
    [UpdatedBy] = @SenderId
  WHERE
    [Id] = @UserId;
END
RETURN 0
