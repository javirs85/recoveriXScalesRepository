CREATE PROCEDURE [dbo].[spPatient_Insert]
	@Id uniqueidentifier,
	@GymCode nvarchar(10),
	@PatientLabel nvarchar(50),
	@NumberOfMeasurementsInLastTherapy nvarchar(10),
	@LastMeasurementInLastTherapy nvarchar(50),
	@SerializedData TEXT
AS
begin
	insert into dbo.Patient (Id, GymCode, PatientLabel, NumberOfMeasurementsInLastTherapy, LastMeasurementInLastTherapy, SerializedData)
	values (@Id, @GymCode, @PatientLabel, @NumberOfMeasurementsInLastTherapy, @LastMeasurementInLastTherapy, @SerializedData)
end
