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

CREATE TABLE [Sample].[Jobs]
(
  [Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,

  [Name] NVARCHAR(500) NOT NULL,
  CONSTRAINT [UQ_Sample_Jobs_Name] UNIQUE ([Name]),

  [DisplayName] NVARCHAR(500) NOT NULL,
  [Description] NVARCHAR(2500) NOT NULL,
  
  -- Standard columns for all tables.
  [InsertDate] DATETIMEOFFSET NOT NULL,
  [InsertedBy] UNIQUEIDENTIFIER NOT NULL,
  [UpdateDate] DATETIMEOFFSET NOT NULL,
  [UpdatedBy] UNIQUEIDENTIFIER NOT NULL
)
