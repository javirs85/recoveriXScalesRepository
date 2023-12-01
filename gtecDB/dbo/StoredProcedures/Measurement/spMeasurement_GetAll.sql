CREATE PROCEDURE [dbo].[spMeasurement_GetAll]
AS
begin
	select PatientID, MeasurementDate, ScaleID, SerializedData
	from dbo.Masurement;
end