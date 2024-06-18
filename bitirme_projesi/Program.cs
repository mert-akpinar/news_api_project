using bitirme_projesi.BusinessLayer.Abstract;
using bitirme_projesi.BusinessLayer.Concrete;
using bitirme_projesi.DataAccessLayer.Abstract;
using bitirme_projesi.DataAccessLayer.Context;
using bitirme_projesi.DataAccessLayer.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IMessageDal, EfMessageDal>();
builder.Services.AddScoped<IMessageService, MessageManager>();
builder.Services.AddScoped<IAuthorDal, EfAuthorDal>();
builder.Services.AddScoped<IAuthorService, AuthorManager>();
builder.Services.AddScoped<INewsDal, EfNewsDal>();
builder.Services.AddScoped<INewsService, NewsManager>();
builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddDbContext<NewsContext>();
builder.Services.AddControllers();

// CORS yapılandırmasını ekleyin
builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowLocalhost3000",
	builder =>
	{
		builder.WithOrigins("http://localhost:3000")
			   .AllowAnyHeader()
			   .AllowAnyMethod();
	});
});

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

// CORS'u middleware olarak ekleyin
app.UseCors("AllowLocalhost3000");

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
