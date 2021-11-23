using Sodashop.DTO.DTOs;
using Sodashop.UI.DataAccess;
using Sodashop.Datasource;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IUserDataAccess<UserDTO>, UserDataAccess>();
builder.Services.AddSingleton<IProductDataAccess<ProductDTO>, ProductsDataAccess>();
builder.Services.AddSingleton<IShoppingCartDataAccess<ShoppingCartDTO>, ShoppingCartDataAccess>();
builder.Services.AddSingleton<IOrderDataAccess<OrderDTO>, OrderDataAccess>();
builder.Services.AddSingleton<SodashopDataSource>();
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

app.MapRazorPages();

app.Run();
