CREATE PROCEDURE [dbo].[UserInsert]
  @SenderId UNIQUEIDENTIFIER,
  @Username NVARCHAR(100),
  @GivenName NVARCHAR(100),
  @Surname NVARCHAR(100)
AS
BEGIN
  SET NOCOUNT ON;

  DECLARE @Id UNIQUEIDENTIFIER = NEWID();
  INSERT INTO [Sample].[Users]
  (
    [Id],
    [Username],
    [GivenName],
    [Surname],
    [InsertDate],
    [InsertedBy],
    [UpdateDate],
    [UpdatedBy]
  )
  VALUES
  (
    @Id,
    @Username,
    @GivenName,
    @Surname,
    SYSDATETIMEOFFSET(),
    @Id,
    SYSDATETIMEOFFSET(),
    @Id
  );

  SELECT @Id AS [Id];
END
RETURN 0
