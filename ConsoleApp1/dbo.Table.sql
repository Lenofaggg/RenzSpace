CREATE TABLE [dbo].[Table]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [number] NVARCHAR(50) NOT NULL, 
    [price] INT NOT NULL, 
    [Stations1] NVARCHAR(50) NOT NULL, 
    [Stations2] NCHAR(10) NOT NULL, 
    [Stations3] NCHAR(10) NOT NULL, 
    [Time1] NCHAR(10) NOT NULL, 
    [Time2] NCHAR(10) NOT NULL, 
    [Time3] NCHAR(10) NOT NULL, 
    [Date1] NCHAR(10) NOT NULL,
	[Date2] NCHAR(10) NOT NULL,
	[Date3] NCHAR(10) NOT NULL
)
