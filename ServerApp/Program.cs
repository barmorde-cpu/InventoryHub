using Microsoft.Extensions.Caching.Memory;

var builder = WebApplication.CreateBuilder(args);

// 1. Add services to the container.
// Enable CORS to allow the Blazor Client to access this API
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

// Add Memory Cache for Performance Optimization (Activity 4)
builder.Services.AddMemoryCache();

var app = builder.Build();

// 2. Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseCors("AllowAll"); // Apply CORS policy

// 3. Define the Optimized API Endpoint
app.MapGet("/api/products", (IMemoryCache cache) =>
{
    // PERFORMANCE OPTIMIZATION: Check if data is in cache
    return cache.GetOrCreate("products", entry =>
    {
        // Set cache expiration to reduce server load (data refreshes every 5 mins)
        entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);

        // JSON STRUCTURE (Activity 3): Nested Category objects
        return new[]
        {
            new 
            { 
                Id = 1, 
                Name = "Laptop", 
                Price = 1200.50, 
                Stock = 25, 
                Category = new { Id = 101, Name = "Electronics" } 
            },
            new 
            { 
                Id = 2, 
                Name = "Headphones", 
                Price = 50.00, 
                Stock = 100, 
                Category = new { Id = 102, Name = "Accessories" } 
            },
            new 
            { 
                Id = 3, 
                Name = "Office Chair", 
                Price = 150.00, 
                Stock = 10, 
                Category = new { Id = 103, Name = "Furniture" } 
            }
        };
    });
});

app.Run();