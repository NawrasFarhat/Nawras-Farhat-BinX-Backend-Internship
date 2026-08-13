# Week 3 – Backend Development with .NET

## Overview

During Week 3, I focused on backend development using **C# and .NET**, starting with C# fundamentals and gradually moving toward building, connecting, testing, and documenting a database-connected REST API.

The week covered **C# fundamentals, OOP, LINQ, asynchronous programming, ASP.NET Core Web APIs, Dependency Injection, Entity Framework Core, SQL Server, CRUD operations, API testing, Postman, and Git/GitHub**.

---

## Day 1 – C# Fundamentals

The first day focused on strengthening my C# fundamentals and understanding concepts commonly used in backend development.

### Topics Covered

- Classes and Objects
- Object-Oriented Programming
- Lists and Collections
- Records
- Generics
- LINQ
- `async` / `await`
- `Task`

### Example – LINQ

```csharp
List<Order> orders = new List<Order>();

var result = orders
    .Where(o => o.Total > 100)
    .ToList();
```

### Example – Asynchronous Programming

```csharp
public async Task<string> GetDataAsync()
{
    return await Task.FromResult("Data");
}
```

---

## Day 2 – ASP.NET Core & REST APIs

The second day focused on building REST APIs using **ASP.NET Core**.

I learned how Controllers handle HTTP requests and how different HTTP methods are used to perform operations on resources.

### HTTP Methods

| Method | Purpose |
|--------|---------|
| GET | Retrieve data |
| POST | Create data |
| PUT | Update data |
| DELETE | Delete data |

### Example Controller

```csharp
[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
}
```

I also practiced working with common HTTP status codes:

- `200 OK`
- `201 Created`
- `204 No Content`
- `400 Bad Request`
- `404 Not Found`

---

## Day 3 – Dependency Injection & Database Integration

Day 3 focused on **Dependency Injection** and connecting the API to a real SQL Server database.

### Dependency Injection

I learned how ASP.NET Core provides dependencies through its built-in Dependency Injection container.

```csharp
private readonly AppDbContext _context;

public OrdersController(AppDbContext context)
{
    _context = context;
}
```

Instead of creating `AppDbContext` manually inside the controller, ASP.NET Core provides it through the constructor.

### Entity Framework Core

I used **Entity Framework Core** to communicate with SQL Server and created an `AppDbContext`.

```csharp
public class AppDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
}
```

This allowed the API to work with persistent data stored in the database.

---

## Day 4 – Database-Connected API & CRUD

Day 4 focused on building a complete API connected to SQL Server using Entity Framework Core.

I worked with two main entities:

- `Customer`
- `Order`

An Order is connected to a Customer through `CustomerId`.

### CRUD Operations

I implemented full CRUD operations for the `Order` resource.

### Create Order

```http
POST /api/Orders
```

Example request:

```json
{
    "total": 100,
    "customerId": 1
}
```

### Get All Orders

```http
GET /api/Orders
```

### Get Order By ID

```http
GET /api/Orders/1
```

### Update Order

```http
PUT /api/Orders/1
```

Example:

```json
{
    "id": 1,
    "total": 250,
    "customerId": 1
}
```

I also added ID validation:

```csharp
if (id != order.Id)
{
    return BadRequest();
}
```

### Delete Order

```http
DELETE /api/Orders/1
```

A successful delete returns:

```text
204 No Content
```

### Error Handling

I tested different error scenarios, including:

- Requesting an Order that does not exist → `404 Not Found`
- Updating a non-existing Order → `404 Not Found`
- Sending different IDs in the URL and body → `400 Bad Request`
- Using an invalid `CustomerId`

I used **Postman** to test both successful and unsuccessful requests.

---

## Day 5 – API Testing & Documentation

The final day focused on organizing and testing the API using **Postman**.

### Postman Collection

I created and organized a collection:

```text
Week 3 - Middleware DI API
│
├── Customers
│   ├── Get All Customers
│   ├── Get Customer By ID
│   └── Create Customer
│
└── Orders
    ├── Get All Orders
    ├── Get Order By ID
    ├── Create Order
    ├── Update Order
    ├── Delete Order
    └── Error Cases
```

### Postman Tests

I added response tests to automatically verify API responses.

```javascript
pm.test("Status code is 200", function () {
    pm.response.to.have.status(200);
});
```

