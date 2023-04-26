# ZooAPI
This is my final API Project for Zoo Animals, created in C#

Dependencies and packages:

![image](https://github.com/johntse1/ZooAPI/blob/main/dependencies.PNG)

Ensure that the connection string is set to your database.

![image](https://github.com/johntse1/ZooAPI/blob/main/connectionstring.PNG)

##Routes
## GET
### GET [/api/Zoos/{Optional ID}]
Returns all Zoos recorded in the database. If an ID is provided, it will link to the zoo with the specific id.

### Example calling GET /api/Zoos
```
[
    {
        "zooID": 1,
        "zooName": "Bronx Zoo",
        "location": "NYC"
    },
    {
        "zooID": 2,
        "zooName": "Staten Island Zoo",
        "location": "Not in NYC"
    }
]
```

### Example calling GET /api/Zoos/1
```
{
    "zooID": 1,
    "zooName": "Bronx Zoo",
    "location": "NYC"
}
```
### GET [/api/Animals/{Optional ID}]
Returns all animals available in the database. If an ID is provided, it will link to the animal with the specific id.

###Example calling GET /api/Animals
```
[
    {
        "animalID": 1,
        "animalName": "African Lion",
        "subSpecies": "Lion"
    },
    {
        "animalID": 2,
        "animalName": "Amur Tiger",
        "subSpecies": "Tiger"
    },
    {
        "animalID": 3,
        "animalName": "Anaconda",
        "subSpecies": "SubSpecies"
    },
    {
        "animalID": 4,
        "animalName": "Andean Condor",
        "subSpecies": "Condor"
    }
]
```

###Example calling GET /api/Animals/1

```
{
    "animalID": 1,
    "animalName": "African Lion",
    "subSpecies": "Lion"
}
```
### Post Requests
POST ```/api/Zoos```

Designed to put Zoo names and locations into the database

Example:
```
{
    "zooName": "Queens Zoo",
    "location": "Queens"
}
```

Which gives the result:
```
    "statusCode": 201,
    "statusDescription": "Success: Zoo was created",
    "result": {
        "zooID": 3,
        "zooName": "Queens Zoo",
        "location": "Queens"
    }
```

POST ```/api/Animals```

Designed to put Animal and locations into the database

Example:
```
{
   "animalName": "Willy Nilly Badger",
   "subSpecies": "Badger"
}
```

Which gives the result
```
{
    "statusCode": 201,
    "statusDescription": "Success: Animal added",
    "result": {
        "urlHelper": null,
        "actionName": "GetAnimals",
        "controllerName": null,
        "routeValues": {
            "id": 7
        },
        "value": {
            "animalID": 7,
            "animalName": "Willy Nilly Badger",
            "subSpecies": "Badger"
        },
        "formatters": [],
        "contentTypes": [],
        "declaredType": null,
        "statusCode": 201
    }
}
```
**NOTE: There is an optional ZooID input** 
Example:
```
{
   "animalName": "Brown Bear",
   "subSpecies": "Bear",
   "zooID":1
}
```
Result:
```
{
    "statusCode": 201,
    "statusDescription": "Success: Animal added",
    "result": {
        "urlHelper": null,
        "actionName": "GetAnimals",
        "controllerName": null,
        "routeValues": {
            "id": 8
        },
        "value": {
            "animalID": 8,
            "animalName": "Brown Bear",
            "subSpecies": "Bear"
        },
        "formatters": [],
        "contentTypes": [],
        "declaredType": null,
        "statusCode": 201
    }
}
```

