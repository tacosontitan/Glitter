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

CREATE PROCEDURE [Sample].[UserInsert] @SenderId UNIQUEIDENTIFIER,
                                       @Username NVARCHAR(100),
                                       @GivenName NVARCHAR(100),
                                       @Surname NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Id UNIQUEIDENTIFIER = NEWID();
    INSERT INTO [Sample].[Users]
    ([Id],
     [Username],
     [GivenName],
     [Surname],
     [InsertDate],
     [InsertedBy],
     [UpdateDate],
     [UpdatedBy])
    VALUES (@Id,
            @Username,
            @GivenName,
            @Surname,
            SYSDATETIMEOFFSET(),
            @Id,
            SYSDATETIMEOFFSET(),
            @Id);

    SELECT @Id AS [Id];
END
    RETURN 0
