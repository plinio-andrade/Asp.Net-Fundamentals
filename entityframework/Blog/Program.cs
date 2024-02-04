using Blog.Data;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true;  // suppresses the default behavior of  (auto) ModelState
    });

builder.Services.AddDbContext<BlogDataContext>();

var app = builder.Build();

app.MapControllers();

app.Run();
