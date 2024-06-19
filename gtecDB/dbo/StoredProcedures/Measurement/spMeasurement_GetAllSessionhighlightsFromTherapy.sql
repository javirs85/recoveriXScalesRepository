CREATE PROCEDURE [dbo].[spMeasurement_GetAllSessionHighlightsFromTherapy]
	@TherapyID nvarchar(50)
AS
begin
	select Id, PatientID,SessionID,SessionKind, TherapyID, MeasurementDate, Tag, AccuracyTag
	from dbo.Masurement
	where TherapyID = @TherapyID;
end