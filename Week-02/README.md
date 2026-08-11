# Week 02 – Backend Internship

During Week 02, I focused on advanced C# concepts and started working with ASP.NET Core to understand how backend applications are structured.

---

## Day 01 – Generics & Repository Pattern

Focused on writing reusable and type-safe code using **Generics** and applying the **Repository Pattern**.

### Topics
- Generics and `Repository<T>`
- `List<T>` and `IReadOnlyList<T>`
- `Func<T, bool>`
- Lambda expressions
- `Add()`, `GetAll()`, and `Find()`

Example:

```csharp
public T? Find(Func<T, bool> predicate)
{
    return items.FirstOrDefault(predicate);
}
```

**Key takeaway:** Generics allow the same repository logic to work with different models without duplicating code.

---

## Day 02 – LINQ & Data Processing

Practiced using **LINQ** to query and process collections of customers and orders.

### Topics
- `Where()` and `Select()`
- `Join()` between related collections
- `GroupBy()`
- `Sum()` and `Count()`
- Deferred Execution
- Lambda expressions

Example:

```csharp
var result = customers.Join(
    orders,
    c => c.Id,
    o => o.CustomerId,
    (c, o) => new { c.Name, o.Total }
);
```

**Key takeaway:** LINQ makes it easier to filter, combine, group, and analyze data stored in collections.

---

## Day 03 – Async Programming

Explored asynchronous programming and compared **sequential vs. concurrent execution**.

### Topics
- `async` / `await`
- `Task`
- `Task.WhenAll()`
- `Stopwatch`
- `CancellationToken`
- `CancellationTokenSource`
- Handling `OperationCanceledException`

Example:

```csharp
var task1 = GetDatabaseDataAsync();
var task2 = GetApiDataAsync();
var task3 = GetFileDataAsync(CancellationToken.None);

await Task.WhenAll(task1, task2, task3);
```

I compared running three operations sequentially with running them concurrently and observed the difference in execution time.

I also practiced cancelling a running task using a `CancellationToken`.

**Key takeaway:** Async programming improves efficiency when working with operations such as APIs, databases, and files.

---

## Day 04 – ASP.NET Core Web API

Started building a basic **ASP.NET Core Web API** and understanding how requests are mapped to endpoints.

### Topics
- ASP.NET Core Web API
- Minimal APIs
- Controllers
- Models
- Routing
- `MapGet()`
- `[ApiController]`
- `[Route]` and `[HttpGet]`
- Route parameters

Created endpoints such as:

```http
GET /customers
GET /customers/{id}
```

Then moved from Minimal APIs to a `CustomersController` to better organize the endpoints.

Example:

```csharp
[HttpGet("{id}")]
public Customer? GetCustomer(int id)
{
    return customers.FirstOrDefault(c => c.Id == id);
}
```

**Key takeaway:** Controllers and routing provide a structured way to handle HTTP requests and expose application data through APIs.

---
### API Endpoints

Implemented and tested four GET endpoints using both Controllers and Minimal APIs:

- `GET /api/Customers` – Get all customers using a Controller.
- `GET /api/Customers/{id}` – Get a customer by ID using a Controller.
- `GET /Customers` – Get all customers using a Minimal API.
- `GET /Customers/{id}` – Get a customer by ID using a Minimal API.
  
## Day 05 – Middleware & Dependency Injection

Focused on understanding the **HTTP request pipeline** and separating application logic using services and Dependency Injection.

### Topics
- Middleware
- `app.Use()` and `next()`
- HTTP Request Pipeline
- Services and Interfaces
- Dependency Injection
- Constructor Injection
- `AddScoped()`

Created custom middleware to log incoming requests:

```csharp
app.Use(async (context, next) =>
{
    Console.WriteLine(
        $"{context.Request.Method} {context.Request.Path}"
    );

    await next();
});
```

Then created:

```text
ICustomerService
        ↓
CustomerService
        ↓
CustomersController
```

and registered the service:

```csharp
builder.Services.AddScoped<ICustomerService, CustomerService>();
```

**Key takeaway:** Middleware controls how requests move through the application, while Dependency Injection helps separate responsibilities and reduce coupling between components.

---

## Week 02 Summary

By the end of this week, I practiced the progression from core C# concepts into ASP.NET Core backend development:

```text
Generics & Repository Pattern
          ↓
LINQ & Data Processing
          ↓
Async Programming
          ↓
ASP.NET Core Web APIs
          ↓
Controllers & Routing
          ↓
Middleware & Dependency Injection
```

This week helped me understand not only how to write backend functionality, but also how to organize it into reusable and maintainable components.
