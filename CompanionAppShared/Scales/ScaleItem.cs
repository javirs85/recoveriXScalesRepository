using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CompanionAppShared.Scales;


public enum ScaleItemType { NotSet, IntItem, FloatItem, StringItem, TimeSpanItem, OptionsItem , InfoItem , ConditionalSection , ConditionalSectionsPack , ComplexOptionsItem };

[JsonDerivedType(typeof(IntItem), typeDiscriminator: "IntItem")]
[JsonDerivedType(typeof(FloatItem), typeDiscriminator: "FloatItem")]
[JsonDerivedType(typeof(StringItem), typeDiscriminator: "StringItem")]
[JsonDerivedType(typeof(TimeSpanItem), typeDiscriminator: "TimeSpanItem")]
[JsonDerivedType(typeof(OptionsItem), typeDiscriminator: "OptionsItem")]
[JsonDerivedType(typeof(InfoItem), typeDiscriminator: "InfoItem")]
[JsonDerivedType(typeof(ConditionalSection), typeDiscriminator: "ConditionalSection")]
[JsonDerivedType(typeof(ConditionalSectionsPack), typeDiscriminator: "ConditionalSectionsPack")]
[JsonDerivedType(typeof(ComplexOptionsItem), typeDiscriminator: "ComplexOptionsItem")]


public class ScaleItem
{
    public ScaleBase ParentScale;
    public event EventHandler UpdateNeeded;
    public event EventHandler<string> FormatError;
    public virtual string StringValue { get; set; } = string.Empty;
    public string Label { get; set; } = string.Empty;
    public string JsonCode { get; set; } = string.Empty;
    public ScaleItemType ItemType { get; set; } = ScaleItemType.NotSet;
    protected void MeasureNeedsUpdate()
    {
        //ParentScale.IsMeasured = true;
        UpdateNeeded?.Invoke(this, new EventArgs());
    }
    public string InstructionsForTheExaminer { get; set; } = string.Empty;
    public string InstructionsForThePatient { get; set; } = string.Empty;

    protected void ReportFormatError(string error) => FormatError?.Invoke(this, error);

	public int MaxValue { get; set; } = 1000;
	public int MinValue { get; set; } = -1000;
}

public class IntItem : ScaleItem
{
    public IntItem() { ItemType = ScaleItemType.IntItem; }
    public int Value { get; set; }

    public override string StringValue
    {
        get { return Value.ToString(); }
        set
        {
            var didWork = int.TryParse(value, out int i);
            if (didWork)
            {
                Value = i;
                if (Value > MaxValue) Value = MaxValue;
                if (Value < MinValue) Value = MinValue;
            }
            else ReportFormatError("Please enter an integer value");
            MeasureNeedsUpdate();
		}
    }

	public void Add()
	{
        if(Value+1 <= MaxValue)
            Value ++;
		MeasureNeedsUpdate();
	}
	public void Subtract()
	{
        if(Value-1 >= MinValue)
            Value --;
		MeasureNeedsUpdate();
	}
}


public class FloatItem : ScaleItem
{
    public FloatItem()
    {
        ItemType = ScaleItemType.FloatItem;
    }
    private decimal _value;

    public decimal Value
    {
        get { return _value; }
        set 
        { 
            _value = value;
			MeasureNeedsUpdate();
		}
    }

    public override string StringValue
	{
		get { return _value.ToString(); }
		set
		{
            var s = value.Replace('.', ',');
			var didWork = decimal.TryParse(s, out decimal i);
			if (didWork) _value = i;
			else ReportFormatError("Please enter a decimal value");
			MeasureNeedsUpdate();
		}
	}
}

public class StringItem : ScaleItem
{
    public StringItem()
    {
        ItemType = ScaleItemType.StringItem;
    }

    private string _value = string.Empty;

    public string Value
    {
        get { return _value; }
        set 
        { 
            _value = value; 
            MeasureNeedsUpdate(); 
        }
    }

    public override string StringValue
    {
        get { return Value; }
        set {
			_value = value.ToString(); 
            MeasureNeedsUpdate();
        }
    }
}

public class TimeSpanItem : ScaleItem
{
    public TimeSpanItem()
    {
        ItemType = ScaleItemType.TimeSpanItem;
    }
    private TimeSpan _value;

