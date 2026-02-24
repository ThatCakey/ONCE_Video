namespace once.Models;

public abstract record ControlItem(string Name);

public record NumericControlItem(string Name, double Value, double Min = 0, double Max = 100) : ControlItem(Name);
public record ColorControlItem(string Name, string HexColor) : ControlItem(Name);
