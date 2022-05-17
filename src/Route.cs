using System;

public class Route {
  public string?  Name           { get; set; }
  public string?  ArrivalPoint   { get; set; }
  public string?  StartPoint     { get; set; }
  public int      RouteLength    { get; set; }
  public virtual Skinner Driver  { get; set; }

  public Route() =>
    (Name, ArrivalPoint, StartPoint, RouteLength, Driver) =
      ("No name", "Undefined", "Undefined", 0, new Skinner());

  public Route
    (string name, string arrivalPoint, string startPoint, int routeLength, Skinner Driver) =>
    (Name, ArrivalPoint, StartPoint, RouteLength, Driver) =
      (name, arrivalPoint, startPoint, routeLength, Driver);

  public double calculateAproximateRouteTime() =>
    RouteLength / Driver.AverageSpeed;

  public double calculateCost() =>
    RouteLength > 1000 ?
      Driver.WorkHourCost * 1.25 * calculateAproximateRouteTime():
      Driver.WorkHourCost * calculateAproximateRouteTime();

  override public string ToString() =>
    $"______The ROUTE______\n" +
    $"Name:             {Name}\n" +
    $"Approximate Time: {calculateAproximateRouteTime()} \n" +
    $"Cost:             {calculateCost()}\n" +
    $"Driver:           {Driver.Name}";
}
