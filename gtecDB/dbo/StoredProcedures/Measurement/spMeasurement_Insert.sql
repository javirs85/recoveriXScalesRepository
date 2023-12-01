CREATE PROCEDURE [dbo].[spMeasurement_Insert]
	@Id uniqueidentifier,
	@PatientID UNIQUEIDENTIFIER,
	@MeasurementDate DATETIME,
	@ScaleID UNIQUEIDENTIFIER,
	@SerializedData TEXT
AS
begin
	insert into dbo.Masurement (Id, PatientID, MeasurementDate, ScaleID, SerializedData)
	values (@Id, @PatientID, @MeasurementDate, @ScaleID, @SerializedData)
end
