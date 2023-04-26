# ZooAPI
This is my final API Project for Zoo Animals, created in C#

Dependencies and packages:
![image](https://github.com/johntse1/ZooAPI/blob/main/dependencies.PNG)

Ensure that the connection string is set to your database.
![image](https://github.com/johntse1/ZooAPI/blob/main/connectionstring.PNG)

##Routes
## GET
### GET [/api/Zoos/{Optional ID}]
Returns all Zoos recorded in the database. If an ID is provided, it will link to to the zoo with the specific id.

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
###Example calling GET
