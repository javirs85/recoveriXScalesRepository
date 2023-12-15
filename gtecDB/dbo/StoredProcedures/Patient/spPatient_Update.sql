CREATE PROCEDURE [dbo].[spPatient_Update]
	@Id UNIQUEIDENTIFIER,
	@Label nvarchar(50),
	@NumberOfMeasurementsInLastTherapy int,
	@LastMeasurementInLastTherapy Date,
	@SerializedData TEXT
AS
begin
	update dbo.Patient
	set PatientLabel = @Label, SerializedData = @SerializedData, NumberOfMeasurementsInLastTherapy = @NumberOfMeasurementsInLastTherapy, LastMeasurementInLastTherapy = @LastMeasurementInLastTherapy
	where Id = @Id;
end