using WebApi;

var builder = WebApplication.CreateBuilder(args);

builder = ApplicationStart.CustomWebAppBuilder(builder);
 
WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
