CREATE PROCEDURE [dbo].[spPatient_GetAll]
AS
begin
	select Id, PatientLabel, LastMeasurementInLastTherapy, NumberOfMeasurementsInLastTherapy
	from dbo.Patient;
end