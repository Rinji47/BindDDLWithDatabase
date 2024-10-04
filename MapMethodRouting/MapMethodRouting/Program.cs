var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/Home", async (context) =>
    {
        await context.Response.WriteAsync("This is home page... GET");
    });

    endpoints.MapPost("/Home", async (context) =>
    {
        await context.Response.WriteAsync("This is home page... POST");
    });

    endpoints.MapPut("/Home", async (context) =>
    {
        await context.Response.WriteAsync("This is home page... PUT");
    });

    endpoints.MapDelete("/Home", async (context) =>
    {
        await context.Response.WriteAsync("This is home page... DELETE");
    });
});

app.Run(async (HttpContext context) => 
{
    await context.Response.WriteAsync("Page not found");
});


//app.MapGet("/", () => "Hello World!");

app.Run();
