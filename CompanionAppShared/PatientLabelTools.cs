using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanionAppShared;

public static class PatientLabelTools
{
	//Gym.Patient.Therapy.#rep therapy_session
	//BCN.23.RxU.0_14

	public static string GetGymLabel(string label)
	{
		var tokens = label.Split('.');
		if(tokens.Length >= 2)
		{
			if (IsLetter(tokens[0])) return tokens[0];
		}
		throw new Exception("Gym not found in patient label");
	}

	public static string GetPatientNumber(string label)
	{
		var tokens = label.Split('.');
		if (tokens.Length >= 2)
		{
			if (IsLetter(tokens[0]) && IsDigit(tokens[1])) return tokens[1];
		}
		throw new Exception("Patient number not found in patient label");
	}

	public static string GetPatientLabel(string label)
	{
		var tokens = label.Split('.');
		if (tokens.Length >= 2)
		{
			if (IsLetter(tokens[0]) && IsDigit(tokens[1])) return tokens[0] + tokens[1];
		}
		throw new Exception("Patient Label not found in patient label");
	}

	public static string GetTherapyLabel(string label)
	{
		var tokens = label.Split('.');
		if (tokens.Length >= 4)
		{
			if (IsLetter(tokens[0]) && 
				IsDigit(tokens[1]) && 
				IsLetter(tokens[2]) &&
				IsDigit(tokens[3]))
			{
				var items = tokens[3].Split('_');
				if(items.Length > 0 && IsDigit(items[0])) 
				{
					return tokens[0] + tokens[1] + tokens[2] + items[0];
				}
			}				
		}
		throw new Exception("therapy Label not found in patient label");
	}

	public static string GetTherapyKeyCode(string label)
	{
		var tokens = label.Split('.');
		if (tokens.Length >= 3)
		{
			if (IsLetter(tokens[0]) && IsDigit(tokens[1]) && IsLetter(tokens[2])) return tokens[2];
		}
		throw new Exception("therapy Label not found in patient label");
	}

	public static int GetSessionNumber(string label)
	{
		var tokens = label.Split('.');
		if (tokens.Length >= 4)
		{
			if (IsLetter(tokens[0]) &&
				IsDigit(tokens[1]) &&
				IsLetter(tokens[2]) &&
				IsDigit(tokens[3]))
			{
				var items = tokens[3].Split('_');
				if (items.Length > 0 && IsDigit(items[1]))
				{
					int.Parse(items[1]);
				}
			}				
		}
		throw new Exception("therapy Label not found in patient label");
	}

	private static bool IsLetter(string str) => str.Length > 0 && char.IsLetter(str[0]);	
	private static bool IsDigit(string str) => str.Length > 0 && char.IsDigit(str[0]);	

	public static string FormLabel(Gyms gym, int patientNumber) 
		=> gym.ToString() +"."+patientNumber.ToString();
	public static string FormLabel(Gyms gym, int patientNumber, string therapyKeyCode) 
		=> gym.ToString() + "." +patientNumber.ToString() + "." +therapyKeyCode;
	public static string FormLabel(Gyms gym, int patientNumber, string therapyKeyCode, int NumRepTherapy)
		=> gym.ToString() + "." + patientNumber.ToString() + "." + therapyKeyCode + "." + NumRepTherapy.ToString();
	public static string FormLabel(Gyms gym, int patientNumber, string therapyKeyCode, int NumRepTherapy, int NumSession)
		=> gym.ToString() + "." + patientNumber.ToString() + "." + therapyKeyCode + "." + NumRepTherapy.ToString() + "_" + NumSession.ToString();

}
