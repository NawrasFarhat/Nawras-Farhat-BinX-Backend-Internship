# Day 2 — Database Schema Design

## Overview

Designed and implemented a normalized SQL Server database schema for the Day 1 API resources.

## Database

**Database:** OrderManagementDB

## Tables

### Customers
- Id — INT, Primary Key, Identity
- Name — NVARCHAR(100), NOT NULL

### Orders
- Id — INT, Primary Key, Identity
- Total — DECIMAL(18,2), NOT NULL
- CustomerId — INT, NOT NULL, Foreign Key

## Relationship

- One Customer can have many Orders.
- Each Order belongs to one Customer.
- `Orders.CustomerId` references `Customers.Id`.

## Normalization

The schema was designed following:
- 1NF
- 2NF
- 3NF

## ERD

The database relationship is illustrated in `ERD.png`.

## Tools

- SQL Server Express
- SQL Server Management Studio (SSMS)