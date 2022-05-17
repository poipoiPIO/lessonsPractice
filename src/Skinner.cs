using System;

public class Skinner : Workman {
  public double AverageSpeed { get; set; }

  public Skinner() : base("No Name", 0) => AverageSpeed = 0;

  public Skinner(string name, double workHourCost, double averageSpeed)
    : base(name, workHourCost) => AverageSpeed = averageSpeed;
}
