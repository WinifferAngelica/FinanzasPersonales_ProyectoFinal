using Finanzas.Data.Context;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FinanzasContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("FinanzasConnection")
    )
);


builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();


app.MapOpenApi();
app.MapScalarApiReference();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
