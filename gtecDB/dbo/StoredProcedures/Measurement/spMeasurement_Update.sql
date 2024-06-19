CREATE PROCEDURE [dbo].[spMeasurement_Update]
	@Id uniqueidentifier,
	@PatientID nvarchar(50),
	@SessionKind nvarchar(50),
	@MeasurementDate DATETIME,
	@TherapyID nvarchar(50),
	@SerializedData TEXT,
	@Tag nvarchar(50),
	@AccuracyTag nvarchar(50)
AS
begin
	update dbo.Masurement
	set PatientID = @PatientID, 
		SessionKind = @SessionKind, 
		MeasurementDate = @MeasurementDate, 
		TherapyID = @TherapyID, 
		Tag = @Tag,
		AccuracyTag = @AccuracyTag,
		SerializedData = @SerializedData
	where Id = @Id;
end