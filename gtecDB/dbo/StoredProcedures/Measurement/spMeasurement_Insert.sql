CREATE PROCEDURE [dbo].[spMeasurement_Insert]
	@Id uniqueidentifier,
	@PatientID nvarchar(50),
	@SessionID nvarchar(50),
	@SessionKind int,
	@MeasurementDate DATETIME,
	@TherapyID nvarchar(50),
	@SerializedData TEXT,
	@Tag nvarchar(50),
	@AccuracyTag nvarchar(50)
AS
begin
	insert into dbo.Masurement (Id, PatientID,SessionID, SessionKind, MeasurementDate, TherapyID, Tag, AccuracyTag, SerializedData)
	values (@Id, @PatientID, @MeasurementDate,@SessionID, @SessionKind, @TherapyID, @Tag, @AccuracyTag, @SerializedData)
end
