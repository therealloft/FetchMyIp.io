var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();
app.UseHttpsRedirection();
app.UseCors();

app.MapGet("", (HttpContext context, string? format, string? callback) =>
{
    var ipAddress = context.Connection.RemoteIpAddress?.ToString();
    if (string.IsNullOrEmpty(ipAddress))
        return Results.BadRequest("No IP address found");

    if (string.IsNullOrEmpty(format) && string.IsNullOrEmpty(callback))
        return Results.Text(ipAddress);

    if (!string.IsNullOrEmpty(format))
    {
        switch(format.ToLower())
        {
            case "json":
                return Results.Json(new { ip = ipAddress });

            case "xml":
                context.Response.ContentType = "application/xml";
                return Results.Text($"<ip>{ipAddress}</ip>", "application/xml");

            case "jsonp":
                if (string.IsNullOrEmpty(callback))
                    return Results.Text($"callback({{\"ip\":\"{ipAddress}\"}})");

                if (!string.IsNullOrEmpty(callback) && callback.Length > 0)
                    return Results.Text($"{callback}({{\"ip\":\"{ipAddress}\"}})");

                return Results.BadRequest("Invalid format");
        }
    }
    return Results.BadRequest("Invalid request");
});
app.Run();