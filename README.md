# Orca Coding Challenge - Contract Management system [.Net Core Web API]

## Overview
This is an API endpoint for a Contract Management system using Domain-Driven Design (DDD) principles. 

### Contract Schema - 

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

## Layers in the project repo

Domain Driven Design (DDD) has been used to implement the API end point. 

## 1. Application
**Definition:**
> Application - Application Layer: Defines the jobs of the API is supposed to do and directs the expressive domain objects to work out problems. The tasks this layer is responsible for are meaningful to the business or necessary for interaction with the application layers of other systems

*Orca.API* contains the API Controller which is responsible for handling inputs. `GET`, `DELETE` and `POST` methods have been implemented to store and retrieve Contracts.

## 2. Domain

**Definition:**
> Domain - A place to define logic concepts, principles, patterns, and behaviors of data, including domain validation, calculations, and expressions for system operations.

*Orca.Domain* contains the Entity models for `Contract`, `Product` and `Element`.

## 3. Infratructure

**Definition:**
> Infrastructure - The infrastructure layer is how the data that is initially held in domain entities (in memory) is persisted in databases or another persistent store.

*Orca.Infrastructure* contains Repository layer interacting with **Azure Cache for Redis**.  


### API Consumption
Pull the code present in `master` and use **Visual Studio** to run. Set Startup Project as ***Orca.API***. It will open Swagger UI Page
https://localhost:<port>/swagger/index.html

![image](https://github.com/AjitAccent/Orca_CodeChallenge/assets/164047233/5aeff173-1e71-46f2-8bbf-33eaa4d3ea22)

1.  `GET` Method
```
GET http://localhost:`<port>`/api/Contract/<guid>
```
![image](https://github.com/AjitAccent/Orca_CodeChallenge/assets/164047233/0a993235-d339-42ee-9d1d-11012e862639)

2. `POST` Method
```
POST http://localhost:`<port>`/api/Contract/
```
![image](https://github.com/AjitAccent/Orca_CodeChallenge/assets/164047233/14d5c76e-b159-43f7-b12c-6938059feded)

3. `DELETE` Method
```
DELETE http://localhost:<port>/api/Contract/<guid>
```
![image](https://github.com/AjitAccent/Orca_CodeChallenge/assets/164047233/03f80826-28b0-4e78-b950-d14e380218b2)

### Sample Requests -
1. `POST` Request -

URL
```
POST http://localhost:<port>/api/Contract/
```
BODY

```
{
  "_id": "ea0d1554-3d34-4f6d-90da-fba626d1d6a0",
  "Name": "Contract Name",
  "CountryId": 4,
  "Products": [
    {
      "_id": "df4b5d82-c2ed-4491-91d7-4c1648845b97",
      "Elements": [
        {
          "_t": "VolumeRisk",
          "Fee": "44.53 EUR/MWh"
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
#### Responses -
Success Response - `200 OK`

2. `GET` Request -
```
GET http://localhost:<port>/api/Contract/ea0d1554-3d34-4f6d-90da-fba626d1d6a0
```

#### Responses -
Success - `200 OK` with associated `Contract`

3. `DELETE` Request -
```
DELETE http://localhost:<port>/api/Contract/ea0d1554-3d34-4f6d-90da-fba626d1d6a0
```

#### Responses -
Success - `200 OK`    

***Note*** - In case Contract does not exist - `404 Not Found`   

