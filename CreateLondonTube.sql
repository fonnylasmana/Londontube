CREATE TABLE [dbo].[TubeLine] (
    [TubeLineId]   INT            IDENTITY (1, 1) NOT NULL,
    [TubeLineName] NVARCHAR (200) NULL,
    [FromStation]  NVARCHAR (200) NULL,
    [ToStation]    NVARCHAR (200) NULL,
    [Express] BIT NULL, 
    PRIMARY KEY CLUSTERED ([TubeLineId] ASC)
);

