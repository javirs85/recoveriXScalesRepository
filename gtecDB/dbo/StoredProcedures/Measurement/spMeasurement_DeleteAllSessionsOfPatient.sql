CREATE PROCEDURE [dbo].[spMeasurement_DeleteAllSessionsOfPatient]
	@PatientId nvarchar(50)
AS
begin
	delete
	from dbo.Masurement
	where PatientID = @PatientId;
end
