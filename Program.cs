using System.Collections.Generic;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
var dataBase = new RouteDBase();

var routeTable = dataBase.Base; // TODO:: Replace with DB

if (app.Environment.IsDevelopment()) {
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/info", () => {
  Object info;
  try {
    info = dataBase.getInfo();
  } catch(System.InvalidOperationException) {
    return Results.NoContent();
  }
  return Results.Ok(info);
});

app.MapGet("/routes", () =>
    Results.Ok(routeTable));

app.MapGet("/routes/moreInfo/{id}", (int id) => {
  Route route; // Will stored queried elem if exist

  try {
    route = routeTable[id];
  } catch(Exception e) {
    Console.WriteLine(e);
    return Results.NotFound();
  }

  return Results.Ok(new {
    AproximateTime = route.calculateAproximateRouteTime(),
    ApproximateCost = route.calculateCost()
  });
});

app.MapGet("/routes/{id}", (int id) => {
  Route route; // Will stored queried elem if exist

  try {
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
