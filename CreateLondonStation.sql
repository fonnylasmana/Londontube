CREATE TABLE [dbo].[Station]
(
	[StationId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [StationName] NVARCHAR(200) NULL, 
    [OSX] INT NULL, 
    [OSY] INT NULL, 
    [Latitude] FLOAT NULL, 
    [Longitude] FLOAT NULL, 
    [Zone] NVARCHAR(50) NULL, 
    [Postcode] NVARCHAR(50) NULL
)
