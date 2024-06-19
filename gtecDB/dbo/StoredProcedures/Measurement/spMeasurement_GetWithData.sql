CREATE PROCEDURE [dbo].[spMeasurement_GetWithData]
	@Id uniqueidentifier
AS
begin
	select Id, PatientID, SessionID, SessionKind, MeasurementDate, TherapyID, Tag, AccuracyTag, SerializedData
	from dbo.Masurement
	where Id = @Id;
end
