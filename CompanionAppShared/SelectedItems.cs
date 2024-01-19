using CompanionAppShared.Scales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanionAppShared;

public class SelectedItems
{
	List<Patient> AllPatients { get; set; } = new();
	public Patient? SelectedPatient { get; set; } 
	public Therapy? SelectedTherapy { get; set; }
	public Session? SelectedSession { get; set; } 
	public IScale? SelectedScale { get; set; }

	public event EventHandler UpdateRequired;
	public void UpdateUI() => UpdateRequired?.Invoke(this, EventArgs.Empty);
}
