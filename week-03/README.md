# Week 3 – Middleware, Dependency Injection & REST API

## Overview

During Week 3, I worked on building and testing an ASP.NET Core Web API using **Middleware, Dependency Injection (DI), Entity Framework Core, SQL Server, and RESTful API concepts**.

The main resources in the project are:

- `Customers`
- `Orders`

I also used **Postman** to organize and test the API, including successful requests, error cases, response tests, and an environment using a reusable `baseUrl`.

---

## Day 1 – Middleware & Request Pipeline

The first part of the week focused on understanding how requests move through an ASP.NET Core application.

### Topics Covered

- ASP.NET Core request pipeline
- Middleware
- Request and response flow
- Custom middleware concepts
- HTTP request processing

A simplified request flow is:

```text
Client
  ↓
Middleware
  ↓
Controller
  ↓
Service / Database
  ↓
Response
  ↓
Client
```

---

## Day 2 – Dependency Injection

The second part focused on **Dependency Injection** in ASP.NET Core.

Dependency Injection allows required dependencies to be provided to a class instead of creating them manually.

```csharp
private readonly AppDbContext _context;

public OrdersController(AppDbContext context)
{
    _context = context;
}
```

The `AppDbContext` is provided to the controller through its constructor.

---

## Day 3 – Entity Framework Core & Database

I worked on connecting the ASP.NET Core API to a SQL Server database using **Entity Framework Core**.

### Main Components

- `AppDbContext`
- `Customer`
- `Order`
- `DbSet`
- Database relationships

Example:

```csharp
public class AppDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
}
```

### Database Relationship

```text
Customer 1 ───────── * Order
```

- One Customer can have many Orders.
- Each Order belongs to one Customer.
- `CustomerId` is used as the foreign key in the Orders table.

---

## Day 4 – REST API & CRUD Operations

The API was implemented using ASP.NET Core Web API and RESTful conventions.

### Customers

#### Get All Customers

```http
GET /api/Customers
```

#### Get Customer By ID

```http
GET /api/Customers/{id}
```

#### Create Customer

```http
POST /api/Customers
```

Example:

```json
{
  "name": "Lara"
}
```

### Orders

Orders were used to implement full CRUD operations.

#### Get All Orders

```http
GET /api/Orders
```

#### Get Order By ID

```http
GET /api/Orders/{id}
```

#### Create Order

```http
POST /api/Orders
```

Example:

```json
{
  "total": 500,
  "customerId": 1
}
```

#### Update Order

```http
PUT /api/Orders/{id}
```

Example:

```json
{
  "id": 6,
  "total": 600,
  "customerId": 1
}
```

ID validation:

```csharp
if (id != order.Id)
{
    return BadRequest();
}
```

#### Delete Order

```http
DELETE /api/Orders/{id}
```

Successful deletion returns:

```text
204 No Content
```

---

## HTTP Status Codes

| Status Code | Meaning |
|-------------|---------|
| `200 OK` | Request completed successfully |
| `201 Created` | Resource created successfully |
| `204 No Content` | Operation completed successfully |
| `400 Bad Request` | Invalid request or input |
| `404 Not Found` | Requested resource does not exist |
| `405 Method Not Allowed` | HTTP method is not supported |

---

## Error Handling & Error Paths

I tested successful requests as well as invalid scenarios.

### Non-Existing Order

```http
GET /api/Orders/9999
```

Expected:

```text
404 Not Found
```

### Non-Existing Order Update

```http
PUT /api/Orders/9999
```

Expected:

```text
404 Not Found
```

### Invalid Update ID

Example:

```text
URL ID: 1
Body ID: 2
```

Expected:

```text
400 Bad Request
```

### Invalid Customer

I also tested creating an Order using a Customer ID that does not exist.

---

# Day 5 – Postman Testing & Documentation

Day 5 focused on organizing, testing, and documenting the API using Postman.

## Postman Collection

I created a Postman Collection named:

```text
Week3-Middleware DI API
```

Structure:

```text
Week3-Middleware DI API
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

## Postman Environment

I created an environment named `Week3 Local` with:

```text
baseUrl = http://localhost:5107
```

Requests use:

```text
{{baseUrl}}/api/Orders
```

This avoids repeating the localhost URL.

## Postman Tests

I added response tests to verify expected status codes automatically.

```javascript
pm.test("Status code is 200", function () {
    pm.response.to.have.status(200);
});
```

## REST API Design

| Method | Endpoint | Purpose |
|--------|----------|---------|
| GET | `/api/Customers` | Get all customers |
| GET | `/api/Customers/{id}` | Get customer by ID |
| POST | `/api/Customers` | Create customer |
| GET | `/api/Orders` | Get all orders |
| GET | `/api/Orders/{id}` | Get order by ID |
| POST | `/api/Orders` | Create order |
| PUT | `/api/Orders/{id}` | Update order |
| DELETE | `/api/Orders/{id}` | Delete order |

The current API uses `/api/{resource}` routes and does not include an explicit version segment.

---

## Entity Framework Core Operations

### Add

```csharp
_context.Orders.Add(order);
await _context.SaveChangesAsync();
```

### Get All

```csharp
var orders = await _context.Orders.ToListAsync();
```

### Get By ID

```csharp
var order = await _context.Orders
    .FirstOrDefaultAsync(o => o.Id == id);
```

---

## ERD

The database contains two main entities:

```text
+------------------+          +------------------+
|    Customers     |          |      Orders      |
+------------------+          +------------------+
| PK Id            |<---------| PK Id            |
| Name             |    1 : N | Total            |
+------------------+          | FK CustomerId    |
                              +------------------+
```

The relationship is:

```text
Customer 1 ───────── * Order
```

The ERD is included separately with the Week 3 deliverables.

---

## Git & GitHub

I used Git and GitHub to manage the Week 3 work.

I practiced:

- `git status`
- `git add`
- `git commit`
- `git push`
- Branch management

The Week 3 work was organized on:

```text
feature/week-3
```

---

## Week 3 Deliverables

- ASP.NET Core REST API
- Middleware
- Dependency Injection
- Entity Framework Core
- SQL Server integration
- Customers and Orders endpoints
- CRUD operations for Orders
- Customer–Order relationship
- Error-path testing
- Postman Collection
- Postman Environment
- Postman tests
- REST API design documentation
- ERD
- Git/GitHub submission

---

## Technologies & Tools

- C#
- .NET / ASP.NET Core
- Entity Framework Core
- SQL Server
- REST APIs
- Postman
- Git
- GitHub
- Visual Studio Code

---

## Outcome

By the end of Week 3, I built and tested a database-connected REST API using ASP.NET Core.

I gained practical experience in:

- Middleware and request pipelines
- Dependency Injection
- Entity Framework Core
- SQL Server integration
- REST API design
- CRUD operations
- Database relationships
- HTTP status codes
- Error handling
- Postman API testing
- Postman environments and tests
- Git and GitHub workflow
