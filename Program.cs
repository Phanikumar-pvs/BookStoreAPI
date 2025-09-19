using BookStoreAPI.Data;
using BookStoreAPI.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);




//1.Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularLocalhost",
       policy =>
        {
            policy.WithOrigins("http://localhost:4200") // Angular URL
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});




// Add services to the container.

builder.Services.AddTransient<IBookRepository, BookRepository>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllers();

// Register DbContext
builder.Services.AddDbContext<BookStoreContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BookstoreConnectionString")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAngularLocalhost");
//app.UseCors();  // 👈 no policy name here, uses default

app.UseAuthorization();

app.MapControllers();

app.Run();
