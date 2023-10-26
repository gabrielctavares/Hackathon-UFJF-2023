
using CodeGeneratorHackathon.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services
    .AddMvc()
    .AddRazorOptions(options =>
    {
        options.ViewLocationFormats.Add("/Pages/Converters/{0}.cshtml");
    });

builder.Services.AddScoped<ViewRenderService>();
builder.Services.AddScoped<CodeGeneratorService>();
builder.Services.AddScoped<ExecuteProjectService>();

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

app.MapRazorPages();

app.Run();
