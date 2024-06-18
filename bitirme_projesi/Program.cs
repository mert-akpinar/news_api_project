using bitirme_projesi.BusinessLayer.Abstract;
using bitirme_projesi.BusinessLayer.Concrete;
using bitirme_projesi.DataAccessLayer.Abstract;
using bitirme_projesi.DataAccessLayer.Context;
using bitirme_projesi.DataAccessLayer.EntityFramework;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowSpecificOrigin",
		policy =>
		{
			policy.WithOrigins("http://localhost:3000")
				  .AllowAnyHeader()
				  .AllowAnyMethod();
		});
});
builder.Services.AddControllers();

var app = builder.Build();
// CORS politikasını kullanın
app.UseCors("AllowSpecificOrigin");

// Diğer middleware'ler
if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
}

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
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