    public TimeSpan Value
    {
        get { return _value; }
        set 
        { 
            _value = value;
			MeasureNeedsUpdate();
		}
    }

    public override string StringValue
    {
        get
        {
            string s = "";
            if (_value.Minutes > 0) s += _value.Minutes + "m";
            s += " " + _value.Seconds + "s";
            return s;
        }
        set
        {
            var s = ParseTimeString(value);
            if (s is not null)
            {
				_value = (TimeSpan)s;
                MeasureNeedsUpdate();
            }
            else
				ReportFormatError("The format must be 2h 45m 12s");

		}
    }

    private TimeSpan? ParseTimeString(string timeString)
    {
        int RawNumber = 0;
        bool isRawNumber = int.TryParse(timeString, out RawNumber);
        if(isRawNumber)
            return TimeSpan.FromSeconds(RawNumber);

		Regex regex = new Regex(@"\s*(?:(\d+)h\s*)?(?:(\d+)m\s*)?(?:(\d+)s)?");
		Match match = regex.Match(timeString);

		if (match.Success)
		{
			int hours = match.Groups[1].Success ? int.Parse(match.Groups[1].Value) : 0;
			int minutes = match.Groups[2].Success ? int.Parse(match.Groups[2].Value) : 0;
			int seconds = match.Groups[3].Success ? int.Parse(match.Groups[3].Value) : 0;

			return new TimeSpan(hours, minutes, seconds);
		}
		else
		{
            return null;
		}
	}
}

public class OptionsItem : ScaleItem
{
    public OptionsItem()
    {
        ItemType = ScaleItemType.OptionsItem;
    }

    public List<string> Options { get; set; } = new List<string>();
    private string _selectedOption = string.Empty;
    public string SelectedOption
    {
        get
        {
            return _selectedOption;
        }
        set
        {
            if (Options.Contains(value))
            {
                _selectedOption = value;
				MeasureNeedsUpdate();
			}
        }
    }

	public override string StringValue
    {
        get
        {
            return SelectedOption;
        }
        set
        {
            SelectedOption = value;
        }
    }
}

public class InfoItem : ScaleItem
{
    public InfoItem()
    {
        ItemType = ScaleItemType.InfoItem;
    }
    public string Label { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public bool DefaultOpen { get; set; } = true;
}

public class ConditionalSectionsPack : ScaleItem
{
    public ConditionalSectionsPack()
    {
            ItemType = ScaleItemType.ConditionalSection;
    }
    public List<ConditionalSection> ConditionalSections { get; set; } = new();
}

public class ConditionalSection : ScaleItem
{
    public ConditionalSection()
    {
        ItemType = ScaleItemType.ConditionalSection;
    }

    public event EventHandler ToggledVisibility;
	private bool _isVisible;

	public bool IsVisible
	{
		get { return _isVisible; }
		set
		{
			if (_isVisible != value)
			{
				_isVisible = value;
				ToggledVisibility?.Invoke(this, EventArgs.Empty);
			};
		}
	}

    public void Toggle() => IsVisible = !IsVisible;


	public string Label { get; set; } = string.Empty;
    public string InstructionsForTheExaminer { get; set; } = string.Empty;
    public List<ScaleItem> Items { get; set; } = new();
}


public class ComplexOptionsItem : ScaleItem
{
    public ComplexOptionsItem()
    {
        ItemType = ScaleItemType.ComplexOptionsItem;
    }

    public int Value => SelectedOption?.Value ?? -1;

    public List<Option> Options { get; set; } = new();

    private Option? _selectedOption;

    public Option? SelectedOption
    {
        get { return _selectedOption; }
        set { _selectedOption = value;
			MeasureNeedsUpdate();
		}
    }

    public void ForceOption(int i)
    {
        if (i == -1) SelectedOption = null;
        else
            SelectedOption = Options[i];
    }


	public override string StringValue
	{
		get { return Value.ToString(); }
		set
		{
            int v = 0;
            var canParse = int.TryParse(value, out v);
            if(canParse)
                ForceOption(v);
            else
            {
                var o = Options.Find(x => x.Name == value);
                if (o is not null)
                    SelectedOption = o;
            }

			MeasureNeedsUpdate();
		}
	}

	public class Option
    {
        public int Value { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
