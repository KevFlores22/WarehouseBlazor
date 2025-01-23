using WarehouseBlazor.Components;
using WarehouseBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped(o => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7247/")
});

builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<ArticleService>();
builder.Services.AddScoped<BrandService>();
builder.Services.AddScoped<CategoriesService>();
builder.Services.AddScoped<LoanDetailService>();
builder.Services.AddScoped<LoanService>();
builder.Services.AddScoped<LoanValidationService>();
builder.Services.AddScoped<MeasurementUnitService>();
builder.Services.AddScoped<RoleService>();
builder.Services.AddScoped<StatusService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
