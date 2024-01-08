CREATE PROCEDURE [dbo].[spMeasurement_Insert]
	@Id uniqueidentifier,
	@PatientID nvarchar(50),
	@Date DATETIME,
	@TherapyID nvarchar(50),
	@SerializedData TEXT,
	@Tag nvarchar(50),
	@AccuracyTag nvarchar(50)
AS
begin
	insert into dbo.Masurement (Id, PatientID, MeasurementDate, TherapyID, Tag, AccuracyTag, SerializedData)
	values (@Id, @PatientID, @Date, @TherapyID, @Tag, @AccuracyTag, @SerializedData)
end
