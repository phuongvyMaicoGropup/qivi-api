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
var builder = WebApplication.CreateBuilder(args);


//Configuration
builder.Services.Configure<MongoDbConfiguration>(
    builder.Configuration.GetSection("MongoDbConfiguration"));


builder.Services.AddScoped<MongoDbConfiguration>();


// Repositories
builder.Services.AddScoped<ICatalogContext, CatalogContext>();
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICartItemRepository, CartItemRepository>();
builder.Services.AddScoped<IBillRepository, BillRepository>();
// GraphQL
builder.Services
   .AddGraphQLServer()
   .AddFiltering()
    .AddQueryType(d => d.Name("Query"))
                .AddTypeExtension<BillQuery>()
                .AddTypeExtension<ProductQuery>()
                .AddTypeExtension<CategoryQuery>()
                .AddTypeExtension<UserQuery>()
                .AddTypeExtension<CartItemQuery>()
            .AddMutationType(d => d.Name("Mutation"))
                .AddTypeExtension<BillMutation>()
                .AddTypeExtension<ProductMutation>()
                .AddTypeExtension<CategoryMutation>()
                .AddTypeExtension<UserMutation>()
                .AddTypeExtension<CartItemMutation>()
            .AddType<ProductType>()
            .AddType<BillType>()
            .AddType<CategoryType>()
            .AddType<CartItemType>()
            .AddType<CategoryResolver>()
            .AddType<ProductResolver>()
            .AddType<UserResolver>()
            .AddInMemorySubscriptions(); ;
var app = builder.Build();


app.UseHttpsRedirection();

//app.UseAuthorization();
app.UseRouting(); 
app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL("/api/graphql");
});

app.Run();

