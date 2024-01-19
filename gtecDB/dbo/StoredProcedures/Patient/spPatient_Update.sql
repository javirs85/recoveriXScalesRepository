CREATE PROCEDURE [dbo].[spPatient_Update]
	@Id UNIQUEIDENTIFIER,
	@Label nvarchar(50),
	@NumberOfMeasurementsInLastTherapy nchar(10),
	@LastMeasurementInLastTherapy nvarchar(50),
	@SerializedData TEXT
AS
begin
	update dbo.Patient
	set PatientLabel = @Label, SerializedData = @SerializedData, NumberOfMeasurementsInLastTherapy = @NumberOfMeasurementsInLastTherapy, LastMeasurementInLastTherapy = @LastMeasurementInLastTherapy
	where Id = @Id;
end