# IISReader
A simple API to get sites and subsites hosted on the IIS of the current machine

Example request:

    GET http://localhost:53992/api/Sites

Response:

    [{
        "Name": "anothersite.com",
        "Projects": [{
            "Name": "WebPortal",
            "Environment": "",
            "Applications": [
              "AngularFrontEnd",
              "WebAPI"
            ]}
        ]
    }]
