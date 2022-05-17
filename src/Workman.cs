using System;

public abstract class Workman {
  public string Name         { get; set; }
  public double  WorkHourCost { get; set; }

  public Workman(string name, double workHourCost) =>
    (Name, WorkHourCost) = (name, workHourCost);
}
