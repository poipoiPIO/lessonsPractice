# lessonsPractice
An simple ASP.Net api for the lessons practice project 
BSU May 2022

## Schemas
### Route:
|Fields        |Type     |IsNullable?|Description              |
|--------------|---------|-----------|-------------------------|
| name         | string  | nullable  | Name of the Route       |
| arrivalPoint | string  | nullable  |                         |
| startPoint   | string  | nullable  |                         |
| routeLength  | integer | nope      | Length of the route     |
| driver       | Driver  | nope      | Driver scheme see bellow|


### Driver:
| Fields       | Type   |IsNullable?| Description        |
|--------------|--------|-----------|--------------------|
| name         | string | nullable  | Name of the Driver |
| workHourCost | number | nope      |                    |
| averageSpeed | number | nope      |                    |


## Endpoints:
| Route                 | Method  | Description                                    |
|-----------------------|---------|------------------------------------------------|
| /routes               | GET     | Response the list of all routes in DB          |
| /routes/{id}          | GET     | Response the route by ID                       |
| /routes/moreInfo/{id} | GET     | Response additional info aboute the route      |
| /info                 | GET     | Response the simple DB data statistics         |
| /routes               | POST    | Gets Route and put it into DB                  |
| /routes/{id}          | PUT     | Update the route by id, gets the Route as body |
| /routes/{id}          | DELETE  | Delete the route by it id.                     |

