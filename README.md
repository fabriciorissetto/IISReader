# IISReader
A simple API to get sites and subsites hosted on the IIS of the current machine

Example request:

    GET http://localhost:53992/api/Sites

Response:

    [{
        "Name": "yoursite.com",
        "Projects": [{
            "Name": "WebPortal",
            "Environment": "",
            "Applications": [
              "AngularFrontEnd",
              "WebAPI"
            ]}
        ]
    }]

## Swagger

    http://localhost:53992/swagger

![alt tag](https://github.com/fabriciorissetto/IISReader/blob/master/sample.png)
