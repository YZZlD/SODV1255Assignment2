using SODV1255Assignment2.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

//Singletons are used to persist List information between repository access to provide temporary storage for the program's runtime.
builder.Services.AddSingleton<BookRepository>();
builder.Services.AddSingleton<BorrowingRepository>();
builder.Services.AddSingleton<ReaderRepository>();
var app = builder.Build();

app.MapControllers();

app.Run();
