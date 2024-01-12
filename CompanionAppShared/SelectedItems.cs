using CompanionAppShared.Scales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanionAppShared;

public class SelectedItems
{
	public Patient SelectedPatient { get; set; } = new Patient();
	public Therapy SelectedTherapy { get; set; } = new Therapy();
	public Session? SelectedSession { get; set; } 

	public IScale SelectedScale = new BlocksAndBlocksTest();
}
