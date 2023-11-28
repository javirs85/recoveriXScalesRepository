CREATE PROCEDURE [dbo].[spMeasurement_Update]
	@Id UNIQUEIDENTIFIER,
	@PatientID UNIQUEIDENTIFIER,
	@Date DATETIME,
	@ScaleID UNIQUEIDENTIFIER,
	@SerializedData TEXT
AS
begin
	update dbo.Masurement
	set PatientID = @PatientID, MeasurementDate = @Date, ScaleID = @ScaleID, SerializedData = @SerializedData
	where Id = @Id;
end