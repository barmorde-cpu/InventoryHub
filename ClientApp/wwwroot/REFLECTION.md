# Reflective Summary: Building InventoryHub with Microsoft Copilot

## Integration Code Generation
Copilot significantly accelerated the development process by generating the boilerplate code for the `HttpClient` in Blazor. Instead of manually typing out the `GetFromJsonAsync` syntax, Copilot provided a working snippet that I only needed to slightly modify to match my specific endpoint path.

## Debugging and Resolution
One of the main challenges was the Cross-Origin Resource Sharing (CORS) error when the Client tried to talk to the Server. I asked Copilot "Why is my Blazor app getting a network error when calling the API?", and it correctly identified that I needed to add `builder.Services.AddCors(...)` in the Server's `Program.cs`. This saved me significant debugging time.

## JSON Structuring
When moving to Activity 3, I needed to add Categories. Copilot helped create the C# class structure that mirrored the nested JSON. By prompting "Create a C# class for a Product with a nested Category object," it generated the correct model with properties that matched the API response perfectly.

## Performance Optimization
For the final activity, I asked Copilot how to optimize a Minimal API. It suggested using `IMemoryCache`. It wrote the code to wrap the data return statement in a `cache.GetOrCreate` block. This ensures that if multiple users hit the API simultaneously, the server doesn't have to regenerate the data list every time, improving scalability.