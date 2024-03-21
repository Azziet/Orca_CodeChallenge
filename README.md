# Orca Coding Challenge - Contract Management system - .Net Core Web API

## Overview
This is an API endpoint for a Contract Management system using Domain-Driven Design (DDD) principles. 

### Implementation Criteria -
- Define two core entities: "Contracts" and "Products."
- Consider Domain Modelling
- Use Sets instead Lists
- No Use Of foreach loop
- Datasource - Update 200 records using the below contracts json format, into redis cache (docker image)


### Evaluation Criteria - 
- API response time
- Adherence to DDD principles and best practices.
- Proper implementation of the Service Layer and Repository layer.
- Effective use of sets and alternative constructs for traversing records.
- Clear and concise API design.
- Proper documentation of the code and design choices.

### Expected output - 

```
"Contracts": {
  "_id": "GUID",
  "Name": "Contract Name",
  "CountryId": 4,
  "Products": [
    {
      "_id": "GUID",
      "Elements": [
        {
          "_t": "VolumeRisk",
          "Fee": "-33.53 EUR/MWh"
        },
        {
          "_t": "CrossSubsidization",
          "Price": null
        }
      ]
    }
  ]
}
```

## Solution Approach

Domain Driven Design (DDD) has been used to implement the given challenge. 
As part of the solution, **3 projects** have been defined -
- POC.API - This contains the *Application Layer*
- POC.Domain - This contains the *Domain Model Layer*
- POC.Infrastructure - This contains the *Infrastructure Layer*

1. *POC.API* contains the API Controller which is responsible for handling inputs. `GET` and `POST` methods have been implemented to store and retrieve Contracts.
2. *POC.Domain* contains the Entity models for `Contract`, `Product` and `Element`. It also contains a `Root` model to wrap the `Contract` object.
3. *POC.Infrastructure* contains the logic for interacting with the Repository, which in this case is **Azure Cache for Redis**.  

**The solution is implemented using .NET 8**

### How To Run
Pull the code present in `master` and use **Visual Studio 2022** to run. Set Startup Project as ***POC.API***

1. For `POST` Method, use - 
```
POST http://localhost:5284/api/Contracts
```

2. For `GET` Method use -
```
GET http://localhost:5284/api/Contracts/<your_guid>
```

### Sample Requests -
1. `POST` Request - 
```
{
  "Contracts": {
    "_id": "69000ae0-ea25-4b77-a531-10c4ef8030ae",
    "Name": "Contract Name",
    "CountryId": 4,
    "Products": [
      {
        "_id": "8dc507fc-2c87-45dc-a395-35a726ce12b3",
        "Elements": [
          {
            "_t": "VolumeRisk",
            "Fee": "-33.53 EUR/MWh"
          },
          {
            "_t": "CrossSubsidization",
            "Price": null
          }
        ]
      }
    ]
  }
}
```
#### Responses -
Success Response - `200 OK` with the message - `Contract created successfully`

2. `GET` Request -
```
GET http://localhost:5284/api/Contracts/69000ae0-ea25-4b77-a531-10c4ef8030ae
```

#### Responses -
Success - `200 OK` with associated `Contract`.   

In case Contract does not exist - `404 Not Found`   



**Test for as many unique GUIDs as required.**


### References - 
https://learn.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/ddd-oriented-microservice
