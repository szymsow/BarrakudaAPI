var builder = WebApplication.CreateBuilder(args);

builder.AddNlog();
builder.Services.AddControllersExtension();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApplication();
builder.Services.AddInfrastructure();
builder.Services.AddSwaggerGen(s =>
{
    s.EnableAnnotations();
});
builder.AddJwtAuthentication();
builder.Services.AddBarrakudaServices();
builder.AddContext();

var app = builder.Build();
await app.Seed();

if (app.Environment.IsDevelopment())
    app.UseSwaggerConfig();
app.AddMiddleware();
app.UseAuthentication();
app.UseHttpsRedirection();
app.UseRouting();
app.UseCors(opt =>
{
    opt.AllowAnyHeader().AllowAnyHeader().AllowAnyMethod().AllowCredentials().WithOrigins("http://localhost:3000");
});
app.UseAuthorization();

app.MapControllers();

app.Run();
