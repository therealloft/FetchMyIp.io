var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseHttpsRedirection();

app.MapGet("", (HttpContext context, string? format, string? callback) =>
{
    var ipAddress = context.Connection.RemoteIpAddress;
    var ipv4Address = ipAddress != null && ipAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork
        ? ipAddress.ToString()
        : null;

    if (ipv4Address == null)
        return Results.BadRequest("No IPv4 address found");

    if (string.IsNullOrEmpty(format) && string.IsNullOrEmpty(callback))
        return Results.Text(ipv4Address);

    if (!string.IsNullOrEmpty(format))
    {
        switch(format.ToLower())
        {
            case "json":
                return Results.Json(new { ip = ipv4Address });

            case "xml":
                context.Response.ContentType = "application/xml";
                return Results.Text($"<ip>{ipv4Address}</ip>", "application/xml");

            case "jsonp":
                if (string.IsNullOrEmpty(callback))
                    return Results.Text($"callback({{\"ip\":\"{ipv4Address}\"}})");

                if (!string.IsNullOrEmpty(callback) && callback.Length > 0)
                    return Results.Text($"{callback}({{\"ip\":\"{ipv4Address}\"}})");

                return Results.BadRequest("Invalid format");
        }
    }
    return Results.BadRequest("Invalid request");
});
app.Run();