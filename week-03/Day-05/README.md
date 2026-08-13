# Day 05 – API Testing & Documentation

## Overview

During Day 5, I focused on testing and documenting the REST API using Postman.

The main goal was to verify that the implemented endpoints work correctly for both successful requests and different error scenarios.

## Postman Collection

I organized the API requests in a Postman Collection and tested the available endpoints for the `Orders` resource.

The collection included:

- Get All Orders
- Get Order By ID
- Create Order
- Update Order
- Delete Order
- Error-path requests

## API Testing

I tested both successful and unsuccessful requests.

### Successful Scenarios

The successful requests included:

- `GET` requests for retrieving orders
- `POST` request for creating an order
- `PUT` request for updating an order
- `DELETE` request for deleting an order

### Error Scenarios

I also tested different error paths, including:

- Requesting an order that does not exist
- Updating a non-existing order
- Deleting a non-existing order
- Sending invalid update data
- Creating an order with an invalid `CustomerId`

These tests helped verify that the API returns appropriate HTTP status codes.

## HTTP Status Codes

The API was tested with different response codes, including:

| Status Code | Meaning |
|-------------|---------|
| 200 | OK |
| 201 | Created |
| 204 | No Content |
| 400 | Bad Request |
| 404 | Not Found |
| 500 | Internal Server Error |

## Postman Environment

A Postman environment was used with the following variable:

```text
baseUrl = http://localhost:5107
```

Requests were written using:

```text
{{baseUrl}}/api/Orders
```

This makes the requests easier to maintain and reuse.

## Postman Tests

Basic tests were added to verify the expected response status.

Example:

```javascript
pm.test("Status Code is 200", function () {
    pm.response.to.have.status(200);
});
```

## API Documentation

A detailed PDF was prepared containing the API requests, endpoints, request/response examples, status codes, successful scenarios, and error-path testing.

### Complete Documentation

**[View Day 05 API Documentation](https://drive.google.com/file/d/1vo31DBRECA94-mzdAgh66BRCFbbh6eo1/view?usp=sharing)**

## Tools Used

- Postman
- ASP.NET Core Web API
- C#
- Entity Framework Core
- SQL Server
- Visual Studio Code
- Git & GitHub

## Outcome

By the end of Day 5, I had tested the implemented REST API through Postman, verified successful and error scenarios, organized the requests into a collection, and prepared detailed documentation for the API.
