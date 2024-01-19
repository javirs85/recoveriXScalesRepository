CREATE TABLE [dbo].[Patient]
(
    [GymCode] nvarchar(10) NOT NULL,
    [SerializedData] TEXT NOT NULL, 
    [PatientLabel] NCHAR(50) NOT NULL, 
    [NumberOfMeasurementsInLastTherapy] NCHAR(10) NULL, 
    [LastMeasurementInLastTherapy] NVARCHAR(50) NULL, 
    [Id] UNIQUEIDENTIFIER PRIMARY KEY,
)
