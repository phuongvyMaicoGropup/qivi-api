using Core.Base;
using Core.Entities;
using Core.Repositories;
using Infrastructure.Base;
using Infrastructure.Configurations;
using Infrastructure.Data;
using Infrastructure.Data.Interfaces;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Interfaces;
using Api.Mutations;
using Api.Queries;
using Api.Resolvers;
using Api.Types;
using Api.Subscriptions;
using HotChocolate.Language;
using Serilog;
using Core.Hubs;
using Infrastructure.Hubs;
using Microsoft.AspNetCore.Identity;
using Ninject;
using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);


//Configuration
builder.Services.Configure<MongoDbConfiguration>(
    builder.Configuration.GetSection("MongoDbConfiguration"));

builder.Services.AddScoped<MongoDbConfiguration>();
var mongoDbSettings = builder.Configuration.GetSection("MongoDbConfiguration").Get<MongoDbConfiguration>();



// MongoIdentity
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
      .AddMongoDbStores<ApplicationUser, ApplicationRole, Guid>
      (
          mongoDbSettings.ConnectionString, mongoDbSettings.Database
      );

// Repositories
builder.Services.AddScoped< UserManager<ApplicationUser>>();
builder.Services.AddScoped<ICatalogContext, CatalogContext>();
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IMessageRepository, MessageRepository>();
builder.Services.AddScoped<ICartItemRepository, CartItemRepository>();
builder.Services.AddScoped<IBillRepository, BillRepository>();
builder.Services.AddScoped<IDiscountRepository, DiscountRepository>();
builder.Services.AddScoped<IShoppingSessionRepository, ShoppingSessionRepository>();
builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();
builder.Services.AddScoped<IOrderDetailsRepository, OrderDetailsRepository>();


builder.Services.AddMemoryCache();
builder.Services.AddSha256DocumentHashProvider(HashFormat.Hex);

builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

// Serilog
var logger = new LoggerConfiguration()
.ReadFrom.Configuration(builder.Configuration)
.Enrich.FromLogContext()
.CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

//SignalR

builder.Services.AddSignalR(e => {
    e.EnableDetailedErrors = true; 
    e.MaximumReceiveMessageSize = 102400000;
});
builder.Services.AddResponseCompression(options =>
{
    options.EnableForHttps = true;
    options.MimeTypes =
    ResponseCompressionDefaults.MimeTypes.Concat(
        new[] { "application/octet-stream" });
});

//Cors
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.WithOrigins("https://example.com")
                .AllowAnyHeader()
                .WithMethods("GET", "POST")
                .AllowCredentials();
        });
});




// GraphQL
builder.Services
   .AddGraphQLServer()
   .AddFiltering()
   .AddProjections()
    .AddSorting()
    .AddQueryType(d => d.Name(nameof(Query)))
                .AddTypeExtension<BillQuery>()
                .AddTypeExtension<ProductQuery>()
                .AddTypeExtension<CategoryQuery>()
                .AddTypeExtension<UserQuery>()
                .AddTypeExtension<CartItemQuery>()
                .UseAutomaticPersistedQueryPipeline()
                .AddReadOnlyFileSystemQueryStorage("./persisted_queries")
                .AddInMemoryQueryStorage()
            .AddMutationType(d => d.Name("Mutation"))
                .AddTypeExtension<BillMutation>()
                .AddTypeExtension<ProductMutation>()
                .AddTypeExtension<CategoryMutation>()
                .AddTypeExtension<UserMutation>()
                .AddTypeExtension<CartItemMutation>()
            .AddSubscriptionType(d => d.Name("Subscription"))
                .AddTypeExtension<CustomerSubscription>()
            .AddType<ProductType>()
            .AddType<BillType>()
            .AddType<CategoryType>()
            .AddType<CartItemType>()
            .AddType<CategoryResolver>()
            .AddType<ProductResolver>()
            .AddType<UserResolver>() 

            .AddInMemorySubscriptions();

var app = builder.Build();


app.UseHttpsRedirection();
app.UseWebSockets();
app.UseStaticFiles();

//app.UseAuthorization();
app.UseRouting();
app.UseCors();
app.MapGraphQL("/api/graphql");
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapRazorPages();
    
});
app.MapHub<ChatHub>("/chathub");


app.UseResponseCompression(); 

// IoC
//GlobalHost.DependencyResolver.Register(typeof(SignalRChatHub),() => new SignalRChatHub(new IChatRepository()));


app.Run();


