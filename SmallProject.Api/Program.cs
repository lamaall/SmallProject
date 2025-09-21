using SmallProject.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ILoanService, LoanService>();
builder.Services.AddSingleton<IBookService, BookService>();
builder.Services.AddSingleton<IUserService, UserService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();