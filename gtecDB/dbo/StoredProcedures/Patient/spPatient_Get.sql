﻿CREATE PROCEDURE [dbo].[spPatient_Get]
	@Id uniqueidentifier
AS
begin
	select PatientLabel, LastMeasurementInLastTherapy, NumberOfMeasurementsInLastTherapy, SerializedData
	from dbo.Patient
	where Id = @Id;
end
