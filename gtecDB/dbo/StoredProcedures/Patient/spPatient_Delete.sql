CREATE PROCEDURE [dbo].[spPatient_Delete]
	@Id uniqueidentifier
AS
begin
	delete
	from dbo.Patient
	where Id = @Id;
end
