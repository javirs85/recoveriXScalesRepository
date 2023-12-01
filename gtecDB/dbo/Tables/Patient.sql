CREATE TABLE [dbo].[Patient]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [SerializedData] TEXT NOT NULL, 
    [PatientLabel] NCHAR(50) NOT NULL, 
    [NumberOfMeasurements] INT NOT NULL, 
    [LastMeasurement] DATE NULL
)
