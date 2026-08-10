using System.Diagnostics;
static async Task GetDatabaseDataAsync()
{
    await Task.Delay(2000);
}

static async Task GetApieDataAsync()
{
    await Task.Delay(3000);
}

static async Task GetFileDataAsync(CancellationToken token)
{
    await Task.Delay(4000, token);
}

var stopwatch= Stopwatch.StartNew();

await GetDatabaseDataAsync();
await GetApieDataAsync();
await GetFileDataAsync(CancellationToken.None);

stopwatch.Stop();
Console.WriteLine($"Seconds: {stopwatch.Elapsed.TotalSeconds}");

var stopwatch2=Stopwatch.StartNew();

var Task1=GetDatabaseDataAsync();
var Task2=GetApieDataAsync();
var Task3=GetFileDataAsync(CancellationToken.None);

await Task.WhenAll(Task1,Task2,Task3);
stopwatch2.Stop();
Console.WriteLine($"Seconds2: {stopwatch2.Elapsed.TotalSeconds}");

var cts=new CancellationTokenSource();
var fileTask=GetFileDataAsync(cts.Token);
await Task.Delay(2000);
cts.Cancel();
try
{
    await fileTask;
}
catch(OperationCanceledException)
{
    Console.WriteLine("File Operation was Cancelled");
}