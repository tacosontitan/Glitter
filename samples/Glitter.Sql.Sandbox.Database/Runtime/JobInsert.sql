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

CREATE PROCEDURE [Sample].[JobInsert]
  @SenderId UNIQUEIDENTIFIER,
  @Name NVARCHAR(500),
  @DisplayName NVARCHAR(500),
  @Description NVARCHAR(2500),
  @InsertedBy UNIQUEIDENTIFIER,
  @UpdatedBy UNIQUEIDENTIFIER
AS
  INSERT INTO [Sample].[Jobs] (
    [Id],
    [Name],
    [DisplayName],
    [Description],
    [InsertDate],
    [InsertedBy],
    [UpdateDate],
    [UpdatedBy]
  ) VALUES (
    NEWID(),
    @Name,
    @DisplayName,
    @Description,
    SYSDATETIMEOFFSET(),
    @SenderId,
    SYSDATETIMEOFFSET(),
    @SenderId
  )
RETURN 0