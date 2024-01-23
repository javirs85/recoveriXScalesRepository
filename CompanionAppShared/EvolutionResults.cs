using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanionAppShared;

public class EvolutionResults
{
    public int InitialPreVale = 0;
    public int LastPreValue = 0;
    public int AveragedPreValue = 0;
    public bool HasNonPreValues = false;
    public int FinalValue = 0;
    public int Increase
    {
        get
        {
            if (HasNonPreValues) return FinalValue - AveragedPreValue;
            else return LastPreValue - InitialPreVale;
        }
    }
}
