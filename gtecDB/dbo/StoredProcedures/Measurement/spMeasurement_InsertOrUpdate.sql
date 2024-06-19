CREATE PROCEDURE [dbo].[spMeasurement_InsertOrUpdate]
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
	SET NOCOUNT ON;
	-- Check if the row with the given ID exists
    IF EXISTS (SELECT 1 FROM dbo.Masurement WHERE Id = @Id)
    BEGIN
        -- Update the existing row
        update dbo.Masurement
		set PatientID = @PatientID, 
		    SessionID = @SessionID, 
		    SessionKind = @SessionKind, 
			MeasurementDate = @MeasurementDate, 
			TherapyID = @TherapyID, 
			Tag = @Tag,
			AccuracyTag = @AccuracyTag,
			SerializedData = @SerializedData
		where Id = @Id;
    END
    ELSE
    BEGIN
        -- Insert a new row
        insert into dbo.Masurement (Id, PatientID,SessionID,SessionKind, MeasurementDate, TherapyID, Tag, AccuracyTag, SerializedData)
		values (@Id, @PatientID,@SessionID,@SessionKind, @MeasurementDate, @TherapyID, @Tag, @AccuracyTag, @SerializedData)
    END

	
end