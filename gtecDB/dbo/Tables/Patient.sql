CREATE TABLE [dbo].[Patient]
(
    [GymCode] nvarchar(10) NOT NULL,
    [SerializedData] TEXT NOT NULL, 
    [PatientLabel] NCHAR(50) NOT NULL, 
    [NumberOfMeasurementsInLastTherapy] SMALLINT NULL, 
    [LastMeasurementInLastTherapy] DATE NULL, 
    [Id] UNIQUEIDENTIFIER PRIMARY KEY,
)
