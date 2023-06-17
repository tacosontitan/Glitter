/*
   Copyright 2023 tacosontitan and contributors

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

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
