CREATE PROCEDURE [dbo].[spPatient_Get]
	@Id uniqueidentifier
AS
begin
	select Id, PatientLabel, SerializedData
	from dbo.Patient
	where Id = @Id;
end
