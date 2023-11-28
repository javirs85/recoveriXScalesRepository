CREATE PROCEDURE [dbo].[spMeasurement_GetAllFromPatient]
	@PatientID UNIQUEIDENTIFIER
AS
begin
	select Id, PatientID, MeasurementDate, ScaleID, SerializedData
	from dbo.Masurement
	where PatientID = @PatientID;
end