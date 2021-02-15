# About

Provides an example for shortening the default timeout on when connecting to SQL-Server rather than using a connection object timeout property. If a connection fails, in this case in four seconds an exception is thrown and dealt with.

```csharp
private CancellationTokenSource _cancellationTokenSource = 
    new CancellationTokenSource(TimeSpan.FromSeconds(4));
```

Two connection strings are setup, one which will connection while the other will not as the server does not exists.

```csharp
_connectionString = RunWithoutIssues ? 
    "Data Source=.\\sqlexpressISSUE;Initial Catalog=NorthWind2020;Integrated Security=True" : 
    "Data Source=.\\sqlexpress;Initial Catalog=NorthWind2020;Integrated Security=True";
```