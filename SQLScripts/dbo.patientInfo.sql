CREATE TABLE [dbo].[patientInfo]
(
	[PID] INT NOT NULL PRIMARY KEY, 
    [pName] VARCHAR(50) NOT NULL, 
    [pBDate] DATE NOT NULL, 
    [pTel] VARCHAR(50) NULL, 
    [pWeChat] VARCHAR(50) NULL
)
