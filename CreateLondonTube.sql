CREATE TABLE [dbo].[TubeLine]
(
	[TubeLineId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [TubeLineName] NVARCHAR(200) NULL, 
    [FromStation] NVARCHAR(200) NULL, 
    [ToStation] NVARCHAR(200) NULL
)
