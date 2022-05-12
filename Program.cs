using Core.Base;
using Core.Entities;
using Core.Repositories;
using Infrastructure.Base;
using Infrastructure.Configurations;
using Infrastructure.Data;
using Infrastructure.Data.Interfaces;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Interfaces;
using qivi_api.Mutations;
using qivi_api.Queries;
using qivi_api.Resolvers;
using qivi_api.Types;
var builder = WebApplication.CreateBuilder(args);


//Configuration
builder.Services.Configure<MongoDbConfiguration>(
    builder.Configuration.GetSection("MongoDbConfiguration"));


builder.Services.AddScoped<MongoDbConfiguration>();


// Repositories
builder.Services.AddScoped<ICatalogContext, CatalogContext>();
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
// GraphQL
builder.Services
   .AddGraphQLServer()
    .AddQueryType(d => d.Name("Query"))
                .AddTypeExtension<ProductQuery>()
                .AddTypeExtension<CategoryQuery>()
            .AddMutationType(d => d.Name("Mutation"))
                .AddTypeExtension<ProductMutation>()
                .AddTypeExtension<CategoryMutation>()
            .AddType<ProductType>()
            .AddType<CategoryType>()
            .AddType<CategoryResolver>()
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

