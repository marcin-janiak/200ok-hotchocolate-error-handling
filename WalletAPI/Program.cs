using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Playground;
using HotChocolate.AspNetCore.Voyager;
using HotChocolate.Types.Descriptors;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using WalletAPI.GraphQL;
using WalletAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IWalletRepository, InMemoryWalletRepository>();

builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<MutationType>()
    .AddConvention<INamingConventions, CustomUnionTypesNamingConventions>();

var app = builder.Build();

app.MapGraphQL();
app.UseVoyager(new VoyagerOptions()
{
    Path = "/voyager",
    QueryPath = "/graphql"
});
app.UsePlayground( new PlaygroundOptions()
{
    Path = "/playground",
    QueryPath = "/graphql"
});

app.Run();