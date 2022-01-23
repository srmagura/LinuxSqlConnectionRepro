# LinuxSqlConnectionRepro

This project shows that Entity Framework Core encounters a segmentation fault on
Linux if the SQL Server connection string contains `Trusted_Connection=True;`.

## Reproduction Steps

Preconditions:

- You are using Linux. This was tested on Ubuntu 21.10.
- You have a SQL Server installation available at `localhost`.

Steps:

1. `dotnet tool restore`
2. `dotnet ef database update`

## Actual Behavior

`dotnet ef database update` exits with code 139. Apparently, this indicates a
segfault because 139 = 128 + 11 and 11 = segfault.

## Expected Behavior

`dotnet ef database update` fails with a helpful .NET stack trace and does not
segfault.

## Additional Context

I tested opening a `SqlConnection` with `Microsoft.Data.SqlClient` and the same
connection string. It produced a helpful stack trace instead of segfaulting.

`dotnet ef database update` succeeds if a valid connection string is provided.
(Remove `Trusted_Connection=True;`, add `User` and `Password`.)
