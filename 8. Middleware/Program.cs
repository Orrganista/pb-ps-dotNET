using Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// 1
/*
app.Run(async context =>
{
    await context.Response.WriteAsync("Hello world!");
});
*/


// 2
/*
app.Use(async (context, next) =>
{
    // Do work that can write to the Response.
    await next.Invoke();
    // Do logging or other work that doesn't write to the Response.
});

app.Run(async context =>
{
    await context.Response.WriteAsync("Hello from 2nd delegate.");
});
*/


// 3
/*
app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("Before Invoke from 1st app.Use()\n");
    await next();
    await context.Response.WriteAsync("After Invoke from 1st app.Use()\n");
});

app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("Before Invoke from 2nd app.Use()\n");
    await next();
    await context.Response.WriteAsync("After Invoke from 2nd app.Use()\n");
});

app.Run(async (context) =>
{
    await context.Response.WriteAsync("Hello from 1st app.Run()\n");
});


// the following will never be executed    
app.Run(async (context) =>
{
    await context.Response.WriteAsync("Hello from 2nd app.Run()\n");
});
*/

//4
/*
app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("Before Invoke from 1st app.Use()\n");
    await next();
});

app.Map("/map1", HandleMapTest1);

// the following will never be executed    
app.Run(async (context) =>
{
    await context.Response.WriteAsync("Hello from 2nd app.Run()\n");
});
*/


//
//app.UseMyMiddleware();
//app.MapRazorPages();
app.Run();

 
//4

static void HandleMapTest1(IApplicationBuilder app)
{
    app.Run(async context =>
    {
        await context.Response.WriteAsync("Map Test 1");
    });
}
