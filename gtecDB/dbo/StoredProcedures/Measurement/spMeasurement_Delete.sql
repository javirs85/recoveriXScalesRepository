CREATE PROCEDURE [dbo].[spMeasurement_Delete]
	@Id int
AS
begin
	delete
	from dbo.Masurement
	where Id = @Id;
end
