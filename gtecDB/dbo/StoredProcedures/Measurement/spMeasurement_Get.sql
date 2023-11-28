CREATE PROCEDURE [dbo].[spMeasurement_Get]
	@Id int
AS
begin
	select Id, PatientID, MeasurementDate, ScaleID, SerializedData
	from dbo.Masurement
	where Id = @Id;
end
