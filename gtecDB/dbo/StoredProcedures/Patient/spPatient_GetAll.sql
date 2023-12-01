CREATE PROCEDURE [dbo].[spPatient_GetAll]
AS
begin
	select Id, PatientLabel, NumberOfMeasurements, LastMeasurement
	from dbo.Patient;
end