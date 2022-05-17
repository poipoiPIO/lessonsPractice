using System.Collections.Generic;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var routeTable = new List<Route> {
// TODO:: Replace with DB
  new Route(
    "Example Road",
    "Celestia",
    "GoverLand",
    2001,
    new Skinner("Victor", 10.1, 102.3)
  )
};

if (app.Environment.IsDevelopment()) {
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/routes", () =>
    Results.Ok(routeTable));

app.MapGet("/routes/{id}", (int id) => {
  Route route; // Will stored queried elem if exist

  try{
    route = routeTable[id];
  } catch(Exception e) {
    Console.WriteLine(e);
    return Results.NotFound();
  }

  return Results.Ok(route);
});

app.MapPost("/routes", (Route route) => {
  routeTable.Add(route);

  return Results.Created($"/routes/{routeTable.Count}", route);
});

app.MapPut("/routes/{id}", (int id, Route route) => {
  try{
    routeTable[id] = route;
  } catch(Exception e) {
    Console.WriteLine(e);
    return Results.NotFound();
  }

  return Results.NoContent();
});

app.MapDelete("/routes/{id}", (int id) => {
  Route route;
  try{
    route = routeTable[id];
    routeTable.RemoveAt(id);
  } catch(Exception e) {
    Console.WriteLine(e);
    return Results.NotFound();
  }

  return Results.Ok(route);
});

app.Run();
