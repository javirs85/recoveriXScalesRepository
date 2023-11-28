CREATE PROCEDURE [dbo].[spMeasurement_Insert]
	@PatientID UNIQUEIDENTIFIER,
	@MeasurementDate DATETIME,
	@ScaleID UNIQUEIDENTIFIER,
	@SerializedData TEXT
AS
begin
	insert into dbo.Masurement (PatientID, MeasurementDate, ScaleID, SerializedData)
	values (@PatientID, @MeasurementDate, @ScaleID, @SerializedData)
end