### Postman Environment

I created a Postman Environment with a reusable `baseUrl`:

```text
baseUrl = http://localhost:5107
```

Requests can use:

```text
{{baseUrl}}/api/Orders
```

This makes the collection easier to maintain.

---

## Git & GitHub

Throughout the week, I used Git and GitHub to manage my work.

I practiced:

- `git status`
- `git add`
- `git commit`
- `git push`
- Working with branches

The Week 3 work was pushed to:

```text
feature/week-3
```

---

## Technologies & Tools

- C#
- .NET
- ASP.NET Core
- Entity Framework Core
- SQL Server
- REST APIs
- Postman
- Git
- GitHub
- Visual Studio Code

---

## Outcome

By the end of Week 3, I moved from working with C# fundamentals to building a **database-connected REST API** using ASP.NET Core.

I gained practical experience with:

- C# and OOP
- LINQ and asynchronous programming
- REST API development
- Dependency Injection
- Entity Framework Core
- SQL Server
- CRUD operations
- API error handling
- Postman testing
- Git and GitHub workflow

This week helped me understand how different backend components work together to build and test a complete API.

---

## Task 5 – Week 3 Close-Out

### REST Resource Design

The API was designed around two main resources:

- `Customers`
- `Orders`

### Endpoint List

| Method | Endpoint | Purpose | Expected Status |
|--------|----------|---------|-----------------|
| GET | `/api/Customers` | Get all customers | `200 OK` |
| GET | `/api/Customers/{id}` | Get customer by ID | `200 OK` / `404 Not Found` |
| POST | `/api/Customers` | Create customer | `201 Created` |
| GET | `/api/Orders` | Get all orders | `200 OK` |
| GET | `/api/Orders/{id}` | Get order by ID | `200 OK` / `404 Not Found` |
| POST | `/api/Orders` | Create order | `201 Created` |
| PUT | `/api/Orders/{id}` | Update order | `204 No Content` / `400 Bad Request` / `404 Not Found` |
| DELETE | `/api/Orders/{id}` | Delete order | `204 No Content` / `404 Not Found` |

### Status Codes

The API uses standard HTTP status codes to describe the result of each request:

- `200 OK` – Request completed successfully.
- `201 Created` – A new resource was created.
- `204 No Content` – Operation completed successfully without a response body.
- `400 Bad Request` – Invalid request or input.
- `404 Not Found` – Requested resource does not exist.

### Versioning Convention

The current API uses the `/api/{resource}` route convention, for example:

```text
/api/Customers
/api/Orders
```

No explicit version segment is currently included in the route.

---

### Database ERD

The database contains two main entities: `Customers` and `Orders`.

```text
+------------------+          +------------------+
|    Customers     |          |      Orders      |
+------------------+          +------------------+
| PK Id            |<---------| PK Id            |
| Name             |     1 : N | Total            |
+------------------+          | FK CustomerId    |
                              +------------------+
```

Relationship:

- One Customer can have many Orders.
- Each Order belongs to one Customer.
- `Orders.CustomerId` is the foreign key that references `Customers.Id`.

---

### Postman Collection

All API requests were organized into a Postman Collection:

```text
Week 3 - Middleware DI API
│
├── Customers
│   ├── Get All Customers
│   ├── Get Customer By ID
│   └── Create Customer
│
└── Orders
    ├── Get All Orders
    ├── Get Order By ID
    ├── Create Order
    ├── Update Order
    ├── Delete Order
    └── Error Cases
```

The collection includes both successful requests and error-path requests to verify how the API handles invalid input and missing resources.

A Postman Environment was also created with:

```text
baseUrl = http://localhost:5107
```

Requests use:

```text
{{baseUrl}}/api/Orders
```

The Postman Collection can be exported as a JSON file and submitted with the Week 3 deliverables.

---

### Week 3 Close-Out Summary

By the end of Week 3, I completed a database-connected REST API and documented its resources, endpoints, status codes, database relationships, and API tests.

The final deliverables include:

- REST resource design and endpoint documentation.
- Database ERD showing the Customer–Order relationship.
- Organized Postman Collection.
- Error-path requests.
- Postman status-code tests.
- Postman Environment with a reusable `baseUrl`.
- Week 3 summary and documentation.
