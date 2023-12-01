CREATE PROCEDURE [dbo].[spMeasurement_Get]
	@PatientID uniqueidentifier
AS
begin
	select Id, PatientID, MeasurementDate, ScaleID, SerializedData
	from dbo.Masurement
	where PatientID = @PatientID;
end
