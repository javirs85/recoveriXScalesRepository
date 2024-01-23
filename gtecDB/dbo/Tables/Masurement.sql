CREATE TABLE [dbo].[Masurement]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [PatientID] NVARCHAR(50) NOT NULL, 
    [MeasurementDate] DATETIME NOT NULL, 
    [TherapyID] NVARCHAR(50) NOT NULL, 
    [Tag] NVARCHAR(50) NOT NULL, 
    [AccuracyTag] NVARCHAR(50) NOT NULL,
    [SerializedData] TEXT NOT NULL, 
)
