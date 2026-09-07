using PcStore.Application.Abstractions;
using PcStore.DataAccess;
using PcStore.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDataAccess(builder.Configuration);
builder.Services.AddInfrastructure();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapHealthChecks("/health");

var products = app.MapGroup("/api/v1/products").WithTags("Products");
products.MapGet("/", async (string? search, int page, int pageSize, IProductQueries queries, CancellationToken ct) =>
    Results.Ok(await queries.GetAsync(search, page == 0 ? 1 : page, pageSize == 0 ? 20 : pageSize, ct)));

app.Run();

public partial class Program;
