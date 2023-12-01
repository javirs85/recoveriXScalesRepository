CREATE PROCEDURE [dbo].[spPatient_Update]
	@Id UNIQUEIDENTIFIER,
	@Label nvarchar(50),
	@NumberOfMeasurements int,
	@LastMeasurement Date,
	@SerializedData TEXT
AS
begin
	update dbo.Patient
	set PatientLabel = @Label, SerializedData = @SerializedData, NumberOfMeasurements = @NumberOfMeasurements, LastMeasurement = @LastMeasurement
	where Id = @Id;
end