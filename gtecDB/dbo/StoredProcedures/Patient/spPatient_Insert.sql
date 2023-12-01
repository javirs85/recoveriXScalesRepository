CREATE PROCEDURE [dbo].[spPatient_Insert]
	@ID UNIQUEIDENTIFIER,
	@PatientLabel nvarchar(50),
	@NumberOfMeasurements int,
	@LastMeasurement Date,
	@SerializedData TEXT
AS
begin
	insert into dbo.Patient (Id, PatientLabel, NumberOfMeasurements, LastMeasurement, SerializedData)
	values (@ID, @PatientLabel, @NumberOfMeasurements, @LastMeasurement, @SerializedData)
end
