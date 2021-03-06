<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Drawing.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Windows.Forms</Namespace>
</Query>

void Main()
{
    MainAsync().Wait();    
}

static async Task MainAsync()
{
    Task<int> task = ComputeLengthAsync(null);
    // We never get this far, as the exception is thrown eagerly.
    Console.WriteLine("Fetched the task");
    int length = await task;
    Console.WriteLine("Length: {0}", length);
}

static Task<int> ComputeLengthAsync(string text)
{
    if (text == null)
    {
        throw new ArgumentNullException("text");
    }
    return ComputeLengthAsyncImpl(text);
}

static async Task<int> ComputeLengthAsyncImpl(string text)
{
    await Task.Delay(500); // Simulate real asynchronous work
    return text.Length;
}
