CREATE PROCEDURE [dbo].[spMeasurement_Delete]
	@Id uniqueidentifier
AS
begin
	delete
	from dbo.Masurement
	where Id = @Id;
end
