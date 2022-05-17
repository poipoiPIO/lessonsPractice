using System;
using System.Linq;
using System.Collections.Generic;

public class RouteDBase {
  public List<Route> Base { get; set; }

  public Object getInfo() => new {
      RecordCount         = Base.Count,
      LongestRouteLength  = getLongestRouteLength(),
      ShortestRouteLength = getShortestRouteLength(),
      MostExpensiveRoadCost   = getMostExpensiveRoad()
    };

  public RouteDBase(List<Route> dBase) => Base = dBase;
  public RouteDBase() => Base = new List<Route>();

  private int getShortestRouteLength() =>
    Base.Select(r => r.RouteLength).Min();

  private double getMostExpensiveRoad() =>
    Base.Select(r => r.calculateCost()).Max();

  private int getLongestRouteLength() =>
    Base.Select(route => route.RouteLength).Max();
}
