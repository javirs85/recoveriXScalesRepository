CREATE PROCEDURE [dbo].[spMeasurement_GetAll]
AS
begin
	select Id, PatientID, MeasurementDate, ScaleID, SerializedData
	from dbo.Masurement;
end